<template>
    <div class="deck">
        <DeckDetails v-for="deck in decks" v-bind:key="deck.deckId" v-bind:deck="deck" class="modify-deck"/>
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

<style scoped>
    .deck {
        display: flex;
        justify-content: space-evenly;
    }
    .modify-deck{
        min-width: 150px;
        min-height: 50px;
        text-align: center;
    }
</style>