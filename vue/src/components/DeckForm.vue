<template>
    <div class="container">
        <form v-on:submit.prevent="submitForm" class="deck-form">
        <h1>Create a New Deck</h1>
        <div class="field">
            <label for="title">Title</label>
            <input type="text" id="title" name="title" v-model="newDeck.deckTitle">
        </div>
        <div class="field">
            <label for="desc">Description</label>
            <input type="text" id="desc" name="desc" v-model="newDeck.deckDesc" />
        </div>
        <div class="field">
            <label for="tags">Tags</label>
            <input type="text" id="tags" name="tags" v-model="newDeck.deckTags" />
        </div>
        <button type="submit" value="Save">Save</button>

    </form>
    </div>
</template>

<script>
import DeckService from '../services/DeckService.js';

export default {
    props: {
        deck: {
            type: Object,
            required: true
        }
    },
    data() {
        return {
            newDeck: {
                deckId: this.deck.deckId,
                deckTags: this.deck.deckTags,
                deckDesc: this.deck.deckDesc,
                userId: this.deck.userId
            }
        };
    },
    methods: {
        submitForm() {
            if (!this.validateForm()) {
                return;
            }
            if (this.newDeck.deckId === 0) {
                DeckService
                    .createDeck(this.newDeck)
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

<style>
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}
form {
  background-color: #fff;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.3);
  max-width: 400px;
  width: 100%;
  font-family: "Poppins", sans-serif;
}
form h1 {
  text-align: center;
  color: #333;
  font-size: 24px;
  margin-bottom: 20px;
}
form label {
  display: block;
  margin-bottom: 8px;
  color: #555;
}

form input {
  width: 90%;
  padding: 10px;
  margin-bottom: 16px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
form button {
  width: 95%;
  margin-top:25px;
  padding: 15px;
  background-color: blueviolet;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}
form button:hover {
  background-color: red;
}
</style>