<template>
  <div class="card shadow mb-3">
    <div class="card-header cstm-primary-light text-center">
      <h3>{{ sale?.name }}</h3>
    </div>
    <div class="card-body cstm-secondary-light text-center">
      <p>{{ SaleStatus[sale?.status] }}</p>
      <a role="button" class="link-primary" v-on:click="routeToSaleHome">Go to sale</a>
    </div>
  </div>
</template>

<script lang="ts">
import { SaleStatus, type Sale } from '@/interfaces/sale';
import type { PropType } from 'vue';
import { useRouter } from 'vue-router';

export default {
  props: {
    sale: {
      type: Object as PropType<Sale>,
      required: true
    }
  },
  setup(props) {
    const router = useRouter();

    const routeToSaleHome = () => {
      router.push(`/sale/${props.sale.id}`);
    };

    return {
      SaleStatus,
      routeToSaleHome
    };
  }
};
</script>

<style scoped>
.card {
  min-height: 9rem;
  width: 15.5rem;
}
.card-header {
  height: 5rem;
}
.card-body {
  border-radius: 5%;
}
</style>
