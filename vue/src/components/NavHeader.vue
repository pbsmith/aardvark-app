<template>
    <div id="nav-bar"> <!-- logo/home, search bar, add plus sign, login, register -->
        <div id="logo" >
            <router-link v-bind:to="{ name: 'home' }">
                <img src="../imgs/Aardvark.jpg" class="logo">
                <h1>Aardvark</h1><!-- todo: replace with image -->
            </router-link>
        </div>
        <div id="search-bar" >
            <input class="search-bar" type="text" placeholder="Search">
        </div>
        <div id="add-button" >
            <button class="addBtn">
                <router-link v-bind:to="{ name: 'newdeck' }">
                    <img src="../imgs/addform.svg" width="24" height="24">
                </router-link>
            </button>
        </div>
        <div id="login" >
            <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>

            <router-link v-bind:to="{ name: 'login' }" v-else>
                Login</router-link>
        </div>
        <div id="register" >
            <router-link v-bind:to="{ name: 'register' }">
                Sign Up</router-link>
        </div>
    </div>
</template>

<script>
export default {
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');

/* grid setup */
div#nav-bar {
    display: grid; 
    grid-template-columns: 1fr 3fr 0.4fr;
    grid-template-areas: 
    "imglogo logo searchbar addformBtn login register";
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    padding: 10px 15px 10px 20px; 
    align-items: center;
    background-color: #fff;
}

h1 {
    grid-area: logo;
    font-size: 14px;
    font-weight: bold;
    color: #3498db; 
    text-transform: uppercase;
    letter-spacing: 4px;
    text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);
    font-family: "Poppins", sans-serif;
    position: relative;
    padding-left: 60px;
}

.logo{
    grid-area: imglogo;
    background-color: #cb997e;
    position: absolute;
    width: 60px;
    height: 50px;
}



/* other styling */

#login {
    grid-area: login;
    padding: 1.3vh;
    border: 0.12rem solid black;
    border-radius: 1vh;
    font-size: large;
    margin-left: 20px;
    background-color: wheat; 
    color: #3498db;
}
#register {
    grid-area: register;
    padding: 1.3vh;
    border: 0.12rem solid black;
    border-radius: 1vh;
    font-size: large;
    margin-left: 20px;
    background-color: wheat; 
    color: #3498db;
}

.search-bar{
    grid-area: searchbar;
    border-radius: 0.7vh;
    width: 40vw;
    height: 5vh;
    border: 1px solid black;
    background-color: wheat;
    font-weight: bold;
    font-size: 17px;
}
.addBtn{
    grid-area: addformBtn;
    margin-left: 150px;
    margin-right: 10px;
    border-radius: 5px;
    padding-top: 2px;
}
a {
    text-decoration: none;
}

</style>