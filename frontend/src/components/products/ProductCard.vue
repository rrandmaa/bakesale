<template>
    <div class="card mb-3">
      <div class="card-header cstm-primary-light text-center">
        <h3>{{ product?.name }}</h3>
      </div>
      <div class="card-body cstm-secondary-light text-center">
        <p>{{ product?.price }}</p>
        <p>{{ product?.remainingQuantity }}</p>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import type { Product } from '@/interfaces/product';
import { SaleStatus } from '@/interfaces/sale';
  import type { PropType } from 'vue';
  
  export default {
    props: {
      product: {
        type: Object as PropType<Product>,
        required: true
      }
    },
    setup() {
      return {
        SaleStatus,
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
  