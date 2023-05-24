<template>
  <div class="container product-cards-container mt-4">
    <div class="row row-cols-auto justify-content-center">
      <div v-for="(product, i) in sale.products" v-bind:key="i" class="col">
        <ProductCard :product="product" :purchase-line="purchaseLines[i]"
          v-on:increment="() => incrementPurchaseLineQuantity(i, product.id)" />
      </div>
    </div>
  </div>
  <span class="row fixed-bottom">
    <div class="container total-price-container border bg-primary text-light text-center">
      <div class="mt-3">
        Total price: {{ totalPrice.toFixed(2) }} €
      </div>
      <br />
      <button class="btn btn-light shadow mx-2" v-on:click="clearPurchaseLines">Reset</button>
      <button class="btn btn-success shadow mx-2">Checkout</button>
    </div>
  </span>
</template>

<script lang="ts">
import { useSalesStore } from '@/stores/sales';
import { useRoute } from 'vue-router';
import ProductCard from '../products/ProductCard.vue';
import type { PurchaseLine } from '@/interfaces/purchase';
import { computed, ref } from 'vue';

export default {
  components: { ProductCard },
  async setup() {
    const route = useRoute();
    const salesStore = useSalesStore();
    const sale = await salesStore.refreshSaleData(Number(route.params.id));
    const purchaseLines = ref<PurchaseLine[]>(new Array<PurchaseLine>(sale.products.length));

    const totalPrice = computed(() => purchaseLines.value.reduce((sum, line) => {
      return sum + (line.quantity * getProductPrice(line.productId))
    }, 0));

    const getProductPrice = (id: number) => {
      return sale.products.find(x => x.id === id)?.price ?? 0;
    }

    const incrementPurchaseLineQuantity = (index: number, productId: number) => {
      if (!purchaseLines.value[index]) {
        purchaseLines.value[index] = { quantity: 0, productId } as PurchaseLine;
      }
      purchaseLines.value[index].quantity++;
    }

    const clearPurchaseLines = () => {
      purchaseLines.value = new Array<PurchaseLine>(sale.products.length);
    }

    return {
      sale,
      purchaseLines,
      totalPrice,
      incrementPurchaseLineQuantity,
      clearPurchaseLines,
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
