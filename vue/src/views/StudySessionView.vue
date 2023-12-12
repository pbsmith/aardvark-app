<template>
  <div class="flashcard-view">
    <div class="nav">
      <h1>--FlashCard Study Session--</h1>
      <button class="finish-study" v-on:click="completeStudySession">Finish Study Session</button>
    </div>
    <div class="card-container-view">
      <StudySession v-if="cards.length > 0" :currentCard="cards[currentIndex]" class="card" />
    </div>
    <button class="centered-button" @click="prevCard" :disabled="currentIndex === 0"><i class="pi pi-arrow-circle-left"
        style="font-size: 3rem"></i></button>
    <button class="wrong-Icon" @click="rightCards(currentIndex)"><i class="pi pi-check-circle" style="font-size: 3rem"></i></button>
    <button class="right-Icon" @click="wrongCards(currentIndex)"><i class="pi pi-times" style="font-size: 3rem"></i></button>
    <button class="centered-button" @click="nextCard" :disabled="currentIndex === cards.length - 1"><i
        class="pi pi-arrow-circle-right" style="font-size: 3rem"></i></button>
  </div>
  <div class="complete-view">
    <h1>Complete Session</h1>
    <div>
      <h2>score:</h2>
    </div>
    <div>
      <h2>Right: {{ numberOfRightAnswers }}</h2>
    </div>
    <div>
      <h2>Wrong: {{ numberOfWrongAnswers }}</h2>
    </div>
  </div>
</template>
  
<script>
import DeckService from '../services/DeckService.js';
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
  computed: {
  },
  methods: {
    completeStudySession() {
      this.$router.push({ name: 'complete-session', params: { deckId: this.deck.deckId } })
    },

    nextCard() {
      this.currentIndex = Math.min(this.currentIndex + 1, this.cards.length - 1);
    },
    prevCard() {
      this.currentIndex = Math.max(this.currentIndex - 1, 0);
    },
    rightCards(currentIndex) {
      this.$store.commit('RIGHT_CARD')
    },
    wrongCards(currentIndex) {
      this.$store.commit('WRONG_CARD')
    },

    getCards() {
      CardService.getCardsByDeckId(this.$route.params.deckId)
        .then(response => {
          this.cards = response.data;
        })
        .catch(error => {
          this.handleError();
        });
    },
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
  margin: 0.4rem;
}

.flashcard-view {
  display: flex;
  justify-content: center;
  align-items: center;
}

.nav {
  display: flex;
  justify-content: space-between;
}

.centered-button {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: .5rem;
  background-color: #6b705c;
  color: #cb997e;
  border: none;
  cursor: pointer;
  border-radius: .3rem;
}

.card {}

.finish-study {
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: #6b705c;
  color: #cb997e;
  border: none;
  cursor: pointer;
  border-radius: .5rem;
}

.wrong-Icon,
.right-Icon {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: .5rem;
  background-color: #6b705c;
  color: #cb997e;
  border: none;
  cursor: pointer;
  border-radius: 5px;
}

h1 {
  text-align: center;
  padding-top: 1rem;
}

.card-container-view {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 150rem;
  background-color: none;
}

.complete-view {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  box-shadow: 0 0px 10px rgba(0, 0, 0, 0.4);
  background-color: #6b705c;

}
</style>
  