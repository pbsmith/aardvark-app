<template>
    <div>
        <div class="flex-top">
            <div><span class="form-button-mock">Turns : <span class="badge"
                        :class="finish ? 'badge-success' : 'badge-light'">{{ turns }}</span> </span></div>
            <div><span class="form-button-mock">Total Time : <span class="badge"
                        :class="finish ? 'badge-success' : 'badge-light'">{{ min }} : {{ sec }}</span></span></div>
            <div><button class="form-button" @click="reset" :disabled="!start">Restart</button></div>
        </div>
            <div class="allcards">
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
.flex-top {
    display: flex;
}

.form-button-mock {
    margin: 1rem 1rem .5rem 1rem;
  padding: .5rem 1rem .5rem 1rem;
  background-color: #b7b7a4;

  border-radius: .5rem;
  border: .05rem solid #b7b7a4;
  box-shadow: 0 0 .25rem #4c4e40;
}

#term-header, #definition-header{
    justify-content: center;
}

#term-cardbox {
    display: flex;
    flex-wrap: wrap;
}

#definition-cardbox {
    display: flex;
    flex-wrap: wrap;

}

#front img {
    background-size: cover;
    max-width: 100%;
}

.matched {
    opacity: 0.3;
}

.allcards {
    display: flex;
    flex-wrap: wrap;
    padding: 1rem;
    justify-content: center;
}

.cardbox {
    padding: 1rem;
}


#front {
    border: solid #4c4e40;
    border-radius: 1rem;
    display: flex;
    justify-content: center;
    align-items: center;
    overflow: hidden;
    width: 12rem;
    height: 10rem;
    background-size: contain;
    background-color: #ffe8d6;
    padding: 1rem;
}

#back {
    border: solid #4c4e40;
    border-radius: 1rem;
    display: flex;
    justify-content: center;
    align-items: center;
    overflow: hidden;
    height: 100%;
    width: 12rem;
    height: 10rem;
    background-color: #ffe8d6;
    padding: 1rem;
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