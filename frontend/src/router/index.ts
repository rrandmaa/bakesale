import { createRouter, createWebHistory } from 'vue-router';
import SalesView from '@/views/SalesView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'main',
      component: SalesView
    }
  ]
});

export default router;
