<template>
    <div class="cardcontainer">
        <div>
            <p>{{ currentCard.term }}</p>
            <p>{{ currentCard.definition }}</p>
        </div>
        <button  class="form-button" id="card-editBtn" v-on:click="editCard" v-if="!isFormDisplayed && isEditPage">Edit</button>
        <button  class="form-button" id="card-editBtn" v-on:click="cancelCard" v-if="isFormDisplayed && isEditPage">Cancel</button>
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
    computed: {
        isEditPage() {
            if(this.$route.name == 'deck-edit') {
                return true;
            }
            return false;
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