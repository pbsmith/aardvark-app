<template>
    <div id="app">
        <div class="row">
            <div class="allcards">
                <div v-for="card in definitions" class="flip-container" id="cardbox" v-bind:key="card.cardId"
                    :class="{ 'flipped': card.isFlipped }" v-on:click="flipCard(card)">
                    <div class="memorycard">
                        <div class="front border rounded cardcontainer" id="front">
                            <img width="100" height="150" src="../imgs/MemoryCardPattern.png">
                        </div>
                        <div class="back rounded border cardcontainer" id="back">
                            <div width="100" height="150">
                                <p>{{ card.definition }}</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div v-for="card in terms" class="col-auto mb-3 flip-container" id="cardbox" v-bind:key="card.cardId"
                    :class="{ 'flipped': card.isFlipped }" v-on:click="flipCard(card)">
                    <div class="memorycard">
                        <div class="front border rounded shadow cardcontainer" id="front">
                            <img width="100" height="150" src="../imgs/MemoryCardPattern.png">
                        </div>
                        <div class="back rounded border cardcontainer" id="back">
                            <div width="100" height="150">
                                <p>{{ card.term }}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
export default {
    props: {
        cards: {
            type: Array,
            required: true
        }
    },
    data() {
        return {
            definitions: [],
            terms: [],
            allCards: [],
            flippedCards: []
        }
    },
    created() {

        /**Shuffle cards and put into allCards */
        this.allCards = this.shuffle(this.cards);
        for (let i = 0; i < this.allCards.length; i++) {
            this.definitions.push(this.allCards[i]);
            this.terms.push(Object.assign({}, this.allCards[i]));
        }

        /**Give all definitions and all terms the isFlipped and isMatched properties of false */
        this.definitions.forEach((card) => {
            card.isFlipped = false;
            card.isMatched = false;
        });
        this.terms.forEach((card) => {
            card.isFlipped = false;
            card.isMatched = false;
        });

        /**Shuffle both arrays */
        this.definitions = this.shuffle(this.definitions)
        this.terms = this.shuffle(this.terms)
    },
    methods: {
        shuffle(array) {
            for (let i = array.length - 1; i > 0; i--) {
                let j = Math.floor(Math.random() * (i + 1));
                [array[i], array[j]] = [array[j], array[i]];
            }
            return array;
        },
        flipCard(card) {
            /**  */
            if (card.isMatched) {
                card.isFlipped=true;
            }
            else if (card.isMatched == false && card.isFlipped == false) {
                card.isFlipped = true;
                if (this.flippedCards.length < 2) {
                    this.flippedCards.push(card);
                }
                else if (this.flippedCards.length === 2) {
                    this._match(card);
                }
            }
            else if (card.isMatched == false && card.isFlipped == true) {
                card.isFlipped = false;
                if (this.flippedCards.length < 2) {
                    this.flippedCards.push(card);
                }
                else if (this.flippedCards.length === 2) {
                    this._match(card);
                }
            }



        },
        _match(card) {
            if (this.flippedCards[0].cardId == card.cardId) {
                this.flippedCards[0].isMatched = true;
                card.isMatched = true;
            }
            else {
                this.flippedCards[0].isFlipped = false;
                card.isFlipped = false;
            }

            this.flippedCards = [];
        }
    }
}
</script>


<style>
.allcards {
    display: flex;
    flex-wrap: wrap;
    padding: 2rem;
}

#cardbox {
    max-height: 3rem;
    max-width: 10rem;
    padding: 2rem;
}

#front {
    border: solid #4c4e40;
    border-radius: 0.5rem;
}

#back {
    border: solid;
    border-radius: 0.5rem;
}

/** Below is the CSS for making memory cards flip 
copied from the internet */
.flip-container {
    -webkit-perspective: 1000;
    -moz-perspective: 1000;
    -o-perspective: 1000;
    perspective: 1000;
    min-height: 120px;
    cursor: pointer;
}

.front,
.back {
    -webkit-backface-visibility: hidden;
    -moz-backface-visibility: hidden;
    -o-backface-visibility: hidden;
    backface-visibility: hidden;
    -webkit-transition: 0.6s;
    -webkit-transform-style: preserve-3d;
    -moz-transition: 0.6s;
    -moz-transform-style: preserve-3d;
    -o-transition: 0.6s;
    -o-transform-style: preserve-3d;
    -ms-transition: 0.6s;
    -ms-transform-style: preserve-3d;
    transition: 0.6s;
    transform-style: preserve-3d;
    top: 0;
    left: 0;
    width: 100%;
}

.back {
    -webkit-transform: rotateY(-180deg);
    -moz-transform: rotateY(-180deg);
    -o-transform: rotateY(-180deg);
    -ms-transform: rotateY(-180deg);
    transform: rotateY(-180deg);
    position: absolute;
}

.flip-container.flipped .back {
    -webkit-transform: rotateY(0deg);
    -moz-transform: rotateY(0deg);
    -o-transform: rotateY(0deg);
    -ms-transform: rotateY(0deg);
    transform: rotateY(0deg);
}

.flip-container.flipped .front {
    -webkit-transform: rotateY(180deg);
    -moz-transform: rotateY(180deg);
    -o-transform: rotateY(180deg);
    -ms-transform: rotateY(180deg);
    transform: rotateY(180deg);
}
</style>