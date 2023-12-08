<template>
    <div>
        <DeckDetails v-bind:deck="deck" />
    </div>
    <draggable :list="cards" group="card-collection">
        <div>
            <div class="card" v-for="card in cards" v-bind:key="card.cardId">
                <CardDetails v-bind:card="card" />
            </div>
        </div>
    </draggable>
    <draggable class="all-cards" v-model="allCards" group="card-collection">
        <template #item="{ element: card}">
            <div id="all-cards" v-for="card in allCards" v-bind:key="card.cardId">
                <CardDetails v-bind:card="card" />
            </div>
        </template>
    </draggable>
</template>

<script>
import CardService from '../services/CardService';
import DeckService from '../services/DeckService';
import CardDetails from './CardDetails.vue';
import DeckDetails from './DeckDetails.vue';
import draggable from 'vuedraggable';

export default {
    data() {
        return {
            deckId: this.$route.params.deckId,
            allCards: [],
            cards: []
        }
    },
    computed: {
        deck() {
            return DeckService
                .getDeckById(this.deckId)
        },
    },
    methods: {
        getAllCards() {
            this.allCards.push(CardService.getAllCards())
        }
    },
    components: {
        CardDetails,
        DeckDetails,
        draggable
    },
    created() {
        this.cards.push('Hello', 'Goodbye')
    }
};
</script>

<style>
.cards {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    justify-content: space-around;
}
</style>