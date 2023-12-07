<template>
    <div class="cardcontainer">
        <div>
            <p>{{ currentCard.term }}</p>
            <p>{{ currentCard.definition }}</p>
        </div>
        <button v-on:click="editCard" v-if="!isFormDisplayed">Edit</button>
        <button v-on:click="cancelCard" v-if="isFormDisplayed">Cancel</button>
    </div>
    <CardForm v-if="isFormDisplayed" v-bind:card="currentCard"/>
</template>

<script>
import CardForm from '../components/CardForm.vue';

export default {
    data() {
        return {
            isFormDisplayed: false,
        }
    },
    methods: {
        editCard() {
                this.isFormDisplayed = true;
        },
        cancelCard() {
            this.isFormDisplayed = false;
        }
    },
    components: {
    CardForm
},
    props:
        ['currentCard']
}
</script>

<style scoped>
.cardcontainer {
    padding: 2vh;
    border: 0.2rem solid black;
}
</style>