import * as React from 'react';
import { styled } from '@mui/material/styles';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell, { tableCellClasses } from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { TransactionToTable } from '../../interfaces/transactionToTable';
import moment from 'moment';

const StyledTableCell = styled(TableCell)(({ theme }) => ({
    [`&.${tableCellClasses.head}`]: {
        backgroundColor: theme.palette.common.black,
        color: theme.palette.common.white,
    },
    [`&.${tableCellClasses.body}`]: {
        fontSize: 14,
    },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
    '&:nth-of-type(odd)': {
        backgroundColor: theme.palette.action.hover,
    },

    '&:last-child td, &:last-child th': {
        border: 0,
    },
}));

interface CustomTableProps {
    transaction: TransactionToTable;
}

interface DataTable {
    seller: string;
    processedAt: Date;
    product: string;
    value: number;
    transactionType: string;
}

export default function CustomTable({ transaction }: CustomTableProps) {

    const [rows, setRows] = React.useState<DataTable[]>([]);

    React.useEffect(() => {
        createData(transaction);
    }, [transaction]);

    function createData(sales: TransactionToTable) {
        let rows: DataTable[] = [];

        sales.transactions.forEach(transaction => {
            rows = [...rows, {
                seller: sales.seller,
                processedAt: transaction.processedAt,
                product: transaction.product,
                value: transaction.value,
                transactionType: transaction.transactionType
            }]
        });

        setRows(rows);
    }

    return (
        <>
            {rows.length > 0 ?
                <TableContainer component={Paper} sx={{ maxWidth: '95%' }}>
                    <Table  aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <StyledTableCell>Vendedor</StyledTableCell>
                                <StyledTableCell align="center">Data de processamento</StyledTableCell>
                                <StyledTableCell align="center">Produto</StyledTableCell>
                                <StyledTableCell align="center">Valor</StyledTableCell>
                                <StyledTableCell align="center">Tipo de transação</StyledTableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {rows.map((row) => (
                                <StyledTableRow key={row.seller}>
                                    <StyledTableCell component="th" scope="row">
                                        {row.seller}
                                    </StyledTableCell>
                                    <StyledTableCell align="center">{moment(row.processedAt).format("DD/MM/YYYY")}</StyledTableCell>
                                    <StyledTableCell align="center">{row.product}</StyledTableCell>
                                    <StyledTableCell align="center">{row.value}</StyledTableCell>
                                    <StyledTableCell align="center">{row.transactionType}</StyledTableCell>
                                </StyledTableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
                : <></>
            }
        </>
    );
}