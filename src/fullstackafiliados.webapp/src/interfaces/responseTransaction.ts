import { Transaction } from "./transaction";

export interface ResponseTransaction {
    success: boolean;
    data: Transaction[];
}