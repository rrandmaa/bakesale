<script setup lang="ts">
import PageHeader from '@/components/common/PageHeader.vue';
import ConstructOrder from '@/components/purchases/ConstructOrder.vue';
</script>

<template>
  <Suspense>
    <div class="container">
      <PageHeader title="New order" />
      <ConstructOrder />
    </div>
  </Suspense>
</template>
