import type { CashReturnResponseLine } from '@/interfaces/cashReturn';
import { get } from './api';

const CASH_RETURN_PATH = 'CashReturn';

export const calculateCashReturn = async (
  cashPaid: number,
  totalPrice: number
): Promise<CashReturnResponseLine[]> => {
  return await get<CashReturnResponseLine>(
    CASH_RETURN_PATH + `?cashPaid=${cashPaid}&totalPrice=${totalPrice}`
  );
};
