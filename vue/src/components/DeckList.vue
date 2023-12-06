<template>
    <div class="deck" v-for="deck in decks" v-bind:key="deck.deckId">
        <router-link v-bind:to="{
            name: 'deck-detail',
            params: { deckId: deck.deckId }
        }">
            <DeckDetails v-bind:deck="deck" class="modify-deck" />
        </router-link>
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

<style scoped>
.deck {
    display: flex;
    justify-content: space-evenly;
}

.modify-deck {
    min-width: 150px;
    min-height: 50px;
    text-align: center;
}
</style>