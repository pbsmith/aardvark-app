<template>
    <DeckForm v-bind:deck="deck"/>
</template>

<script>
import DeckForm from '../components/DeckForm.vue'

export default{
    components:{
        DeckForm
    },
    data(){
        return{
            deck:{
                deckId: 0,
                userId: 0,
                deckTitle:'',
                deckDesc:'',
                deckTags:''
            }
        }
    }
}
</script>