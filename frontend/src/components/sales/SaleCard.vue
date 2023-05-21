<template>
    <div class="card mb-3">
        <div class="card-header cstm-primary-light">
            <h2>{{ sale?.name }}</h2>
        </div>
        <div class="card-body cstm-secondary-light text-center">
            <p>{{ SaleStatus[sale?.status] }}</p>
            <a href="#">Go to sale</a>
        </div>
    </div>
</template>

<script lang="ts">
import { SaleStatus, type Sale } from '@/interfaces/sale';
import type { PropType } from 'vue';

export default {
    props: {
        sale: {
            type: Object as PropType<Sale>,
            required: true,
        }
    },
    setup() {
        return {
            SaleStatus,
        }
    }
}
</script>

<style scoped>
.card-body {
    border-radius: 5%
}
</style>
