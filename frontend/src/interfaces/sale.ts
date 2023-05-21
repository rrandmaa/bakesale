import type { Product } from "./product";

export enum SaleStatus {
  Active,
  Finished
}

export interface Sale {
  id: number;
  name: string;
  status: SaleStatus;
  products: Product[];
}
