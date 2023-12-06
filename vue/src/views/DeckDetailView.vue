<template>
    <div class="deck-container">
        <DeckDetails v-bind:deck="deck" />
    </div>
    <button v-if="!isFormDisplayed" v-on:click="displayForm">Create Card</button>
    <button v-if="isFormDisplayed" v-on:click="cancelForm">Cancel</button>
    <CardForm v-if="isFormDisplayed" v-bind:card="card"/>
    <!--add view of all cards-->
    <div class="card-container">
        <CardDetails v-for="currentCard in cards" v-bind:key="currentCard.cardId" v-bind:currentCard="currentCard"/>
    </div>
    
</template>

<script>
import CardService from '../services/CardService.js';
import DeckService from '../services/DeckService.js';

import CardDetails from '../components/CardDetails.vue';
import CardForm from '../components/CardForm.vue';
import DeckDetails from '../components/DeckDetails.vue';

export default {
    data() {
        return {
            deck: {},
            cards: {},
            card:{
                cardId: 0,
                deckId: this.$route.params.deckId,
                cardTerm: '',
                cardDefinition: '',
                userId: 0,
            },
            isFormDisplayed: false,
        }
    },
    components: {
        DeckDetails,
        CardForm,
        CardDetails
    },
    methods: {
        displayForm(){
            this.isFormDisplayed = true;
        },
        cancelForm(){
            this.isFormDisplayed = false;
        },
        getDeck() {
            DeckService.getDeckById(this.$route.params.deckId)
                .then(response => {
                    this.deck = response.data;
                })
                .catch(error => {
                    this.handleError();
                })
        },
        getCards(){
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
        this.getDeck();
        this.getCards();
    }
}
</script>