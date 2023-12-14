<template>
  <div v-if="!sessionCompleted" class="flashcard-view">
    <div class="nav">
      <h1>Flashcard Study Session</h1>
    </div>
    <StudySession v-if="cards.length > 0" :currentCard="cards[currentIndex]" class="card" />
    <div class="card-container-view">
      <div id="study-buttons">
        <button class="centered-button" @click="prevCard" :disabled="currentIndex === 0">
          <i class="pi pi-arrow-circle-left"></i>
        </button>
        <button class="wrong-Icon" @click="rightCard(cards[currentIndex])">
          <i class="pi pi-check-circle"></i>
        </button>
        <button class="right-Icon" @click="wrongCard(cards[currentIndex])">
          <i class="pi pi-times"></i>
        </button>
        <button class="centered-button" @click="nextCard" :disabled="currentIndex === cards.length - 1">
          <i class="pi pi-arrow-circle-right"></i>
        </button>
      </div>
    </div>
  </div>
  <div id="study-session-buttons">
    <button class="form-button"><router-link :to="{ name: 'deck-detail' }">Back to Deck</router-link></button>
    <button v-if="!sessionCompleted" class="form-button" v-on:click="completeStudySession">Finish Study Session</button>
  </div>

  <div class="complete-study">
    <div v-if="sessionCompleted" class="complete-view">
      <h1>Complete Session</h1>
      <div>
        <h2>Score: {{ score() }}</h2>
      </div>
      <div>
        <h2>Right: {{ rightCards.length }}</h2>
      </div>
      <div>
        <h2>Wrong: {{ wrongCards.length }}</h2>
      </div>
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
      currentIndex: 0,
      wrongCards: [],
      rightCards: [],
      sessionCompleted: false
    };
  },
  components: {
    StudySession
  },
  computed: {
  },
  methods: {
    completeStudySession() {
      this.sessionCompleted = true;
    },
    nextCard() {
      this.currentIndex = Math.min(this.currentIndex + 1, this.cards.length - 1);
    },
    prevCard() {
      this.currentIndex = Math.max(this.currentIndex - 1, 0);
    },
    rightCard(currentIndex) {

      if (!this.rightCards.includes(currentIndex)) {
        this.rightCards.push(currentIndex)
      }
      if (this.wrongCards.includes(currentIndex)) {
        this.wrongCards.pop(currentIndex)
      }

      this.currentIndex = Math.min(this.currentIndex + 1, this.cards.length - 1)
      console.log(currentIndex);
    },
    wrongCard(currentIndex) {

      if (!this.wrongCards.includes(currentIndex)) {
        this.wrongCards.push(currentIndex)
      }
      if (this.rightCards.includes(currentIndex)) {
        this.rightCards.pop(currentIndex)
      }

      this.currentIndex = Math.min(this.currentIndex + 1, this.cards.length - 1)
      console.log(currentIndex);
    },
    score() {
      let score = ((this.rightCards.length / (this.rightCards.length + this.wrongCards.length)) * 100)
      score = Math.round(score)
      return `${score}%`;
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

.form-button {
  align-items: center;
  background-color: #1C0B00;
}

#study-session-buttons {
  display: flex;
  flex-direction: row;
  justify-content: center;
}

.flashcard-view {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.nav {
  display: flex;
  justify-content: space-between;
}

.complete-study {
  display: flex;
  justify-content: center;
  align-items: center;
}

.centered-button {
  display: flex;
  align-items: center;
  justify-content: center;
  padding: .5rem;
  background-color: #1C0B00;
  color: #E5AC65;
  border: none;
  cursor: pointer;
  border-radius: .3rem;

}

i {
  font-size: 6vw;
}



.wrong-Icon,
.right-Icon {
  width: fit-content;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: .5rem;
  background-color: #1C0B00;
  color: #E5AC65;
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
  width: 80%;
  background-color: none;
}

.card {
  width: 100%;
  max-width: 50rem;
}

.complete-view {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  box-shadow: 0 0px 10px rgba(0, 0, 0, 0.4);
  background-color: #1C0B00;
  width: 80%;
  color: #E5AC65;
}
</style>
  