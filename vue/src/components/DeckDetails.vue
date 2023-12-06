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

export default {
    props:
        ['deck']
}
</script>

<style scoped>
.deckcontainer {
    display: flex;
    flex-direction: row;
    padding: 2vh;
    border: 0.2rem solid black;
}
</style>