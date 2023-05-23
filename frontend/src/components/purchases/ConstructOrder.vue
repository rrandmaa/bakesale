<template>
  <div class="container mt-4">
    <div class="row row-cols-auto justify-content-center">
      <div v-for="product in sale.products" v-bind:key="product.id" class="col">
        <ProductCard :product="product" />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { useSalesStore } from '@/stores/sales';
import { useRoute } from 'vue-router';
import ProductCard from '../products/ProductCard.vue';

export default {
  components: { ProductCard },
  async setup() {
    const route = useRoute();
    const salesStore = useSalesStore();
    const sale = await salesStore.refreshSaleData(Number(route.params.id));
    return {
      sale,
    };
  },
};
</script>
