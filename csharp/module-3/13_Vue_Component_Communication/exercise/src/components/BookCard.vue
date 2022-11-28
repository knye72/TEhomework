<template>
  <div class="card">

    <h2 class="book-title"> {{bookcard.title}} </h2>
    <img v-if="bookcard.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + bookcard.isbn + '-M.jpg'" />
    <p class="book-author"> {{bookcard.author}} </p>


  </div>
</template>

<script>
export default {
    name: 'book-card',
    props: ['bookcard']
}
</script>

<style>
.card {
    border: 2px solid black;
    border-radius: 10px;
    width: 250px;
    height: 550px;
    margin: 20px;
}

.card.read {
    background-color: lightgray;
}

.card .book-title {
    font-size: 1.5rem;
}

.card .book-author {
    font-size: 1rem;
}
</style>