<template>
    <div class="deckcontainer">
        <h2>
            {{ deck.deckTitle }}
        </h2>
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
