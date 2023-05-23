<script setup lang="ts">
import PageHeader from '@/components/common/PageHeader.vue';
import ConstructPurchase from '@/components/purchases/ConstructPurchase.vue';
</script>

<template>
  <Suspense>
    <div class="container">
      <PageHeader title="New order" />
      <ConstructPurchase />
    </div>
  </Suspense>
</template>
