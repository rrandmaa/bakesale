<script setup lang="ts">
import { RouterView } from 'vue-router';
import NavBar from '@/components/common/NavBar.vue';
</script>

<template>
  <NavBar />
  <body class="mt-3">
    <RouterView />
  </body>
</template>

<style scoped></style>
