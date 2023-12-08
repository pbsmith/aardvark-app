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

/** Universal Styling */

* {
  font-family: "Poppins", sans-serif;
}

body {
  background-color: #ddbea9;
}

a {
  text-decoration: none;
  color: black;
}

/** Nav */

#nav-header {
  margin-bottom: 7rem;
  width: 100vh;
}

@media only screen and (max-width:62rem) and (min-width:37.6rem) {
  #nav-header {
    margin-bottom: 9rem;
  }
}

@media only screen and (max-width: 37.5rem){
  #nav-header {
    margin-bottom: 12rem;
  }
}
/** Views under 400px are not supported*/

/** Form Styling */

form {
  margin-top: auto;
  background-color: #ffe8d6;
  padding: 1.5rem;
  border-radius: .5rem;
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
  padding: .5rem;
  margin-bottom: 1rem;
  border: .05rem solid #ddbea9;
  border-radius: .5rem;

}

#save {
  width: 95%;

  padding: 1rem;

  background-color: #6b705c;
  color: #ffe8d6;
  border: none;
  border-radius: .5rem;
}

#save:hover {
  cursor: pointer;
  transition: background-color 0.3s ease;
  background-color: #4c4e40;
}

/** Card Form Only */

.card-form,
.deck-form, .login-form{
  margin: 1rem 0rem 2rem 5%;
}

/** Deck Detail Mini Nav Button Styling */

.form-button {
  margin: 1rem 1rem .5rem 1rem;
  padding: .5rem 1rem .5rem 1rem;
  background-color: #b7b7a4;

  border-radius: .5rem;
  border: .05rem solid #b7b7a4;
  box-shadow: 0 0 .25rem #4c4e40;
}

.form-button:hover {
  transition: background-color 0.3s ease;
  cursor: pointer;

  background-color: #6b705c;
  border: .05rem solid #4c4e40;
  box-shadow: 0 0 .25rem #4c4e40;
}

/** Deck Details Styling */

.deckcontainer,
.cardcontainer {
  margin: auto;
  margin-top: .5rem;
  padding: 0rem 1.2rem 1.2rem 1.2rem;
  background-color: #ffe8d6;
  width: 90%;

  border: .05rem solid #cb997e;
  border-radius: 1rem;
  box-shadow: 0 0 1rem #cb997e;
}

.deckdetail-button-container {
  display: flex;
  flex-direction: row;
  flex-wrap: nowrap;
  justify-content: flex-start;
  margin: 0.5rem 5% 1rem 5%;
}
</style>