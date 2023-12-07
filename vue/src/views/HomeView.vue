<template>
  <div class="loading" v-if="isLoading">
    <p>Loading...</p>
  </div>
  <div v-else id="home-grid">
    <h1 id="deck-title">- Flashcard Decks -</h1>
    <DeckList v-bind:decks="decks" />
  </div>
</template>

<script>
import DeckList from '../components/DeckList.vue';
import deckService from '../services/DeckService.js';

export default {
  components: {
    DeckList,
  },
  data() {
    return {
      decks: [],
      isLoading: true
    };
  },
  methods: {
    getDecks() {
      deckService.getDecks()
        .then(response => {
          this.decks = response.data;
          this.isLoading = false;
        })
        .catch(error => {
          this.handleError();
        })
    },
  },
  created() {
    console.log('Reached created in home view')
    this.getDecks();
  }


};
</script>

<style>
#deck-title {
  margin: auto;
  margin-bottom: 2rem;
  width: fit-content;
  text-align: center;

  padding: .8rem .8rem .8rem .8rem;
}
</style>
