<template>
  <form class="container-fluid my-4" v-on:submit.prevent="submitAddSaleForm">
    <div class="form-group row">
      <label class="col-sm-2 col-form-label text-nowrap" for="saleName">Sale name</label>
      <div class="col-sm-10">
        <input
          type="text"
          class="form-control"
          id="saleName"
          placeholder="Enter sale name"
          required
          v-model="saleName"
        />
      </div>
    </div>
    <div class="row mt-5">
      <h4>Products</h4>
    </div>
    <table class="table table-bordered table-responsive mt-2">
      <thead>
        <tr class="text-center">
          <th scope="col">Name</th>
          <th scope="col">Price</th>
          <th scope="col">Quantity in stock</th>
        </tr>
      </thead>
      <tbody>
        <tr class="text-center" v-for="(product, i) in defaultProducts" v-bind:key="i">
          <td>{{ product.name }}</td>
          <td>{{ product.price }}</td>
          <td>
            <input type="number" class="form-control" required v-model="product.initialQuantity" />
          </td>
        </tr>
      </tbody>
    </table>
    <div class="form-group row text-center mt-5">
      <div class="col sm-2">
        <button type="submit" class="btn btn-primary">Register sale</button>
      </div>
    </div>
  </form>
</template>

<script lang="ts">
import type { Sale } from '@/interfaces/sale';
import { useSalesStore } from '@/stores/sales';
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import productsConfig from '@/assets/products.json';
import { type Product } from '@/interfaces/product';

export default {
  setup() {
    const router = useRouter();
    const salesStore = useSalesStore();

    const saleName = ref<String>();
    const defaultProducts = ref<Product[]>(productsConfig as Product[]);

    const submitAddSaleForm = async () => {
      const saleToAdd = { name: saleName.value, products: defaultProducts.value } as Sale;
      await salesStore.addSale(saleToAdd);
      router.push('/');
    };

    return {
      saleName,
      defaultProducts,
      submitAddSaleForm
    };
  }
};
</script>
