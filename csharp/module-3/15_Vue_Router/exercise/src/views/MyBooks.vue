<template>
  <div class="booklist">
      <h1> Reading List Books </h1>
      <reading-list />
      <router-link v-bind:to="{ name: 'addbook' } ">Add Book </router-link>
</template>

<script>
import ReadingList from '../components/ReadingList.vue'

export default {
    components: { ReadingList }
}
</script>

<style>

</style>