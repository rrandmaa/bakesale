<template>
    <form class="container-fluid mt-4">
        <div class="form-group row">
            <label class="col-sm-2 col-form-label text-nowrap" for="saleName">Sale name</label>
            <div class="col-sm-10">
                <input type="text" class="form-control" id="saleName" placeholder="Enter sale name" v-model="saleName">
            </div>
        </div>
        <div class="form-group row text-center mt-5" v-for="(product, i) in defaultProducts" v-bind:key="i">
            {{ product.name }}
            {{ product.price }}
            {{ product.initialQuantity }}
        </div>
        <div class="form-group row text-center mt-5">
            <div class="col sm-2">
                <button type="button" class="btn btn-primary" v-on:click="submitAddSaleForm">Submit</button>
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

        console.log(defaultProducts.value);

        const submitAddSaleForm = async () => {
            const saleToAdd = { name: saleName.value } as Sale;
            await salesStore.addSale(saleToAdd);
            router.push("/");
        }

        return {
            saleName,
            defaultProducts,
            submitAddSaleForm,
        }
    }
}

</script>
