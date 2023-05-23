<template>
  <div class="container mt-4">
    <div class="row row-cols-auto justify-content-center">
      <div v-for="(product, i) in sale.products" v-bind:key="i" class="col">
        <ProductCard :product="product" :purchase-line="purchaseLines[i]"
          v-on:increment="() => incrementPurchaseLineQuantity(i, product.id)" />
      </div>
    </div>
  </div>
  <span class="row fixed-bottom text-center">
    <div class="container border bg-primary text-light">
      {{ totalPrice.toFixed(2) }}
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

    return {
      sale,
      purchaseLines,
      totalPrice,
      incrementPurchaseLineQuantity,
    };
  },
};
</script>
