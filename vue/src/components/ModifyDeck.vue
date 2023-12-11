<template>
    <div >
        <h1>Current Deck</h1>
        <button v-on:click="save(currentCards, allCards)">Save</button>
        <draggable id="draggable" v-model="currentCards" tag="ul" group="meals" item-key="card.cardId">
            <template #item="{ element: card }">
                <li class="cardcontainer">
                    <p>{{ card.term }}</p>
                    <p>{{ card.definition }}</p>
                </li>
            </template>
        </draggable>
        <h1>All Available Cards</h1>
        <draggable v-model="allCards" tag="ul" group="meals" item-key="card.cardId">
            <template #item="{ element: card }">
                <li class="cardcontainer">
                    <p>{{ card.term }}</p>
                    <p>{{ card.definition }}</p>
                </li>
            </template>
        </draggable>
    </div>
</template>


<script setup>
import { ref, onMounted } from 'vue';
import draggable from 'vuedraggable';
import CardService from '../services/CardService';
const currentCards = ref([]);
const allCards = ref([]);
/** using async allows the use of await in the function.
 *  await prevents a syntax error
 *  await is used to wait for a promise to resolve
 *  before moving onto the next line of code
 */
const fetchData = async () => {
    try {
        const response1 = await CardService.getCardsByDeckId(1);
        currentCards.value = response1.data;
        const response2 = await CardService.getAllCards();
        allCards.value = response2.data;
    } catch (error) {
        console.error('An error occurred while fetching data:', error);
    }
};
onMounted(() => fetchData())
</script>


<script>
export default {
    data() {
        return {
            oldDeck: [],
        }
    },
    methods: {
        save(currentCards, allCards) {
            console.log(currentCards)
            currentCards.filter((card) => {
                this.oldDeck.forEach((c) => {
                    if (card != c) {
                        console.log('foreach loop',card)
                        return true;
                    }
                    else {
                        return false;
                    }
                })
            }).forEach((card) => {
                CardService.addCardToDeck(card)
            });
            allCards.filter((card) => {
                this.oldDeck.forEach((c) => {
                    if (card == c) {
                        return true;
                    }
                    else {
                        return false;
                    }
                })
            }).forEach((card) => {
                CardService.deleteCardFromDeck(card)
            });
        },
        getCardsByDeckId() {
            this.oldDeck = CardService.getCardsByDeckId(this.$route.params.deckId);
        }
    }
}
</script>

<style>
ul {
    list-style: none;
}
</style>

