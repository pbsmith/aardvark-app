<template>
    <div class="cardcontainer">
        <div>
            <p>{{ card.term }}</p>
            <p>{{ card.definition }}</p>
        </div>
    </div>
</template>

<script>

export default {
    props:
        ['card']
}
</script>

<style scoped>
.cardcontainer {
    padding: 2vh;
    border: 0.2rem solid black;
}
</style>