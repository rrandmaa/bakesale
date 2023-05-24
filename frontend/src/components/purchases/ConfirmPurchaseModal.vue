<template>
    <div class="modal fade" :id="tagId" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Review purchase</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div v-if="!isPurchaseValid()" class="alert alert-danger" role="alert">
                        Some products appear to have run out of stock!
                    </div>
                    <table class="table table-bordered table-responsive mt-2">
                        <thead class="table-">
                            <tr class="text-center">
                                <th scope="col">Product</th>
                                <th scope="col">Quantity</th>
                                <th scope="col">Quantity in stock</th>
                            </tr>
                        </thead>
                        <tbody class="text-center">
                            <tr :class="isPurchaseLineValid(line) ? 'table-success' : 'table-danger'"
                                v-for="line in purchaseLinesWithContent" v-bind:key="line?.id">
                                <td>{{ getProductName(line?.productId) }}</td>
                                <td>{{ line?.quantity }}</td>
                                <td>{{ getProductRemainingQuantity(line?.productId) }}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer justify-content-center">
                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Back to products</button>
                    <button type="button" class="btn btn-success">Confirm purchase</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import type { PurchaseLine } from '@/interfaces/purchase';
import { useSalesStore } from '@/stores/sales';
import { computed, type PropType } from 'vue';
import { useRoute } from 'vue-router';

export default {
    props: {
        tagId: {
            type: String,
            required: true,
        },
        purchaseLines: {
            type: Object as PropType<PurchaseLine[]>,
            required: true,
        }
    },
    async setup(props) {
        const route = useRoute();
        const salesStore = useSalesStore();
        const sale = await salesStore.refreshSaleData(Number(route.params.id));

        const purchaseLinesWithContent = computed<PurchaseLine[]>(() => props.purchaseLines.filter(x => x.productId));

        const isPurchaseValid = () => {
            return props.purchaseLines.every(x => isPurchaseLineValid(x));
        }

        const isPurchaseLineValid = (line: PurchaseLine) => {
            return getProductRemainingQuantity(line.productId) >= line.quantity;
        }

        const getProductName = (id: number) => {
            return sale.products.find(x => x.id === id)?.name ?? "";
        }

        const getProductRemainingQuantity = (id: number) => {
            return sale.products.find(x => x.id === id)?.remainingQuantity ?? 0;
        }

        return {
            purchaseLinesWithContent,
            isPurchaseValid,
            isPurchaseLineValid,
            getProductName,
            getProductRemainingQuantity,
        }
    }
}
</script>
