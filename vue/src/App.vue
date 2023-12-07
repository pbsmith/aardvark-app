<template>
  <div id="capstone-app">
    <nav id="nav-header">
      <NavHeader />
    </nav>
    <router-view id="view" />
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
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');

body {
  background-color: #ddbea9;
}

nav {
  margin-bottom: 15vh;
}

* {
  font-family: "Poppins", sans-serif;
}

#nav-header{
  width: 100vh;
}

/** form styling */

form {
  margin-top: auto;
  background-color: #ffe8d6;
  padding: 1.5rem;
  border-radius: 2%;
  box-shadow: 0 0 2rem #cb997e;
  width: 100%;
  max-width: 25rem;
}

form h1 {
  text-align: center;
  color: black;
  font-size: x-large;
  margin-bottom: 2vh;
}

form label {
  display: block;
  margin-bottom: .5vh;
  color: black;
}

form input {
  width: 90%;
  padding: 10px;
  margin-bottom: 16px;
  border: 1px solid #ddbea9;
  border-radius: 4px;

}

form button {
  width: 95%;
  margin-top: 1.5vh;
  padding: 1.5vh;
  background-color: #6b705c;
  color: #ffe8d6;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

form button:hover {
  background-color: #4c4e40;
}

</style>