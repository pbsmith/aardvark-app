<template>
    <div>
        <button class="form-button" v-on:click="startGame" v-if="!isStarted">Start</button>
    </div>
    <div>
        <MemoryCardGame v-if="isStarted" v-bind:cards="cards"/>
    </div>
</template>

<script>
import MemoryCardGame from '../components/MemoryCardGame.vue'
import CardService from '../services/CardService'

export default {
    data() {
        return {
            isStarted: false,
            cards: []
        }
    },
    components: {
        MemoryCardGame
    },
    created() {
        CardService
            .getCardsByDeckId(this.$route.params.deckId)
            .then(response => {
                if(response.status === 200) {
                    this.cards = response.data;
                }
            })
    },
    methods: {
        startGame() {
            this.isStarted = true;
        }    
    }
}
</script>