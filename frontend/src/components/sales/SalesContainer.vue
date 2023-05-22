<template>
  <div class="container mt-4">
    <div class="row row-cols-auto justify-content-center">
      <div v-for="sale in salesStore.sales" v-bind:key="sale.id" class="col">
        <SaleCard :sale="sale" />
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import SaleCard from './SaleCard.vue';
import { useSalesStore } from '@/stores/sales';

export default {
  async setup() {
    const salesStore = useSalesStore();

    return {
      salesStore
    };
  },
  components: { SaleCard }
};
</script>
