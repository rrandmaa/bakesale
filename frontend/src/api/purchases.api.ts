import type { Purchase } from '@/interfaces/purchase';
import { post } from './api';

const getPurchasesPath = (saleId: number) => `Sales/${saleId}/Purchases`;

export const postPurchase = async (saleId: number, purchase: Purchase): Promise<Purchase> => {
  return await post<Purchase>(getPurchasesPath(saleId), purchase);
};
