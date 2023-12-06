<template>
    <div class="deck-container">
        <DeckDetails v-bind:deck="deck" />
    </div>
    <button v-if="!isFormDisplayed" v-on:click="displayForm">Create Card</button>
    <button v-if="isFormDisplayed" v-on:click="cancelForm">Cancel</button>
    <CardForm v-if="isFormDisplayed" v-bind:card="card"/>
    <!--add view of all cards-->
</template>

<script>
import DeckDetails from '../components/DeckDetails.vue';
import DeckService from '../services/DeckService.js';
import CardForm from '../components/CardForm.vue';

export default {
    data() {
        return {
            deck: {},
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
    },
    created() {
        this.getDeck();
    }
}
</script>