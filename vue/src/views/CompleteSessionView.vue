<template>
  <div class="complete-view">
    <h1>Complete Session</h1>
    <div>
      <h2>score:</h2>
    </div>
    <div>
      <h2>Right: {{ numberOfRightAnswers }}</h2>
    </div>
    <div>
      <h2>Wrong: {{ numberOfWrongAnswers }}</h2>
    </div>
  </div>
</template>
  
<script>
export default {
  computed: {
    numberOfRightAnswers() {
      return this.$state.rightAnswers.length
    },
    numberOfWrongAnswers() {
      return this.$state.wrongAnswers.length
    },
  },
};
</script>
<style>
.complete-view {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  box-shadow: 0 0px 10px rgba(0, 0, 0, 0.4);
  background-color: #6b705c;

}
</style>
  