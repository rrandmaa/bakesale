<script setup lang="ts">
import PageHeader from '@/components/common/PageHeader.vue';
import NewSaleButton from '@/components/sales/NewSaleButton.vue';
import SalesContainer from '@/components/sales/SalesContainer.vue';
</script>

<template>
  <Suspense>
    <div class="container mb-4">
      <PageHeader title="Manage Sales" />
      <SalesContainer />
      <NewSaleButton />
    </div>
  </Suspense>
</template>
