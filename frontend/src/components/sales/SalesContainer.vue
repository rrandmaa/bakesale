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
import { getSales } from '@/api/sales.api';


export default {
    async setup() {
        const sales: Sale[] = await getSales();

        return {
            sales,
        };
    },
    components: { SaleCard }
}

</script>
