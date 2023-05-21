import type { Sale } from "@/interfaces/sale";
import { get } from "./api";

const SALES_PATH = "sales";

export const getSales = async (): Promise<Sale[]> => {
    return get<Sale>(SALES_PATH);
}
