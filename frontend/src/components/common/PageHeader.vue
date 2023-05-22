<template>
  <header class="page-header border-bottom">
    <h1>{{ title }}</h1>
  </header>
</template>

<script lang="ts">
export default {
  props: {
    title: {
      type: String,
      required: true,
    }
  }
};
</script>
