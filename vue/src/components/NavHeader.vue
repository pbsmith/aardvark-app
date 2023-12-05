<template>
    <div id="nav-bar"> <!-- logo/home, search bar, add plus sign, login, register -->
        <div id="logo" class="navElement">
            <router-link v-bind:to="{ name: 'home' }">
                <h1>Aardvark</h1><!-- todo: replace with image -->
            </router-link>
        </div>
        <div id="search-bar" class="navElement">
            <input class="search-bar" type="text" placeholder="Search">
        </div>
        <div id="add-button" class="navElement">
            <button>
                +
            </button>
        </div>
        <div id="login" class="navElement">
            <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>

            <router-link v-bind:to="{ name: 'login' }" v-else>
                Login</router-link>
        </div>
        <div id="register" class="navElement">
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
/* grid setup */
#nav-bar {
    width: 100vw;
    align-items: center;
    justify-items: center;
    position: fixed;
    left: 0;
    top: 0;
    grid-template-columns: 1fr 2fr 1fr 1fr 1fr;
    display: grid;
    grid-template-areas:
        "logo search-bar add-button login register";

}

#logo {
    grid-area: logo;
    padding-left: 3vw;
    padding-right: 3vw;
}

#search-bar {
    grid-area: search-bar;
}

#add-button {
    grid-area: add-button;
}

#login {
    grid-area: login;
}

#register {
    grid-area: register;
}

/* other styling */

#login,
#register {
    padding: 0.7vh;
    border: 0.05rem solid black;
    border-radius: 1vh;
    font-size: medium;

}

.search-bar{
    border-radius: 1vh;
    width: 30vw;
}

a {
    text-decoration: none;
}

* {
    background-color: #9C89FF;
}
</style>