<template>
  <div class="accordion accordion-flush">
    <div class="accordion-item">
      <h2 class="accordion-header" id="headingOne">
        <button
          class="accordion-button"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#collapseOne"
        >
          Cash return
        </button>
      </h2>
      <div
        id="collapseOne"
        class="accordion-collapse collapse show"
        data-bs-parent="#accordionExample"
      >
        <div class="container mt-3">
          <div class="input-group mb-3">
            <input
              type="text"
              class="form-control"
              placeholder="Cash received"
              :min="totalPrice"
              v-model="cashPaid"
            />
            <button class="btn btn-primary" type="button" v-on:click="getCashReturn">
              Calculate return
            </button>
          </div>
          <table class="table table-border-bottom table-responsive">
            <thead class="table">
              <tr class="text-center">
                <th scope="col">Note or coin</th>
                <th scope="col">Amount</th>
              </tr>
            </thead>
            <tbody class="text-center">
              <tr v-for="(cashReturnLine, i) in cashReturn" v-bind:key="i">
                <td>{{ cashReturnLine.value.toFixed(2) }} €</td>
                <td>{{ cashReturnLine.count }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { calculateCashReturn } from '@/api/cashReturn.api';
import type { CashReturnResponseLine } from '@/interfaces/cashReturn';
import { ref } from 'vue';

export default {
  props: {
    totalPrice: {
      type: Number,
      required: true
    }
  },
  setup(props) {
    const cashPaid = ref<number>();
    const cashReturn = ref<CashReturnResponseLine[]>([]);

    const getCashReturn = async () => {
      if (!cashPaid.value) return;
      if (cashPaid.value > props.totalPrice) {
        cashReturn.value = await calculateCashReturn(cashPaid.value, props.totalPrice);
      }
    };

    return {
      cashPaid,
      cashReturn,
      getCashReturn
    };
  }
};
</script>
