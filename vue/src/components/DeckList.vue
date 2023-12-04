<template>
    <div class="deck">
        <DeckDetails v-for="deck in decks" v-bind:key="deck.deckId" v-bind:deck="deck"/>
    </div>
</template>

<script>
import DeckDetails from './DeckDetails.vue';

export default{
    components: {
        DeckDetails
    },
    props:{
        decks:{
            type: Array,
            required: true
        }
    }
};
</script>

<style>
    .deck {
        display: flex;
        justify-content: space-evenly;
    }
</style>