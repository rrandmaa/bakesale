import { getSales } from '@/api/sales.api';
import type { Sale } from '@/interfaces/sale';
import { defineStore } from 'pinia';
import { onMounted, ref } from 'vue';

export const useSalesStore = defineStore('sales', () => {
  const sales = ref<Sale[]>([]);

  async function fetchSales() {
    sales.value = await getSales();
  }

  onMounted(async () => await fetchSales());

  return { sales };
});
