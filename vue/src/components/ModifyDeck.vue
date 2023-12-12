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

<script>
import CardService from '../services/CardService';
import { ref } from 'vue';
import draggable from 'vuedraggable';

let currentCards = ref([]);
let allCards = ref([]);

export default {
    data() {
        return {
            deckId: this.$route.params.deckId,
        }
    },
    props: ['oldDeck'],
    components: {
        draggable
    },
    methods: {
        save(currentCards, allCards) {
            console.log('inModifyDeck, currentCards', currentCards)
            console.log('inModifyDeck, allCards', allCards)

            console.log('inModifyDeck, save, oldDeck', this.oldDeck)

            /** filter cards in current cards, */
            let cardsToAdd = currentCards.filter((card) => {
                /** if the old deck includes the card,
                 * it does not need to be added and can be filtered out
                 * includes returns true if the array does include the object
                */
                if (this.oldDeck.includes(card)) {
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
                if (this.oldDeck.includes(card)) {
                    return true;
                }
                else {
                    return false;
                }

            }).forEach((card) => {
                /*CardService.deleteCardFromDeck(card)*/
            });
            console.log('in modifyDeck cardsToDelete', cardsToDelete)
        },
        fetchData() {
            try {
                let response1 = CardService.getCardsByDeckId(this.deckId)
                    .then(response => {
                        currentCards = response1.data;
                    });
                let response2 = CardService.getAllCards()
                    .then(response => {
                        allCards = response2.data;
                    });

            } catch (error) {
                console.error('An error occurred while fetching data:', error);
            }
        },
    },
    onMounted(){
        this.fetchData();
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
