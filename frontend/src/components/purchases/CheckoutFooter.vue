<template>
  <span class="row fixed-bottom">
    <div class="container total-price-container border bg-primary text-light text-center">
      <div class="mt-3">Total price: {{ totalPrice.toFixed(2) }} €</div>
      <br />
      <button class="btn btn-light shadow mx-2" v-on:click="$emit('resetButtonClick')">
        Reset
      </button>
      <button
        class="btn btn-success shadow mx-2"
        data-bs-toggle="modal"
        :data-bs-target="`#${MODAL_TAG_ID}`"
        v-on:click="$emit('checkoutButtonClick')"
      >
        Checkout
      </button>
    </div>
  </span>
  <ConfirmPurchaseModal
    :tag-id="MODAL_TAG_ID"
    :purchase-lines="purchaseLines"
    :total-price="totalPrice"
  />
</template>

<script lang="ts">
import type { PurchaseLine } from '@/interfaces/purchase';
import { computed, type PropType } from 'vue';
import ConfirmPurchaseModal from './ConfirmPurchaseModal.vue';
import { useSalesStore } from '@/stores/sales';

export default {
  components: { ConfirmPurchaseModal },
  emits: ['resetButtonClick', 'checkoutButtonClick'],
  props: {
    purchaseLines: {
      type: Object as PropType<PurchaseLine[]>,
      required: true
    }
  },
  setup(props) {
    const MODAL_TAG_ID = 'confirmModal';

    const saleStore = useSalesStore();

    const totalPrice = computed(() =>
      props.purchaseLines.reduce((sum, line) => {
        return sum + line.quantity * getProductPrice(line.productId);
      }, 0)
    );

    const getProductPrice = (productId: number) => {
      return saleStore.getSaleProduct(productId)?.price ?? 0;
    };

    return {
      MODAL_TAG_ID,
      totalPrice
    };
  }
};
</script>
