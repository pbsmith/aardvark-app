<template>
    <div class="cardcontainer">
        <div>
            <p>{{ currentCard.term }}</p>
            <p>{{ currentCard.definition }}</p>
        </div>
    </div>
</template>

<script>

export default {
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