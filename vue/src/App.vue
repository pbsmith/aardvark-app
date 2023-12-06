<template>
  <div id="capstone-app">
    <nav>
      <NavHeader />
    </nav>
    <router-view id="view"/>
  </div>
</template>

<script>
import NavHeader from './components/NavHeader.vue';

export default {
  components: {
    NavHeader
  }
}
</script>

<style >
  body{
    background-color: darkcyan;
  }
  nav{
    margin-bottom: 12vh;
  }
</style>