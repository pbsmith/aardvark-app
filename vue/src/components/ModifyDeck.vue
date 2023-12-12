<template>
    <div>
        <h1>Current Deck</h1>
        <button class="form-button" v-on:click="save(currentCards, allCards)">Save</button>
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
        }
    },
    props: [],
    methods: {
        save(currentCards, allCards) {
            console.log('inModifyDeck, currentCards', currentCards)
            console.log('inModifyDeck, allCards', allCards)

            console.log('inModifyDeck, save, oldDeck', oldDeck)

            /** filter cards in current cards, */
            let cardsToAdd = currentCards.filter((card) => {
                /** if the old deck includes the card,
                 * it does not need to be added and can be filtered out
                 * includes returns true if the array does include the object
                */
                if (oldDeck.includes(card)) {
                    return false;
                    console.log('in ModifyDeck, oldDeck doesnt include', card)
                }
                else {
                    return true;
                    console.log('in ModifyDeck, oldDeck does include', card)
                }

            }).forEach((card) => {
                console.log('in ModifyDeck add card', card)
                /*card.deckId = this.$route.params.deckId
                CardService.addCardToDeck(card)*/

            });
            console.log('in modifyDeck cardsToAdd', cardsToAdd)

            let cardsToDelete = allCards.filter((card) => {
                /** if the old deck includes the card,
                 * it does not need to be added and can be filtered out
                 * includes returns true if the array does include the object
                */
                if (oldDeck.includes(card)) {
                    return true;
                }
                else {
                    return false;
                }

            }).forEach((card) => {
                /*CardService.deleteCardFromDeck(card)*/
            });
            console.log('in modifyDeck cardsToDelete', cardsToDelete)
        }
    }
}
</script>

<style>
.cards {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    justify-content: space-around;
}
</style>
