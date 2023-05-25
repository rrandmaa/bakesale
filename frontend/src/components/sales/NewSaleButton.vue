<template>
  <div class="d-grid gap-2 col-3 mx-auto">
    <router-link to="/newsale" custom v-slot="{ navigate }">
      <button class="btn btn-primary mt-3 text-nowrap shadow" v-on:click="navigate">
        New sale
      </button>
    </router-link>
  </div>
</template>

<script lang="ts">
export default {};
</script>
