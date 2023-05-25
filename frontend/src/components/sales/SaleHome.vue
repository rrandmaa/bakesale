<template>
  <PageHeader :title="sale?.name ?? ''" />
  <div class="container text-center mt-5">
    <button role="button" class="btn btn-primary shadow" v-on:click="routeToNewOrder">
      Start new order
    </button>
  </div>
</template>

<script lang="ts">
import PageHeader from '@/components/common/PageHeader.vue';
import { useSalesStore } from '@/stores/sales';
import { computed } from 'vue';
import { useRoute, useRouter } from 'vue-router';

export default {
  components: {
    PageHeader
  },
  async setup() {
    const route = useRoute();
    const router = useRouter();
    const salesStore = useSalesStore();

    const sale = computed(() => salesStore.sales.find((x) => x.id === Number(route.params.id)));

    const routeToNewOrder = () => {
      router.push(`/sale/${sale.value?.id}/neworder`);
    };

    return {
      sale,
      routeToNewOrder
    };
  }
};
</script>
