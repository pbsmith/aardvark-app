<template>
    <form v-on:submit.prevent="submitForm">
        <div class="field">
            <label for="title">Title</label>
            <input type="text" id="title" name="title" v-model="editDeck.deckTitle">
        </div>
        <div class="field">
            <label for="desc">Description</label>
            <input type="text" id="desc" name="desc" v-model="editDeck.deckDesc" />
        </div>
        <div class="field">
            <label for="tags">Tags</label>
            <input type="text" id="tags" name="tags" v-model="editDeck.deckTags" />
        </div>

    </form>
</template>

<script>
import DeckService from '../services/DeckService';

export default {
    props: {
        deck: {
            type: Object,
            required: true
        },
    },
    data() {
        return {
            editDeck: {
                deckId: this.deck.deckId,
                deckTitle: this.deck.deckTitle,
                deckDesc: this.deck.deckDesc,
                deckTags: this.deck.deckTags
            }
        };
    },
    methods: {
        submitForm() {
            if (!this.validateForm()) {
                return;
            }
            if (this.editDeck.deckId === 0) {
                DeckService
                    .createDeck(this.editDeck)
                    .then(response => {
                        if (response.status === 201) {
                            this.$store.commit(
                                'SET_NOTIFICATION',
                                {
                                    message: 'A new deck was added.',
                                    type: 'success'
                                }
                            );
                            this.$router.push({
                                name: 'HomeView',
                            });
                        }
                    })
                    .catch(error => {
                        this.handleErrorResponse(error, 'adding');
                    });
                //add edit here
            }
        }
    }
}
</script>