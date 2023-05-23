<template>
  <div class="card mb-3" role="button" v-on:click="incrementSelected">
      <div class="card-header cstm-primary-light text-center">
        <h3>{{ product?.name }}</h3>
        <p>Selected: {{ clickedCount }}</p>
      </div>
      <div class="card-body cstm-secondary-light text-center">
        <p>Price: {{ product?.price.toFixed(2) }} €</p>
        <p>In stock: {{ product?.remainingQuantity }}</p>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import type { Product } from '@/interfaces/product';
import { SaleStatus } from '@/interfaces/sale';
  import { ref, type PropType } from 'vue';
  
  export default {
    props: {
      product: {
        type: Object as PropType<Product>,
        required: true
      }
    },
    setup() {
      const clickedCount = ref<number>(0);

      const incrementSelected = () => {
        clickedCount.value++;
      }

      return {
        SaleStatus,
        clickedCount,
        incrementSelected,
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
  