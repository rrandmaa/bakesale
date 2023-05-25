<template>
  <p class="text-center">Purchase list:</p>
  <table class="table table-bordered table-responsive mt-2">
    <thead class="table">
      <tr class="text-center">
        <th scope="col">Product</th>
        <th scope="col">Quantity</th>
        <th scope="col">Quantity in stock</th>
      </tr>
    </thead>
    <tbody class="text-center">
      <tr
        :class="isPurchaseLineValid(line) ? 'table-success' : 'table-danger'"
        v-for="line in purchaseLines"
        v-bind:key="line?.id"
      >
        <td>{{ salesStore.getSaleProduct(line?.productId)?.name }}</td>
        <td>{{ line?.quantity }}</td>
        <td>{{ salesStore.getSaleProduct(line?.productId)?.remainingQuantity }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import type { PurchaseLine } from '@/interfaces/purchase';
import { useSalesStore } from '@/stores/sales';
import type { PropType } from 'vue';

export default {
  props: {
    purchaseLines: {
      type: Object as PropType<PurchaseLine[]>,
      required: true
    }
  },
  setup() {
    const salesStore = useSalesStore();

    const isPurchaseLineValid = (line: PurchaseLine) => {
      return (salesStore.getSaleProduct(line.productId)?.remainingQuantity ?? 0) >= line.quantity;
    };

    return {
      salesStore,
      isPurchaseLineValid
    };
  }
};
</script>
