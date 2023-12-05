<template>
    <div class="deckcontainer">
        <h1>
            {{ deck.deckTitle }}
        </h1>
        <div>
            <p>{{ deck.deckDesc }}</p>
            <p>{{ deck.deckTags }}</p>
        </div>
    </div>
</template>

<script>
    import deckService from "../services/DeckService.js";

    export default {
        props:
            ['deck']
    }
</script>

<style scoped>
    .deckcontainer {
        padding: 2vh;
        border: 0.2rem solid black;
    }
</style>