<template>
    <div class="card">
        <div class="card-header cstm-primary-light">
            <h2>{{ sale?.name }}</h2>
        </div>
        <div class="card-body cstm-secondary-light">
            {{ sale?.status }}
        </div>
    </div>
</template>

<script lang="ts">
import type { Sale } from '@/interfaces/sale';
import type { PropType } from 'vue';

export default {
    props: {
        sale: {
            type: Object as PropType<Sale>,
            required: true,
        }
    }
}
</script>
