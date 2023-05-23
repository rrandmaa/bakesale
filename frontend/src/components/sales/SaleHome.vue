<template>
    <PageHeader :title="sale.name" />
    <div class="container text-center mt-5">
        <button role="button" class="btn btn-primary">Start new order</button>
    </div>
    
</template>

<script lang="ts">
import PageHeader from '@/components/common/PageHeader.vue';
import type { Sale } from '@/interfaces/sale';
import { useSalesStore } from '@/stores/sales';
import { useRoute } from 'vue-router';

export default {
    components: {
        PageHeader,
    },
    async setup() {
        const route = useRoute();
        const salesStore = useSalesStore();

        const sale: Sale = await salesStore.refreshSaleData(Number(route.params.id));

        return { 
            sale,
        }
    }
}

</script>
