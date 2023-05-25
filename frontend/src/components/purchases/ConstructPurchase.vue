<template>
  <div class="container product-cards-container mt-4">
    <div class="row row-cols-auto justify-content-center">
      <div v-for="(product, i) in salesStore.saleProducts" v-bind:key="i" class="col">
        <ProductCard :product="product" :purchase-line="purchaseLines[i]"
          v-on:increment="() => incrementPurchaseLineQuantity(i, product.id)" />
      </div>
    </div>
  </div>
  <CheckoutFooter 
    :purchase-lines="purchaseLines"
    v-on:resetButtonClick="clearPurchaseLines"
    v-on:checkoutButtonClick="fetchSaleData"
  />
</template>

<script lang="ts">
import { useSalesStore } from '@/stores/sales';
import { useRoute } from 'vue-router';
import ProductCard from '../products/ProductCard.vue';
import type { PurchaseLine } from '@/interfaces/purchase';
import { ref } from 'vue';
import CheckoutFooter from './CheckoutFooter.vue';

export default {
  components: { ProductCard, CheckoutFooter },
  async setup() {
    const route = useRoute();
    const salesStore = useSalesStore();
    const purchaseLines = ref<PurchaseLine[]>(new Array<PurchaseLine>(salesStore.saleProducts?.length ?? 0));

    const getProductRemainingQuantity = (id: number) => {
      return salesStore.getSaleProduct(id)?.remainingQuantity ?? 0;
    }

    const incrementPurchaseLineQuantity = (index: number, productId: number) => {
      if (!purchaseLines.value[index]) {
        purchaseLines.value[index] = { quantity: 0, productId } as PurchaseLine;
      }
      if (purchaseLines.value[index].quantity < getProductRemainingQuantity(productId)) {
        purchaseLines.value[index].quantity++;
      }
    }

    const clearPurchaseLines = () => {
      purchaseLines.value = new Array<PurchaseLine>(salesStore.sale?.products.length ?? 0);
    }

    const fetchSaleData = async () => {
      await salesStore.fetchSale(Number(route.params.id));
    }

    await salesStore.fetchSale(Number(route.params.id));

    return {
      salesStore,
      purchaseLines,
      incrementPurchaseLineQuantity,
      clearPurchaseLines,
      fetchSaleData,
    };
  },
};
</script>

<style scoped>
.product-cards-container {
  margin-bottom: 8rem;
}

.total-price-container {
  height: 8rem;
}
</style>
