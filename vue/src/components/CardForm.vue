<template>
    <div class="container">
        <form v-on:submit.prevent="submitForm" class="card-form">
            <h1>Create a New Card</h1>
            <div class="field">
                <label for="term">Term</label>
                <input type="text" id="term" name="term" v-model="newCard.cardTerm">
            </div>
            <div class="field">
                <label for="definition">Term</label>
                <input type="text" id="definition" name="definition" v-model="newCard.cardDefinition">
            </div>
            <div class="field">
                <label for="tags">Term</label>
                <input type="text" id="tags" name="tags" v-model="newCard.cardTags">
            </div>
        </form>
    </div>
</template>

<script>
import CardService from '../services/CardService';

export default{
    props: {
        card: {
            type: Object,
            required: true
        }
    },
    data() {
        return {
            newCard: {
                cardId: this.card.cardId,
                deckId: this.card.deckId,
                cardTerm: this.card.cardTerm,
                cardDefinition: this.card.cardDefinition,
                cardTags: this.card.cardTags,
                userId: this.card.userId
            }
        };
    },
    methods: {
        submitForm() {
            if (!this.validateForm()) {
                return;
            }
            if (this.newDeck.deckId === 0) {
                CardService
                    .createCard(this.newCard)
                    .then(response => {
                        if (response.status === 201) {
                            this.$store.commit(
                                'SET_NOTIFICATION',
                                {
                                    message: 'A new card was added.',
                                    type: 'success'
                                }
                            );
                            this.$router.push({
                                //change to deck view
                                name: 'home',
                            });
                        }
                    })
                    .catch(error => {
                        this.handleErrorResponse(error, 'adding');
                    });
                //add edit here

            }

        },
        handleErrorResponse(error, verb) {
            if (error.response) {
                this.$store.commit('SET_NOTIFICATION',
                    "Error " + verb + " card. Response received was '" + error.response.statusText + "'.");
            } else if (error.request) {
                this.$store.commit('SET_NOTIFICATION', "Error " + verb + " card. Server could not be reached.");
            } else {
                this.$store.commit('SET_NOTIFICATION', "Error " + verb + " card. Request could not be created.");
            }
        },
        validateForm() {
            let msg = '';
            if (this.newDeck.deckTitle.length === 0) {
                msg += 'The new card must have a title. ';
            }
            if (this.newDeck.deckDesc.length === 0) {
                msg += 'The new card must have a Description.';
            }
            if (this.newDeck.deckTags.length === 0) {
                msg += 'The new card must have a Tags.';
            }
            if (msg.length > 0) {
                this.$store.commit('SET_NOTIFICATION', msg);
                return false;
            }
            return true;
        }
    }
}
</script>