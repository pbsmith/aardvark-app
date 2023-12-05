<template>
  <div id="capstone-app">
    <nav>
      <NavHeader />
    </nav>
    
    <router-view />
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

<style>
  * {
    background-color: #99cced;
  }

</style>