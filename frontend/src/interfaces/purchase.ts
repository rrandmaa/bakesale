export interface PurchaseLine {
  id: number;
  purchaseId: number;
  productId: number;
  quantity: number;
}

export interface Purchase {
  id: number;
  purchaseLines: PurchaseLine[];
}
