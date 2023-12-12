<template>
    <h1>Card Race</h1>
    <!--Display an error instead of game if not enough cards-->
    <button id="exit-race-button" class="form-button" v-on:click="returnToDetails">Exit Game</button>
    <div v-if="!isPlayable">
        <h2>Your deck must contain at least 10 cards to play this game. Please add more cards and try again.</h2>
    </div>

    <!--Display game if enough cards-->
    <div v-if="isPlayable && !isOutOfCards">
        <h2>Score: {{ cardsCorrect }}/{{ totalCards }}</h2>
        <div class="termCard">
            <h2>Current Card</h2>
            <div class="cardcontainer">
                {{ correctCard.term }}
                {{ correctCard.cardId }}
            </div>
        </div>

        <div id="popup-container" v-if="isAnswerWrong || isAnswerRight">
            <div class="popUp" v-if="isAnswerWrong">
                <span>Oops!</span>
            </div>
            <div class="popUp" v-if="isAnswerRight">
                <span>Got it! +1</span>
            </div>
        </div>

        <div class="possibleDefinitions">
            <h2>Definitions</h2>
            <div v-if="!isAnswerRight && !isAnswerWrong">
                <div class="cardcontainer" v-on:click="checkAnswer(card)" v-for="card in roundCards"
                    v-bind:key="card.cardId">
                    {{ card.definition }}
                    {{ card.cardId }}
                </div>
            </div>

        </div>
    </div>
    <div v-if="isOutOfCards">
        <button class="form-button" v-on:click="returnToDetails">Return to Deck Details</button>
        <h3>Results:</h3>
        <div v-if="cardsWrong.length > 0">
            <p>You missed the following cards:</p>
            <div class="cardcontainer" v-for="card in cardsWrong" v-bind:key="card.cardId">
                <p>
                    {{ card.term }}
                </p>
                <p>
                    {{ card.definition }}
                </p>
            </div>
        </div>
        <div v-else>
            <p>Great Job! You got all the cards right!</p>
        </div>

    </div>
</template>

<script>
/** todo :
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
            cards: {},
            shuffledCards: [],
            cardsToTest: [],
            correctCard: {},
            roundCards: [],
            cardsWrong: [],
            isOutOfCards: false,
            isPlayable: false,
            totalCards: 0,
            cardsCorrect: 0,
            isAnswerWrong: false,
            isAnswerRight: false,
        }
    },
    methods: {
        checkAnswer(card) {
            if (card.cardId == this.correctCard.cardId) {
                this.canClick = false,
                    this.cardsCorrect++;
                this.isAnswerRight = true;

                setTimeout(() => { this.getRoundCards() }, 1000)
                setTimeout(() => { this.isAnswerRight = false }, 1000)
            }
            else {
                this.cardsWrong.push(this.correctCard);
                this.isAnswerWrong = true;
                /** todo: implement try again */
                setTimeout(() => { this.getRoundCards() }, 1500)
                setTimeout(() => { this.isAnswerWrong = false }, 1500)
            }
            console.log('in check answer', this.cardsWrong)
        },

        /** if enough cards in set, 
         *  Gets a deck of cards and allows user to play
         *  if not enough cards, doesn't allow user to play.
         */
        gameSetup() {
            CardService.getCardsByDeckId(this.$route.params.deckId)
                .then(response => {
                    this.cards = response.data;
                    this.totalCards = this.cards.length
                    if (this.totalCards >= 10) {
                        this.isPlayable = true;
                        this.shuffledCards = _.shuffle(this.cards);
                        this.cardsToTest = _.shuffle(this.cards);
                        this.getRoundCards();
                    } else {
                        this.isPlayable = false;
                    }

                })
                .catch(error => {
                    this.handleError();
                })
        },
        /** add 4 cards to the round cards
             *  remove the card being tested from the card list */
        getRoundCards() {
            let counter = 0;
            if (this.cardsToTest.length > 0) {
                this.roundCards = [];
                this.correctCard = this.cardsToTest.pop();
                this.roundCards.push(this.correctCard);

                this.cardOptions = this.shuffledCards.filter((card) => { return card.cardId != this.correctCard.cardId });

                let index = 0;

                while (counter < 3) {
                    let nextCard = this.cardOptions[index];
                    this.roundCards.push(nextCard);

                    counter++;
                    index++;
                }
                this.roundCards = _.shuffle(this.roundCards);
            }
            else {
                //** add method to end game */
                this.isOutOfCards = true;
            }
        },
        returnToDetails() {
            this.$router.push({ name: 'deck-detail', params: { deckId: this.$route.params.deckId } })
        },
    },
    created() {
        this.gameSetup();
    }
}
</script>

<style>
#popup-container {
    position: fixed;
    right: 15%;
    display: flex;
    cursor: pointer;
    padding: .5rem 1rem .5rem 1rem;
    background-color: #b7b7a4;

    border-radius: .5rem;
    border: .05rem solid #b7b7a4;
    box-shadow: 0 0 .25rem #4c4e40;
}

.popUp {
    font-size: xx-large;
}
</style>