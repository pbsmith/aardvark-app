<template>
    <div class="deck-detail-container">
        <DeckDetails v-bind:deck="deck" />
    </div>
    <div>
        <button class="form-button" v-if="!isFormDisplayed" v-on:click="displayForm">Create Card</button>
        <button class="form-button" v-if="isFormDisplayed" v-on:click="cancelForm">Cancel</button>
    </div>
    <div id="cardform">
        <CardForm v-if="isFormDisplayed" v-bind:card="card" />
    </div>
    <!--add view of all cards-->
    <div class="card-container">
        <CardDetails id="cardsInDeck" v-for="currentCard in cards" v-bind:key="currentCard.cardId"
            v-bind:currentCard="currentCard" />
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
            card: {
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
        displayForm() {
            this.isFormDisplayed = true;
        },
        cancelForm() {
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
        this.getDeck();
        this.getCards();
    }
}
</script>

<style>
.deck-detail-container {
    margin: auto;
    padding: 0rem 1.2rem 1.2rem 1.2rem;
    background-color: #ffe8d6;
    width: 90%;

    border: .05rem solid #cb997e;
    border-radius: 1rem;
    box-shadow: 0 0 1rem #cb997e;
}

.form-button {
    margin: 1rem 1rem .5rem 4rem;
    padding: 1.5vh;
    background-color: #b7b7a4;
    border: none;
    border-radius: .5rem;
    cursor: pointer;
    transition: background-color 0.3s ease;
    border: .05rem solid #b7b7a4;
    box-shadow: 0 0 .25rem #6b705c;
}

.form-button:hover{
    background-color: #6b705c;
    border: .05rem solid #4c4e40;
    box-shadow: 0 0 .25rem #4c4e40;

}


.cardcontainer {
    margin: auto;
    margin-bottom: .5rem;
    width: 90%;
    padding: .5rem 1rem .5rem 1rem;
    background-color: #ffe8d6;

    border: .05rem solid #cb997e;
    border-radius: .5rem;
    box-shadow: 0 0 2rem #cb997e;
}

#cardform {
    margin-left:3rem;
    margin-bottom:1rem;
}
</style>