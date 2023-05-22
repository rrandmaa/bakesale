import type { Sale } from '@/interfaces/sale';
import { get, post } from './api';

const SALES_PATH = 'sales';

export const getSales = async (): Promise<Sale[]> => {
  return get<Sale>(SALES_PATH);
};

export const postSale = async (sale: Sale): Promise<Sale> => {
  return post<Sale>(SALES_PATH, sale);
}
