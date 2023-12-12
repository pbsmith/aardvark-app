<template>
    <div @click="flipCard">
        <div v-bind:style="{ backgroundColor: colorFront, color: colorTextFront }" v-show="!isToggle"
            class="animated flipInX flashcard">
            <div class="card-content center">
                <p v-bind:style="{ fontSize: textSizeFront, fontWeight: 'bold' }">{{ currentCard.term }}</p>
            </div>
            <div class="card-footer">{{ footerFront }}</div>
        </div>
        <div v-bind:style="{ backgroundColor: colorBack, color: colorTextBack }" v-show="isToggle"
            class="animated flipInX flashcard">
            <div class="card-content center">
                <p v-bind:style="{ fontSize: textSizeBack, fontWeight: 'bold' }">{{ currentCard.definition }}</p>
            </div>
            <div class="card-footer">{{ footerBack }}</div>
        </div>
    </div>
</template>
  
<script>
import 'primeicons/primeicons.css'
export default {
    props: {
        currentCard: {
            type: Object,
        },
        front: {
            type: String,
            default: 'default front',
        },
        back: {
            type: String,
            default: 'default back',
        },
        textSizeFront: {
            type: String,
            default: '2em'
        },
        textSizeBack: {
            type: String,
            default: '2em'
        },
        colorTextFront: {
            type: String,
            default: 'white'
        },
        colorTextBack: {
            type: String,
            default: 'white'
        },
        colorFront: {
            type: String,
            default: '#6b705c'
        },
        colorBack: {
            type: String,
            default: '#6b705c'
        },
        footerFront: {
            type: String,
            default: 'Click to show Back'
        },
        footerBack: {
            type: String,
            default: 'Click to show Front'
        },
    },
    computed: {
        isToggle() {
            return this.$store.state.cardFlipped 
        },
    },
    methods: {
        flipCard() {
            this.$store.commit('FLIP_CARD')
        },
    },
}
</script>
  
<style scoped>
.center {
    text-align: center;
}

.flashcard {
    cursor: pointer;
    border-radius: 10px;
    margin: .5rem;
    padding: 1rem;
    box-shadow: 0 0px 10px rgba(0, 0, 0, 0.4);
    text-align: center;
    width: 45rem;
    height: 15rem;
}

.animated {
    animation-duration: 0.75s;
    animation-fill-mode: both;
}

@keyframes flipInX {
    from {
        transform: perspective(400px) rotate3d(1, 0, 0, 90deg);
        animation-timing-function: ease-in;
        opacity: 0;
    }

    40% {
        transform: perspective(400px) rotate3d(1, 0, 0, -10deg);
        animation-timing-function: ease-in;
    }

    60% {
        transform: perspective(400px) rotate3d(1, 0, 0, 10deg);
        opacity: 1;
    }

    80% {
        transform: perspective(400px) rotate3d(1, 0, 0, -5deg);
    }

    to {
        transform: perspective(400px);
    }
}

.flipInX {
    backface-visibility: visible !important;
    animation-name: flipInX;
}</style>