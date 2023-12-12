<template>
    <div class="flashcard-view">
        <h1>FlashCard Study Session</h1>
      <div class="card-container-view">
        <StudySession v-if="cards.length > 0" :currentCard="cards[currentIndex]"  class="card"/>
      </div>
      <button class="centered-button" @click="prevCard" :disabled="currentIndex === 0"><i class="pi pi-arrow-circle-left" style="font-size: 3rem"></i></button>
      <button class="centered-button" @click="nextCard" :disabled="currentIndex === cards.length - 1"><i class="pi pi-arrow-circle-right" style="font-size: 3rem"></i></button>
    </div>
  </template>
  
  <script>
  import CardService from '../services/CardService.js';
  import StudySession from '../components/StudySession.vue';
  
  export default {
    data() {
      return {
        cards: [],
        currentIndex: 0
      };
    },
    components: {
      StudySession
    },
    methods: {
      getCards() {
        CardService.getCardsByDeckId(this.$route.params.deckId)
          .then(response => {
            this.cards = response.data;
          })
          .catch(error => {
            this.handleError();
          });
      },
      nextCard() {
        this.currentIndex = Math.min(this.currentIndex + 1, this.cards.length - 1);
      },
      prevCard() {
        this.currentIndex = Math.max(this.currentIndex - 1, 0);
      },
      handleError() {
        // Handle error logic
      }
    },
    created() {
      this.getCards();
    }
  };
  </script>
  
  <style scoped>
  * {
    display: flex;
    flex-wrap: wrap;
    margin: 0.8rem;
  }

  .flashcard-view{
    display: flex;
    justify-content: center;
    align-items: center;
  }
  
  .centered-button {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 10px;
  background-color: #6b705c;
  color: #cb997e;
  border: none;
  cursor: pointer;
  border-radius: 5px;
  width: 10rem;
}

  h1 {
    text-align: center;
    padding-top: 1rem;
  }
  .card-container-view {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 70rem;
    background-color: none;
  }
  </style>
  