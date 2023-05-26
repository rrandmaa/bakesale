<template>
  <div class="container product-cards-container mt-4">
    <div class="row row-cols-auto justify-content-center">
      <div v-for="(product, i) in salesStore.saleProducts" v-bind:key="i" class="col">
        <ProductCard :product="product" v-model:purchase-line="purchaseLines[i]" />
      </div>
    </div>
  </div>
  <CheckoutFooter :purchase-lines="purchaseLines" v-on:resetButtonClick="clearPurchaseLines"
    v-on:checkoutButtonClick="async () => await salesStore.fetchSale(Number(route.params.id))" />
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
    const purchaseLines = ref<PurchaseLine[]>(
      new Array<PurchaseLine>(salesStore.saleProducts?.length ?? 0)
    );

    const clearPurchaseLines = () => purchaseLines.value = new Array<PurchaseLine>(salesStore.sale?.products.length ?? 0);

    await salesStore.fetchSale(Number(route.params.id));

    return {
      route,
      salesStore,
      purchaseLines,
      clearPurchaseLines
    };
  }
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
