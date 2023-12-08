<template>
    <h1>Welcome to the Study Session</h1>
    <div class="card-container-view">
        <StudySession  v-for="currentCard in cards" v-bind:key="currentCard.cardId"
            v-bind:currentCard="currentCard" />           
    </div>
</template>
<script>
import CardService from '../services/CardService.js';
import StudySession from '../components/StudySession.vue';

export default {
    data() {
        return {
            cards: {},
        }
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
                })
        }
    },
    created() {
        this.getCards();
    }
}
</script>
<style scoped>
*{
    display: flex;
    flex-wrap: wrap;
    margin: 0.8rem;
    
}
    h1{
        text-align: center;
        padding-top: 1rem;
    }
    .card-container-view{
        display: flex;
    }
</style>