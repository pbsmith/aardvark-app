<template>
    <h1>Card Race</h1>
    <!--Display an error instead of game if not enough cards-->
    <div v-if="!canPlay">
        <h2>Your deck must contain at least 10 cards to play this game. Please add more cards and try again.</h2>
    </div>
    <!--Display game if enough cards-->
    <div v-if="canPlay">
        <div class="termCard">
            <div class="cardcontainer">
                {{ correctCard.term }}
            </div>
        </div>
        <div class="possibleDefinitions">
            <div class="cardcontainer" v-for="card in roundCards" v-bind:key="card.cardId">
                {{ card.definition }}
            </div>
        </div>
    </div>
</template>

<script>
/** todo :
 * check data
 * check display
 * add timer
 * add correct/incorrect
 * add game ending
 * add cancel button
 */
import CardService from '../services/CardService';
import _ from 'lodash';

export default {
    data() {
        return {
            cards: [],
            correctCard: {},
            roundCards: [],
            canPlay: false,
            isOutOfCards: false,
        }
    },
    methods: {
        /** if enough cards in set, 
         *  Gets a deck of cards and allows user to play
         *  if not enough cards, doesn't allow user to play.
         */
        getShuffledCards() {
            CardService.getCardsByDeckId(this.$route.params.deckId)
                .then(response => {
                    this.cards = response.data;
                    if (this.cards.length >= 10) {
                        this.shuffledCards = _.shuffle(this.cards);
                        this.canPlay = true;
                        this.getRoundCards();
                    }
                    else {
                        this.canPlay = false;
                    }
                })
                .catch(error => {
                    this.handleError();
                })
        },
        getRoundCards() {
            /** add 4 cards to the round cards
             *  remove the card being tested from the card list */
            let counter = 0;
            if (this.cards.length >= 4) {
                this.correctCard = this.cards.pop();
                this.roundCards.push(this.correctCard);
                while (counter > 3) {
                    let indexNum = Math.random(this.cards.count - 1, 0);
                    this.roundCards.push(this.cards[indexNum]);
                    counter++;
                }
                this.roundCards = _.shuffle(this.roundCards);
            }
            else {
                //** add method to end game */
                this.isOutOfCards = true;
            }
        }
    },
    created() {
        this.getShuffledCards()
    }

}
</script>