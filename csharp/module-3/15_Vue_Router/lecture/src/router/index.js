import Vue from 'vue'
import VueRouter from 'vue-router'
//have to import the views we want to use for routes
import Products from '../views/Products.vue'
import ProductDetail from '../views/ProductDetail.vue'
import AddReview from '../views/AddReview.vue'

Vue.use(VueRouter)

const routes = [
  //define routes to views
  //each route is its own object and has 3 pieces, as seen below.
  {
    path: '/',   //this is the route. a slash is the root from when we did module 2, and we want this at the root so it shows up immediately.
    name: 'products',   //it is good practice to give the route a name.
    component: Products //this is the view. it's got a dumb name. 
  },
  {
    path: '/products/:id', //dynamic route based on the product id
    name: 'product-detail',
    component: ProductDetail
  },
  {
    path: '/products/:id/add-review', //dynamic route for adding a review to a particular product
    name: 'add-review',
    component: AddReview
  }


]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
