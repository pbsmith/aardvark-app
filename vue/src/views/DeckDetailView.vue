<template>
    <div class="deck-container">
        <DeckDetails v-bind:deck="deck"/>
    </div>
</template>

<script>
import DeckDetails from '../components/DeckDetails.vue';

export default{
    props:['deck'],
    components:{
        DeckDetails,
    }
}
</script>