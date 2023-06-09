import { createRouter, createWebHistory } from 'vue-router';
import SalesView from '@/views/SalesView.vue';
import AddNewSaleView from '@/views/AddNewSaleView.vue';
import SaleHomeView from '@/views/SaleHomeView.vue';
import NewOrderView from '@/views/NewOrderView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'main',
      component: SalesView
    },
    {
      path: '/newsale',
      name: 'newSale',
      component: AddNewSaleView
    },
    {
      path: '/sale/:id',
      name: 'saleHome',
      component: SaleHomeView
    },
    {
      path: '/sale/:id/neworder',
      name: 'newOrder',
      component: NewOrderView
    }
  ]
});

export default router;
