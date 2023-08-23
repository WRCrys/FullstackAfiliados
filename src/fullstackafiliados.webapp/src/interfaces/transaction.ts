import { TransactionType } from "./transactionType";

export interface Transaction {
    id: number;
    processedAt: Date;
    product: string;
    value: number;
    seller: string;
    transactionType: TransactionType;
}