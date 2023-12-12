<template>
    <h1>Card Race</h1>
    <!--Display an error instead of game if not enough cards-->
    <div v-if="!checkPlayability">
        <h2>Your deck must contain at least 10 cards to play this game. Please add more cards and try again.</h2>
    </div>
    <!--Display game if enough cards-->
    <div v-if="checkPlayability">
        <div class="termCard">
            <h2>Current Card</h2>
            <div class="cardcontainer">
                {{ correctCard.term }}
            </div>
        </div>
        <div class="possibleDefinitions">
            <h2>Definitions</h2>
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
            isOutOfCards: false,
        }
    },
    methods: {
        /** checks to see if user has 10 or more cards.
         * if user has 10+ cards, game displays.
         * if user has less than 10 cards, error displays.
         */
        checkPlayability() {
            if (this.cards.length >= 10) {
                return true;
            }
            else {
                return false;
            }
        },
        /** if enough cards in set, 
         *  Gets a deck of cards and allows user to play
         *  if not enough cards, doesn't allow user to play.
         */
        getShuffledCards() {
            CardService.getCardsByDeckId(this.$route.params.deckId)
                .then(response => {
                    console.log(this.cards)
                    this.cards = response.data;
                    this.shuffledCards = _.shuffle(this.cards);
                    this.getRoundCards();
                })
                .catch(error => {
                    this.handleError();
                })
        },
        /** add 4 cards to the round cards
             *  remove the card being tested from the card list */
        getRoundCards() {
            let counter = 0;
            if (this.cards.length >= 4) {
                this.correctCard = this.cards.pop();
                this.roundCards.push(this.correctCard);
                while (counter < 3) {
                    this.cards = _.shuffle(this.cards);

                    let nextCard = this.cards.pop();
                    this.roundCards.push(nextCard);

                    counter++;
                }
                console.log('in get roundCards', this.roundCards)
                this.roundCards = _.shuffle(this.roundCards);
            }
            else {
                //** add method to end game */
                this.isOutOfCards = true;
            }
        }
    },
    created() {
        this.checkPlayability();
        this.getShuffledCards();
        this.getRoundCards();

    }
}
</script>