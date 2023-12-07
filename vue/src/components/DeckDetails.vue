<template>
    <div class="deckcontainer">
        <h2>
            {{ deck.deckTitle }}
        </h2>
        <div>
            <p>{{ deck.deckDesc }}</p>
            <p>{{ deck.deckTags }}</p>
        </div>
        <button  class="form-button" id="deck-editBtn" v-on:click="editDeck" v-if="!isEditing && isEditPage">Edit</button>
        <button  class="form-button" id="deck-editBtn" v-on:click="cancelDeck" v-if="isEditing && isEditPage">Cancel</button>
    </div>
    <div>        
        <DeckForm v-if="isEditing" v-bind:deck="deck"/>
    </div>
</template>

<script>
import DeckForm from './DeckForm.vue';


export default {
    data() {
        return {
            isEditing: false,
        };
    },
    computed: {
        isEditPage() {
            if(this.$route.name == 'deck-edit') {
                return true;
            }
            return false;
        }
    },
    methods: {
        editDeck() {
            this.isEditing = true;
        },
        cancelDeck() {
            this.isEditing = false;
        }
    },
    props: ['deck'],
    components: { DeckForm }
}
</script>
