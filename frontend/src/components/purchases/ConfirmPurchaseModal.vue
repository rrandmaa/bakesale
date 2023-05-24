<template>
    <div class="modal fade" :id="tagId" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Review purchase</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="container text-center">
                        <p>Total amount to be paid: {{ totalPrice.toFixed(2) }} €</p>
                        <div class="accordion accordion-flush">
                            <div class="accordion-item">
                                <h2 class="accordion-header" id="headingOne">
                                    <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne">
                                        Cash return
                                    </button>
                                </h2>
                                <div id="collapseOne" class="accordion-collapse collapse show"
                                    data-bs-parent="#accordionExample">
                                    <div class="container mt-3">
                                        <div class="input-group mb-3">
                            <input type="text" class="form-control" placeholder="Cash received" :min="totalPrice"
                                v-model="cashPaid">
                            <button class="btn btn-primary" type="button" v-on:click="getCashReturn">Calculate
                                return</button>
                        </div>
                        <table class="table table-border-bottom table-responsive">
                            <thead class="table">
                                <tr class="text-center">
                                    <th scope="col">Note or coin</th>
                                    <th scope="col">Amount</th>
                                </tr>
                            </thead>
                            <tbody class="text-center">
                                <tr v-for="(cashReturnLine, i) in cashReturn" v-bind:key="i">
                                    <td>{{ cashReturnLine.value }} €</td>
                                    <td>{{ cashReturnLine.count }}</td>
                                </tr>
                            </tbody>
                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>              
                    </div>
                    <div v-if="!purchaseIsValid" class="alert alert-danger" role="alert">
                        Some products appear to have run out of stock!
                    </div>
                    <p class="text-center"> Purchase list: </p>
                    <table class="table table-bordered table-responsive mt-2">
                        <thead class="table">
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
                    <button type="button" class="btn btn-success" data-bs-dismiss="modal"
                        v-if="purchaseIsValid && purchaseLinesWithContent.length > 0" v-on:click="confirmPurchase">Complete
                        purchase</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { calculateCashReturn } from '@/api/cashReturn.api';
import { postPurchase } from '@/api/purchases.api';
import type { Purchase, PurchaseLine } from '@/interfaces/purchase';
import type { CashReturnResponseLine } from '@/interfaces/cashReturn';
import { useSalesStore } from '@/stores/sales';
import { computed, ref, type PropType } from 'vue';
import { useRoute, useRouter } from 'vue-router';

export default {
    props: {
        tagId: {
            type: String,
            required: true,
        },
        purchaseLines: {
            type: Object as PropType<PurchaseLine[]>,
            required: true,
        },
        totalPrice: {
            type: Number,
            required: true,
        }
    },
    async setup(props) {
        const route = useRoute();
        const router = useRouter();
        const salesStore = useSalesStore();

        const sale = computed(() => salesStore.sales.find(x => x.id === Number(route.params.id)));
        const purchaseLinesWithContent = computed<PurchaseLine[]>(() => props.purchaseLines.filter(x => x.productId));
        const purchaseIsValid = computed(() => purchaseLinesWithContent.value.every(x => isPurchaseLineValid(x)));

        const cashPaid = ref<number>();
        const cashReturn = ref<CashReturnResponseLine[]>([]);

        const isPurchaseLineValid = (line: PurchaseLine) => {
            return getProductRemainingQuantity(line.productId) >= line.quantity;
        }

        const getProductName = (id: number) => {
            return sale.value?.products.find(x => x.id === id)?.name ?? "";
        }

        const getProductRemainingQuantity = (id: number) => {
            return sale.value?.products.find(x => x.id === id)?.remainingQuantity ?? 0;
        }

        const getCashReturn = async () => {
            if (!cashPaid.value) return;
            if (cashPaid.value > props.totalPrice) {
                cashReturn.value = await calculateCashReturn(cashPaid.value, props.totalPrice);
            }
        }

        const confirmPurchase = async () => {
            if (!purchaseIsValid.value) return;

            await postPurchase({ purchaseLines: purchaseLinesWithContent.value } as Purchase);

            router.push(`/sale/${route.params.id}`);
        }

        return {
            purchaseLinesWithContent,
            purchaseIsValid,
            cashPaid,
            cashReturn,
            isPurchaseLineValid,
            getProductName,
            getProductRemainingQuantity,
            getCashReturn,
            confirmPurchase,
        }
    }
}
</script>
