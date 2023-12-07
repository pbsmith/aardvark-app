<template>
    <CardForm v-bind:card="card"/>
</template>

<script>
import CardForm from '../components/CardForm.vue'

export default {
    components:{
        CardForm
    },
    data(){
        return{
            card:{
                cardId: 0,
                deckId: 0,
                cardTerm: '',
                cardDefinition: '',
                userId: 0,
            }
        }
    }
}
</script>