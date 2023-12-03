<template>
    <div class="deck" v-for="deck in decks" :key="deck.id"></div>
</template>

<script>
export default{
    props:{
        decks:{
            type: Array,
            required: true
        }
    }
};
</script>