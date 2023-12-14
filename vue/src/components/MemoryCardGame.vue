<template>
    <div v-if="this.finish == false">
        <div class="flex-top">
            <div><span class="form-button-mock">Turns : <span class="badge"
                        :class="finish ? 'badge-success' : 'badge-light'">{{ turns }}</span> </span></div>
            <div><span class="form-button-mock">Total Time : <span class="badge"
                        :class="finish ? 'badge-success' : 'badge-light'">{{ min }} : {{ sec }}</span></span></div>
            <div><button class="form-button" @click="reset" :disabled="!start">Restart</button></div>
            <button class="form-button"><router-link :to="{ name: 'deck-detail' }">Back to Deck</router-link></button>
        </div>
        <div class="allcards">
            <div id="terms-width">
                <h1 id="term-header">Terms</h1>
                <div id="term-cardbox">
                    <div v-for="card in terms" class="flip-container cardbox" v-bind:key="card.cardId"
                        :class="{ 'flipped': card.isFlipped, 'matched': card.isMatched }" v-on:click="flipCard(card)">
                        <div class="memorycard">
                            <div class="front border rounded shadow" id="front">
                                <img id="pattern" src="../imgs/MemoryCardPattern.png">
                            </div>
                            <div class="back rounded border" id="back">
                                <div>
                                    <p>{{ card.term }}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="definitions-width">
                <h1 id="definition-header">Definitions</h1>
                <div id="definition-cardbox">
                    <div v-for="card in definitions" class="flip-container cardbox" v-bind:key="card.cardId"
                        :class="{ 'flipped': card.isFlipped, 'matched': card.isMatched }" v-on:click="flipCard(card)">
                        <div class="memorycard">
                            <div class="front border rounded" id="front">
                                <img src="../imgs/MemoryCardPattern.png" id="pattern">
                            </div>
                            <div class="back rounded border" id="back">
                                <div>
                                    <p>{{ card.definition }}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div v-if="this.finish == true" id="finish-popup">
        <div class="turns-final"><span>Turns : <span>{{ turns }}</span> </span></div>
        <div class="time-final"><span>Total Time : <span>{{ min }} : {{ sec }}</span></span></div>
        <div><button class="form-button reset-button" @click="reset" :disabled="!start">Restart</button></div>
        <button class="form-button"><router-link :to="{ name: 'deck-detail' }">Back to Deck</router-link></button>
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
            flippedCards: [],
            finish: false,
            start: false,
            turns: 0,
            totalTime: {
                minutes: 0,
                seconds: 0
            }
        }
    },
    created() {

        /**Shuffle and split cards */
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
    computed: {
        sec() {
            if (this.totalTime.seconds < 10) {
                return '0' + this.totalTime.seconds;
            }
            return this.totalTime.seconds;
        },
        min() {
            if (this.totalTime.minutes < 10) {
                return '0' + this.totalTime.minutes;
            }
            return this.totalTime.minutes;
        }
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
            if (card.isMatched || card.isFlipped || this.flippedCards.length === 2) {
                return;
            }

            if (!this.start) {
                this._startGame();
            }

            card.isFlipped = true;

            if (this.flippedCards.length < 2) {
                this.flippedCards.push(card);
            }
            if (this.flippedCards.length === 2) {
                this._match(card);
            }


        },
        _match(card) {
            this.turns++;
            if (this.flippedCards[0].cardId === this.flippedCards[1].cardId) {
                setTimeout(() => {
                    this.flippedCards.forEach(card => card.isMatched = true);
                    this.flippedCards = [];

                    if (this.definitions.every(card => card.isMatched === true) && this.terms.every(card => card.isMatched === true)) {
                        clearInterval(this.interval);
                        this.finish = true;
                    }
                }, 400);
            }
            else {
                setTimeout(() => {
                    this.flippedCards.forEach((card) => { card.isFlipped = false });
                    this.flippedCards = [];
                }, 800);
            }
        },
        _startGame() {
            this._tick();
            this.interval = setInterval(this._tick, 1000);
            this.start = true;
        },

        _tick() {
            if (this.totalTime.seconds !== 59) {
                this.totalTime.seconds++;
                return
            }

            this.totalTime.minutes++;
            this.totalTime.seconds = 0;
        },
        reset() {
            clearInterval(this.interval);

            this.allCards = [];
            this.terms = [];
            this.definitions = [];
            this.allCards = this.shuffle(this.cards);
            for (let i = 0; i < this.allCards.length; i++) {
                this.definitions.push(this.allCards[i]);
                this.terms.push(Object.assign({}, this.allCards[i]));
            }

            this.definitions.forEach((card) => {
                card.isFlipped = false;
                card.isMatched = false;
            });
            this.terms.forEach((card) => {
                card.isFlipped = false;
                card.isMatched = false;
            });

            setTimeout(() => {
                this.totalTime.minutes = 0;
                this.totalTime.seconds = 0;
                this.start = false;
                this.finish = false;
                this.turns = 0;
                this.flippedCards = [];

            }, 600);

            this.definitions = this.shuffle(this.definitions)
            this.terms = this.shuffle(this.terms)
        },
    }
}
</script>


<style>

#terms-width {
    width: 50%;
}

#definitions-width {
    width: 50%;
}

.turns-final {
    height: 5rem;
    justify-content: center;
    align-items: center;
    text-align: center;
    margin-top: 5rem;
    font-size: xx-large;
}

.time-final {
    height: 5rem;
    justify-content: center;
    align-items: center;
    text-align: center;
    font-size: xx-large;
}

.reset-button {
    justify-content: center;
    align-items: center;
    text-align: center;
}

.reset-button:hover { 
  cursor: pointer;
  transition: background-color 0.3s ease;
  background-color: #753B00;

}

#finish-popup {
    margin: auto;
    margin-top: .5rem;
    padding: 0rem 1.2rem 1.2rem 1.2rem;
    background-color: #1C0B00;
    width: 40%;
    height: 30rem;
    border: .05rem solid #2D1800;
    border-radius: 1rem;
    box-shadow: 0 0 1rem #2D1800;
    color: #E5AC65;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    display: flex;
}

/** 
.vertical-line {
    border-left: 0.25rem solid black;
    border-radius: 0.25rem;
    height: 40rem;
    position: absolute;
    left: 50%;
    top: 20%;
}
*/

#term-header,
#definition-header {
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center;
    background-color: #1C0B00;
    color: #E5AC65;
    box-shadow: 0 0 0.25rem #1C0B00;
    height: 4rem;
    margin-right: 15rem;
    margin-left: 15rem;
    padding-left: 5rem;
    padding-right: 5rem;
}

.flex-top {
    display: flex;
}

.form-button-mock {
    margin: 1rem 1rem .5rem 1rem;
    padding: .5rem 1rem .5rem 1rem;
    color: #E5AC65;
    background-color: #753B00;
    border-radius: .5rem;
    border: .05rem solid #2D1800;
    box-shadow: 0 0 0.25rem #1C0B00;
}

#term-cardbox {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
}

#definition-cardbox {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
}

#front img {
    background-size: cover;
    max-width: 100%;
    background-color: #753B00;
}

.matched {
    opacity: 0.3;
}

.allcards {
    display: flex;

}

.cardbox {
    padding: 1rem;
}


#front {
    border: solid black;
    border-radius: 1rem;
    overflow: hidden;
    width: 8vw;
    height: 8vw;
    background-size: contain;
    background-color: #753B00;
    padding: 1rem;
    box-shadow: 0 0 .25rem black;
}

#back {
    border: solid black;
    border-radius: 1rem;
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center;
    overflow: hidden;
    height: 100%;
    width: 8vw;
    height: 8vw;
    background-color: #ffe8d6;
    padding: 1rem;
    box-shadow: 0 0 .25rem black;
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