import type { Sale } from '@/interfaces/sale';
import { get, getById, post } from './api';

const SALES_PATH = 'Sales';

export const getSales = async (): Promise<Sale[]> => {
  return await get<Sale>(SALES_PATH);
};

export const getSale = async (id: number): Promise<Sale> => {
  return await getById<Sale>(SALES_PATH, id);
};

export const postSale = async (sale: Sale): Promise<Sale> => {
  return await post<Sale>(SALES_PATH, sale);
};
