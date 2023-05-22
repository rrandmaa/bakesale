<script setup lang="ts">
import PageHeader from '@/components/common/PageHeader.vue';
import SalesContainer from '@/components/sales/SalesContainer.vue';
</script>

<template>
  <Suspense>
    <div class="container">
      <PageHeader title="Sales" />
      <SalesContainer />
    </div>
  </Suspense>
</template>
