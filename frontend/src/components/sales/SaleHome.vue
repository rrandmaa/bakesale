<template>
  <PageHeader :title="sale.name" />
  <div class="container text-center mt-5">
    <button role="button" class="btn btn-primary" v-on:click="routeToNewOrder">
      Start new order
    </button>
  </div>
</template>

<script lang="ts">
import PageHeader from '@/components/common/PageHeader.vue';
import type { Sale } from '@/interfaces/sale';
import { useSalesStore } from '@/stores/sales';
import { useRoute, useRouter } from 'vue-router';

export default {
  components: {
    PageHeader
  },
  async setup() {
    const route = useRoute();
    const router = useRouter();
    const salesStore = useSalesStore();

    const sale: Sale = await salesStore.refreshSaleData(Number(route.params.id));

    const routeToNewOrder = () => {
      router.push(`/sale/${sale.id}/neworder`);
    };

    return {
      sale,
      routeToNewOrder
    };
  }
};
</script>
