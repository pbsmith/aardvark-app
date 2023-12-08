<template>
    <div class="cardswithBtns">
        <div class="card-container">
            <div class="card" :class="{ 'flipped': isFlipped }">
                <div class="front">
                    <h4>{{ currentCard.term }}</h4>
                </div>
                <div class="back">
                    <h4>{{ currentCard.definition }}</h4>
                </div>
            </div>
        </div>
        <div>
            <button class="btn" @click="toggleIcon"><i class="pi pi-times"></i></button>
            <button class="btn" @click="toggleIcon"><i class="pi pi-check"></i></button>
            <button class="btn eye" @click="flipCard"><i class="pi pi-eye"></i></button>
        </div>
    </div>
</template>
  
<script>
import 'primeicons/primeicons.css'
export default {
    components: {},
    data() {
        return {
            isFlipped: false,
            isWrong: false,
            isRight: false,
        };
    },
    computed: {},
    methods: {
        flipCard() {
            this.isFlipped = !this.isFlipped;
        },
        toggleIcon() {
            this.isWrong = !this.isWrong;
        },
    },
    props: ['currentCard'],
};
</script>
  
<style scoped>
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    overflow: hidden;
}
/*
.icon-wrong {
    color: #ff5555;
}

.icon-right {
    color: #55ff55;
}

.card i {
    font-size: 3em;
    position: absolute;
    font-size: 8rem;
}
*/
.btn {
    width: 3rem;
    height: 2rem;
    border-radius: .3rem;
    margin-left: 1rem;
    cursor: pointer;
    font-size: 1.2rem;
    text-align: center;
}

.flippable {
    transition: 0.5s;
    transform-style: preserve-3d;
    position: relative;
}

.card.flipped {
    transform: rotateY(180deg);
}

.cardswithBtns {
    min-width: 12.875rem;
    min-height: 12.25rem;
    padding: 1rem;
    display: flex;
    flex-direction: column;
    justify-content: center;
}

.card-container {
    min-width: 12.875rem;
    min-height: 12.25rem;
    perspective: 800px;
    margin-bottom: 1rem;
}

.card {
    width: 100%;
    height: 100%;
    background-color: #6b705c;
    border-radius: 1rem;
    box-shadow: 0 0 0.2rem 0.1rem rgba(50, 50, 50, 0.25);
    position: relative;
    transform-style: preserve-3d;
    transition: transform 1500ms;
    text-align: center;
}

.front,
.back {
    position: absolute;
    width: 100%;
    height: 100%;
    backface-visibility: hidden;
    display: flex;
    justify-content: center;
    align-items: center;
}

.front {
    transform: rotateY(0deg);
}

.back {
    transform: rotateY(180deg);
}

.back h4 {
    margin: 1rem;
    color: white;
}
</style>

  