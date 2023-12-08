<template>
    <h1>Current Deck</h1>

    <!--Notice the group prop is the same on both <draggable>-->
    <draggable v-model="currentCards" tag="ul" group="meals">
        <template #item="{ element: card }">
            <li>{{ card }}</li>
        </template>
    </draggable>

    <h1>All Available Cards</h1>
    <draggable v-model="allCards" tag="ul" group="meals">
        <template #item="{ element: card }">
            <li>{{ card }}</li>
        </template>
    </draggable>
</template>

<script setup>
import { ref } from 'vue';
import draggable from 'vuedraggable';

const currentCards = ref([
    'Bat wing soup',
    'Spicy Octopus',
    'Anything from Taco Bell',
]);

const allCards = ref([
    'Bat wing soup',
    'Spicy Octopus',
    'Anything from Taco Bell',
]);
</script>

<script>
import CardService from '../services/CardService';

export default {
    data() {
        return {
            getCurrentCards: CardService.getCardsByDeckId(this.$route.params.deckId),
        }
    },
    created: {
        consoleLog() {
            console.log(CardService.getAllCards(this.$route.params.deckId))
        }
    }
};
</script>



