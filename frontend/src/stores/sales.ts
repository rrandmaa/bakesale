import { getSale, getSales, postSale } from '@/api/sales.api';
import type { Sale } from '@/interfaces/sale';
import { defineStore } from 'pinia';
import { onMounted, ref } from 'vue';

export const useSalesStore = defineStore('sales', () => {
  const sales = ref<Sale[]>([]);

  async function fetchSales() {
    sales.value = await getSales();
  }

  async function refreshSaleData(id: number) {
    const updatedSale = await getSale(id);
    const saleToUpdate = sales.value.find(x => x.id === id);
    if (saleToUpdate && updatedSale) {
      Object.assign(saleToUpdate, updatedSale);
    }
  }

  async function addSale(saleToAdd: Sale) {
    const newSale = await postSale(saleToAdd);
    if (newSale) sales.value.push(newSale);
    return newSale;
  }

  onMounted(async () => await fetchSales());

  return { sales, refreshSaleData, addSale };
});
