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
import SaleCard from './SaleCard.vue';


export default {
    setup() {
        const sales = [
            {
                id: 1,
                name: "Bakesale 1",
                status: 0,
            },
            {
                id: 2,
                name: "Bakesale 2",
                status: 0,
            },
            {
                id: 3,
                name: "Bakesale 3",
                status: 0,
            },
            {
                id: 4,
                name: "Bakesale 4",
                status: 0,
            },
        ];
        return {
            sales,
        };
    },
    components: { SaleCard }
}

</script>
