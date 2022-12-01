import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue'
import ReadingList from '../views/MyBooks.vue'
import NewBookForm from '../views/NewBook.vue'
import BookDetails from '../views/BookDetails.vue'

Vue.use(VueRouter);

const routes = [
    {
      path: '/',
      name: 'home',
      component: Home
    },
     { 
      path: '/myBooks',
      name: 'mybooks',
      component: ReadingList
     },
     {
       path: '/addBook',
       name: 'addbook',
       component: NewBookForm
     },
     {
       path: '/book/:isbn',
       name: 'bookdetails',
       component: BookDetails
     }
     
];

const router = new VueRouter({
  mode: 'history',
  routes 
});

export default router;
