<template>
    <div >
        <div class="card-container" @click="flipCard">
        <div class="card" :class="{ 'flipped': isFlipped }">
            <div class="front">
                <h4>{{ currentCard.term }}</h4>
            </div>
            <div class="back">
                <h4>{{ currentCard.definition }}</h4>
            </div>
        </div>
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
        };
    },
    computed: {},
    methods: {
        flipCard() {
            this.isFlipped = !this.isFlipped;
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


.card.flipped {
    transform: rotateY(180deg);
}

.card-container {
    width: 40rem;
    height: 20rem;
    background-color: rgba(255, 0, 0, 0.075);

}

.card {
    width: 100%;
    height: 100%;
    background-color: #6b705c;
    border-radius: 1rem;
    position: relative;
    transform-style: preserve-3d;
    transition: transform 1500ms;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
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
    font-size: 1.5rem;
}

.back {
    transform: rotateY(180deg);
    font-size: 1.5rem;
}

.back h4 {
    margin: 1rem;
    color: white;
}
</style>

  