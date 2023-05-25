<template>
  <div class="card shadow mb-3" role="button" v-on:click="$emit('update:purchaseLine', updatedPurchaseLine)">
    <div class="card-header cstm-primary-light text-center">
      <h3>{{ product?.name }}</h3>
      <p>Selected: {{ purchaseLine?.quantity ?? 0 }}</p>
    </div>
    <div class="card-body cstm-secondary-light text-center">
      <p>Price: {{ product?.price.toFixed(2) }} €</p>
      <p>In stock: {{ product?.remainingQuantity }}</p>
    </div>
  </div>
</template>
  
<script lang="ts">
import type { Product } from '@/interfaces/product';
import type { PurchaseLine } from '@/interfaces/purchase';
import { computed, type PropType } from 'vue';

export default {
  props: {
    product: {
      type: Object as PropType<Product>,
      required: true
    },
    purchaseLine: Object as PropType<PurchaseLine>
  },
  setup(props) {
    const updatedPurchaseLine = computed(() => {
      let purchaseLine = props.purchaseLine;

      if (!purchaseLine) {
        purchaseLine = { quantity: 0, productId: props.product.id } as PurchaseLine
      }

      if (purchaseLine.quantity < props.product.remainingQuantity) {
        return { ...purchaseLine, quantity: purchaseLine.quantity + 1 } as PurchaseLine
      }

      return purchaseLine;
    });

    return { updatedPurchaseLine }
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
  