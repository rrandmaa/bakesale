export enum ProductType {
  Edible,
  SecondHand
}

export interface Product {
  id: number;
  name: string;
  type: ProductType;
  saleId: number;
  initialQuantity: number;
  price: number;
  remainingQuantity: number;
}
