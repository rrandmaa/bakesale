export enum PurchaseStatus {
    Pending,
    Completed
}

export interface PurchaseLine {
    id: number;
    purchaseId: number;
    productId: number;
    quantity: number;
}

export interface Purchase {
    id: number;
    status: PurchaseStatus;
    purchaseLines: PurchaseLine[];
}
