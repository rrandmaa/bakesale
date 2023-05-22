import { createRouter, createWebHistory } from 'vue-router';
import SalesView from '@/views/SalesView.vue';
import AddNewSaleView from '@/views/AddNewSaleView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'main',
      component: SalesView
    },
    {
      path: "/newsale",
      name: "newSale",
      component: AddNewSaleView
    }
  ]
});

export default router;
