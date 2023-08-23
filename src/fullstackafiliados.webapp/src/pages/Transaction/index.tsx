import React, { useEffect, useState } from "react";
import './styles.scss'
import { Divider, Grid } from "@mui/material";
import { LoadingButton } from "@mui/lab";
import { Upload } from "@mui/icons-material";
import Snackbar from '@mui/material/Snackbar';
import MuiAlert, { AlertProps, AlertColor } from '@mui/material/Alert';
import Swal from "sweetalert2";
import { GetAllTransactions, SendFile } from "../../services/transaction";
import { AxiosError } from "axios";
import { Transaction } from "../../interfaces/transaction";
import { TransactionToTable } from "../../interfaces/transactionToTable";
import CustomTable from "../../components/CustomTable";

const Alert = React.forwardRef<HTMLDivElement, AlertProps>(function Alert(
    props,
    ref,
) {
    return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

interface MessageState {
    text: string;
    type: AlertColor | undefined;
}

export function TransactionPage() {

    const [file, setFile] = useState<File>();
    const [loading, setLoading] = useState<boolean>(false);
    const [open, setOpen] = React.useState(false);
    const [transactions, setTransactions] = useState<TransactionToTable[]>([]);
    const [finalValue, setFinalValue] = useState<number>(0.0);
    const [message, setMessage] = React.useState<MessageState>({
        text: "",
        type: undefined,
    });

    useEffect(() => {
        async function get() {
            try {
                const response = await GetAllTransactions();

                if (response.status !== 200)
                    setSnackbarMessage({
                        text: "Ops! Ocorreu um erro ao obter as transações.",
                        type: "error"
                    });

                const transactions = response.data.data;

                toGroupBySeller(transactions);

                calculateFinalValue(transactions);
            }
            catch (error: any | AxiosError) {
                console.log(error);
            }
        }

        get();
    }, []);

    function calculateFinalValue(arrTransactions: Transaction[]) {
        let finalValue = 0;

        arrTransactions.forEach(transaction => {
            if (transaction.transactionType.nature.toUpperCase() === "ENTRADA")
                finalValue += transaction.value;
            else
                finalValue -= transaction.value;
        });

        setFinalValue(finalValue);
    }

    function toGroupBySeller(arrTransactions: Transaction[]) {

        const sellers = arrTransactions.map(item => item.seller)
            .filter((value, index, self) => self.indexOf(value) === index);

        let sales: TransactionToTable[] = [];

        sellers.forEach(seller => {

            let transaction = {
                seller: "",
                transactions: [],
                totalValue: 0,
            } as TransactionToTable;

            transaction.seller = seller;

            const transactionsBySeller = arrTransactions.filter(t => t.seller === seller);

            let totalValue = 0;

            transactionsBySeller.forEach(ts => {
                transaction.transactions = [...transaction.transactions, {
                    processedAt: ts.processedAt,
                    product: ts.product,
                    value: ts.value,
                    transactionType: ts.transactionType.description,
                }];

                totalValue += ts.value;
            });

            transaction.totalValue = totalValue;

            sales = [...sales, transaction];

        })

        setTransactions(sales);

    }

    const handleClose = (event?: React.SyntheticEvent | Event, reason?: string) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpen(false);
    };

    function handleChangeFile(event: React.FormEvent) {
        const files = (event.target as HTMLInputElement).files;

        if (files && files.length > 0) {
            setFile(files[0])
        }
    }

    function handleSendFile() {
        if (!file)
            setSnackbarMessage({
                text: "Selecione um arquivo para realizar o envio.",
                type: "warning"
            });
        else if (file.type !== "text/plain")
            setSnackbarMessage({
                text: "Você precisa selecionar um arquivo .txt!",
                type: "error"
            });

        Swal.fire({
            title: 'Importação de transações',
            html: `Deseja realmente importar o arquivo <b>${file?.name}</b>?`,
            icon: 'question',
            showConfirmButton: true,
            confirmButtonText: 'Confirmar',
            confirmButtonColor: '#2E7D32',
            showCancelButton: true,
            cancelButtonColor: '#D32F2F',
            cancelButtonText: 'Cancelar',
        }).then(async (result) => {
            if (result.isConfirmed) {
                setLoading(true);
                await SendFile(file!)
                    .then(response => {
                        if (response.status === 200) {
                            setSnackbarMessage({
                                text: "Arquivo importado com sucesso!",
                                type: "success"
                            });
                            setLoading(false);
                        }
                    })
                    .catch(error => {
                        setLoading(false);
                        console.log(error);
                    });

            }
        });
    }

    function setSnackbarMessage(message: MessageState) {
        setMessage(message);
        setOpen(true);
    }

    return (
        <Grid container spacing={3}>
            <Snackbar
                open={open}
                autoHideDuration={3000}
                onClose={handleClose}
                anchorOrigin={{
                    vertical: 'top',
                    horizontal: 'right'
                }}>
                <Alert onClose={handleClose} severity={message.type} sx={{ width: '100%' }}>
                    {message.text}
                </Alert>
            </Snackbar>
            <Grid item xs={6} className="flex flex-center container-upload">
                <span>Selecione um arquivo para importar as transações</span>
                <input type="file" onChange={handleChangeFile} accept=".txt" />
                <LoadingButton
                    onClick={handleSendFile}
                    endIcon={<Upload />}
                    loading={loading}
                    loadingPosition="center"
                    variant="contained"
                >
                    Enviar
                </LoadingButton>
            </Grid>
            <Grid item xs={6}>
                {transactions.map(t =>
                    <Grid sx={{ mt: 10 }}>
                        <CustomTable transaction={t} />
                    </Grid>
                )}
                <Grid className="grid-final-value">
                    Valor Total: <span>$ {finalValue}</span>
                </Grid>
            </Grid>

        </Grid>
    )
}