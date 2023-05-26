import type { Product } from './product';

export interface Sale {
  id: number;
  name: string;
  products: Product[];
}
