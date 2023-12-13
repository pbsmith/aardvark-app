<template>
    <div>
        <h1>Current Deck</h1>
        <button class="form-button" v-on:click="save()">Save</button>
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
import { ref, onMounted } from 'vue';
import draggable from 'vuedraggable';
import { useRoute } from 'vue-router';

/** In vue3, refs should be accessed using .value instead of this. */


/** In Vue 3, the data property is handled differently compared to Vue 2. 
 * Instead of defining data as a function that returns an object, 
 * you can use the Composition API and define your reactive data using the ref function. 
 * */

export default {
    setup() {
        /**vue3 router requires an import and the use of this constant variable */
        const route = useRoute();
        const deckId = route.params.deckId

        const oldDeck = ref([]);
        const currentCards = ref([]);
        const allCards = ref([]);
        const temp = ref([]);

        const fetchData = () => {
            CardService.getCardsByDeckId(deckId)
                .then((responseCurrent) => {
                    oldDeck.value = responseCurrent.data;
                    currentCards.value = responseCurrent.data;
                    console.log('in fetchData currentDeck:', currentCards.value);
                    console.log('in fetchData oldDeck:', oldDeck.value);
                })
                .catch((error) => {
                    console.error('An error occurred while fetching current cards:', error);
                });

            CardService.getAllCards()
                .then((responseAll) => {
                    temp.value = responseAll.data;
                    console.log('in fetchData temp:', temp.value)

                    /** filtering cards based on cards alone was not specific enough.
                     * changed to filtering based on cardId by creating an array of cardIds
                     * then using some() to filter based on the cardIds
                     * some() tests if at least one element in the array passes the test and returns a bool
                     */
                    const currentCardIds = currentCards.value.map(card => card.cardId);

                    allCards.value = temp.value.filter((card) => {
                        /** add all cards not in the currentdeck */
                        return !currentCardIds.some(cardId => cardId === card.cardId);
                    })
                })
                .catch((error) => {
                    console.error('An error occurred while fetching all cards:', error);
                });
        };


        /** methods do not have to be defined inside of setup(),
         * but methods outside of setup don't have access to state within setup() directly
         * save must be within setup due to the draggable arrays.
         * The draggable arrays must be accessed in order to save them
         */
        const save = () => {
            console.log('inModifyDeck, currentCards', currentCards.value)
            console.log('inModifyDeck, allCards', allCards.value)

            console.log('inModifyDeck, save, oldDeck', oldDeck)

            /**filter cards in current cards,*/
            let cardsToAdd = currentCards.value.filter((card) => {
                /** if the old deck includes the card,
                  it does not need to be added and can be filtered out
                  includes returns true if the array does include the object
                */
                return !oldDeck.value.includes(card)

            })

            console.log('in save of modify deck, cardsToAdd:', cardsToAdd)

            cardsToAdd.forEach((card) => {
                console.log('in ModifyDeck add card', card)
                card.deckId = deckId
                CardService.addCardToDeck(card)

            });


            let cardsToDelete = allCards.value.filter((card) => {
                /** if the old deck includes the card,
                 * it does not need to be added and can be filtered out
                 * includes returns true if the array does include the object
                */
                return oldDeck.value.includes(card)

            })

            console.log('in modifyDeck cardsToDelete', cardsToDelete)

            cardsToDelete.forEach((card) => {
                card.deckId = deckId
                CardService.deleteCardFromDeck(card)
            });

        };

        onMounted(() => {
            fetchData();
        });

        return { deckId, oldDeck, currentCards, allCards, save };
    },
    components: {
        draggable,
    },
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
