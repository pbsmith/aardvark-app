<template>
    <div class="decks">
        <div class="deck" v-for="deck in decks" v-bind:key="deck.deckId">
            <router-link v-bind:to="{
                name: 'deck-detail',
                params: { deckId: deck.deckId }
            }">
                <DeckDetails v-bind:deck="deck" class="modify-deck" />
            </router-link>
        </div>
    </div>
</template>

<script>
import DeckDetails from './DeckDetails.vue';

export default {
    components: {
        DeckDetails
    },
    props: {
        decks: {
            type: Array,
            required: true
        }
    }
};
</script>

<style>

.decks {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    justify-content: space-around;
}

.deck {
    padding: 0rem 1.2rem 1.2rem 1.2rem;
    background-color: #ffe8d6;

    border: .05rem solid #cb997e;
    border-radius: 7%;
    box-shadow: 0 0 1rem #cb997e;
}

.deck:hover{
    background-color: #cb997e;
}

a {
    text-decoration: none;
    color: black;
}




</style>