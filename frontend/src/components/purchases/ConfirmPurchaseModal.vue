<template>
  <GenericModal :tag-id="tagId" title="Review purchase">
    <template v-slot:body>
      <div class="container text-center">
        <p>Total amount to be paid: {{ totalPrice.toFixed(2) }} €</p>
        <CashReturnAccordion :total-price="totalPrice" />
      </div>
      <div v-if="!purchaseIsValid" class="alert alert-danger" role="alert">
        Some products appear to have run out of stock!
      </div>
      <ConfirmPurchaseList :purchase-lines="purchaseLinesWithContent" />
    </template>
    <template v-slot:footer>
      <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Back to products</button>
      <button
        type="button"
        class="btn btn-success"
        data-bs-dismiss="modal"
        v-if="purchaseIsValid && purchaseLinesWithContent.length > 0"
        v-on:click="confirmPurchase"
      >
        Complete purchase
      </button>
    </template>
  </GenericModal>
</template>

<script lang="ts">
import { postPurchase } from '@/api/purchases.api';
import type { Purchase, PurchaseLine } from '@/interfaces/purchase';
import { useSalesStore } from '@/stores/sales';
import { computed, type PropType } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import ConfirmPurchaseList from './ConfirmPurchaseList.vue';
import CashReturnAccordion from './CashReturnAccordion.vue';
import GenericModal from '../common/GenericModal.vue';

export default {
  components: {
    GenericModal,
    ConfirmPurchaseList,
    CashReturnAccordion
  },
  props: {
    tagId: {
      type: String,
      required: true
    },
    purchaseLines: {
      type: Object as PropType<PurchaseLine[]>,
      required: true
    },
    totalPrice: {
      type: Number,
      required: true
    }
  },
  async setup(props) {
    const route = useRoute();
    const router = useRouter();
    const salesStore = useSalesStore();
    const purchaseLinesWithContent = computed<PurchaseLine[]>(() =>
      props.purchaseLines.filter((x) => x.productId)
    );
    const purchaseIsValid = computed(() =>
      salesStore.isPurchaseValidForSale(purchaseLinesWithContent.value)
    );

    const confirmPurchase = async () => {
      if (!purchaseIsValid.value) return;

      try {
        await postPurchase(Number(route.params.id), {
          purchaseLines: purchaseLinesWithContent.value
        } as Purchase);
      } catch {
        await salesStore.fetchSale(Number(route.params.id));
        alert('Something ran out of stock while checking out!');
        return;
      }

      router.push(`/sale/${route.params.id}`);
    };

    return {
      purchaseLinesWithContent,
      purchaseIsValid,
      confirmPurchase
    };
  }
};
</script>
