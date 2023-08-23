import { AxiosResponse } from "axios";
import { apiFullstackAfiliados } from ".";
import { ResponseTransaction } from "../interfaces/responseTransaction";

export async function SendFile(file: File) {

    let formData = new FormData();

    formData.append('file', file);

    return apiFullstackAfiliados.post('transaction', formData, {
        headers: {
            "Content-Type": "multipart/form-data",
        }
    });
}

export async function GetAllTransactions() : Promise<AxiosResponse<ResponseTransaction>> {
    return apiFullstackAfiliados.get('transaction');
}