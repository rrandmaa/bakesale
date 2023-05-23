<template>Construct order</template>

<script lang="ts">
import { useSalesStore } from '@/stores/sales';
import { useRoute } from 'vue-router';

export default {
  async setup() {
    const route = useRoute();
    const salesStore = useSalesStore();

    const sale = await salesStore.refreshSaleData(Number(route.params.id));
  }
};
</script>
