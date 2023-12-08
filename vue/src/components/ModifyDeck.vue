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
    <draggable class="all-cards" :list="allCards" group="card-collection">
        <div id="all-cards" v-for="card in allCards" v-bind:key="card.cardId">
            <CardDetails v-bind:card="card" />
        </div>
    </draggable>
</template>

<script>
import CardService from '../services/CardService';
import DeckService from '../services/DeckService';
import CardDetails from './CardDetails.vue';
import DeckDetails from './DeckDetails.vue';
import { ref } from 'vue';
import draggable from 'vuedraggable';

export default {
    data() {
        return {
            deckId: this.$route.params.deckId,
            allCards: CardService.getAllCards
        }
    },
    computed: {
        deck() {
            return DeckService
                .getDeckById(this.deckId)
        }
    },
    components: {
        CardDetails,
        DeckDetails,
        draggable
    },
    props: {
        cards: {
            type: Array,
            required: true
        }
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