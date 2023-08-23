export interface TransactionToTable {
    seller: string;
    transactions: {
        processedAt: Date;
        product: string;
        value: number;
        transactionType: string;
    }[];
    totalValue: number;
}