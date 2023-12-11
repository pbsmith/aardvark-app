<template>
    <div v-for="card in cards" v-bind:class="{'flipped': card.isFlipped}" v-on:click="flipCard(card)">

    </div>
</template>

<script>


export default {
    created() {
        this.cards.forEach( (card) => {
            Vue.set(card, 'isFlipped', false)
        });
    },
    methods: {
        flipCard(card) {
            card.isFlipped = true;
        }
    }
}
</script>