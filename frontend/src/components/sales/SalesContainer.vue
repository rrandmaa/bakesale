<template>
    <div class="container mt-4">
        <div class="row row-cols-auto">
            <div v-for="sale in sales" v-bind:key="sale.id" class="col">
                <SaleCard :sale="sale" />
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import type { Sale } from '@/interfaces/sale';
import SaleCard from './SaleCard.vue';


export default {
    async setup() {

        const response = await fetch("http://localhost:8080/api/Sales");
        const sales: Sale[] = await response.json();

        return {
            sales,
        };
    },
    components: { SaleCard }
}

</script>
