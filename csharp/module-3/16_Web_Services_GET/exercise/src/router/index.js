import Vue from 'vue';
import VueRouter from 'vue-router';
import TopicService from '../Services/TopicService';
import Home from '../views/Home.vue';
import Messages from '../views/Messages.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/:id',
    name: 'Messages',
    component: Messages
  },
  {
    path: '/topics',
    name: 'Topics',
    component: TopicService
  }
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

export default router;
