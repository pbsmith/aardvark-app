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
    height: 100%;
    width: 100vw;
    background-color: rgba(92, 140, 140, 0.527);
  }
  nav{
    margin-bottom: 12vh;
  }
</style>