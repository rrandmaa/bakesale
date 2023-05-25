import { getSale, getSales, postSale } from '@/api/sales.api';
import type { Sale } from '@/interfaces/sale';
import { defineStore } from 'pinia';
import { computed, onMounted, ref } from 'vue';

export const useSalesStore = defineStore('sales', () => {
  const sales = ref<Sale[]>([]);
  const sale = ref<Sale>();

  const saleProducts = computed(() => sale.value?.products);

  async function fetchSales() {
    sales.value = await getSales();
  }

  async function fetchSale(id: number) {
    sale.value = await getSale(id);
  }

  async function addSale(saleToAdd: Sale) {
    const newSale = await postSale(saleToAdd);
    if (newSale) sales.value.push(newSale);
    return newSale;
  }

  function getSaleProduct(id: number) {
    return saleProducts.value?.find(x => x.id === id);
  }

  onMounted(async () => await fetchSales());

  return { sales, sale, saleProducts, fetchSale, addSale, getSaleProduct };
});
