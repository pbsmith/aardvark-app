<template>
    <div class="cardcontainer">
        <div>
            <p>{{ card.cardTerm }}</p>
            <p>{{ card.cardDefinition }}</p>
            <p>{{ card.cardTags }}</p>
        </div>
    </div>
</template>

<script>
import CardService from '../services/CardService';

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