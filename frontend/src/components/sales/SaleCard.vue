<template>
  <div class="card mb-3">
    <div class="card-header cstm-primary-light text-center">
      <h3>{{ sale?.name }}</h3>
    </div>
    <div class="card-body cstm-secondary-light text-center">
      <p>{{ SaleStatus[sale?.status] }}</p>
      <a href="#">Go to sale</a>
    </div>
  </div>
</template>

<script lang="ts">
import { SaleStatus, type Sale } from '@/interfaces/sale';
import type { PropType } from 'vue';

export default {
  props: {
    sale: {
      type: Object as PropType<Sale>,
      required: true
    }
  },
  setup() {
    return {
      SaleStatus
    };
  }
};
</script>

<style scoped>
.card {
  min-height: 9rem;
  width: 15.5rem;
}
.card-body {
  border-radius: 5%;
}
</style>
