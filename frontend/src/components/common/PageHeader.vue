<template>
  <header class="page-header border-bottom">
    <h1>{{ title }}</h1>
  </header>
</template>

<script lang="ts">
export default {
  props: {
    title: String
  }
};
</script>
