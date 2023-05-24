import type { Purchase } from "@/interfaces/purchase";
import { post } from "./api";

const PURCHASES_PATH = "Purchases";

export const postPurchase = async (purchase: Purchase): Promise<Purchase> => {
    return await post<Purchase>(PURCHASES_PATH, purchase);
  };
