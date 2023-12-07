<template>
    <nav id="nav-bar">
        <ul>
            <li id="logo">
                <router-link v-bind:to="{ name: 'home' }">
                    <img src="../imgs/Aardvark.png" class="logo">
                </router-link>
            </li>
            <li id="title">
                <router-link v-bind:to="{ name: 'home' }">
                    AARDVARK
                </router-link>
            </li>
            <li id="search-bar">
                <input class="search-bar" type="text" placeholder="Search">
            </li>
            <li id="add-button" class="button">
                <router-link v-bind:to="{ name: 'newdeck' }">
                    <img src="../imgs/formImg.png" width="24" height="24">
                </router-link>
            </li>
            <li id="login" class="button">
                <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>

                <router-link v-bind:to="{ name: 'login' }" v-else>
                    Login</router-link>
            </li>
            <li id="register" class="button">
                <router-link v-bind:to="{ name: 'register' }">
                    Sign Up</router-link>
            </li>
        </ul>
    </nav>
</template>

<script>
export default {
}
</script>

<style scoped>

/* grid setup */
#nav-bar {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
   
    background-color: #6b705c;
    font-size: medium;
}

ul {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    flex-wrap: nowrap;
    align-items: center;

    list-style-type: none;
    margin-right: 1rem;
}

li {
    display: inline-block;
}

#title {
    font-size: xx-large;
    font-weight: bold;
    letter-spacing: .1rem;
    text-shadow: .05rem .05rem .2rem rgba(0, 0, 0, 0.7);
    color: #ddbea9;
}

.logo {
    width: 3.5rem;
}

/* other styling */

.button  {
    padding: .5rem;
    border-radius: 0.7vh;
    font-size: large;
    background-color: #4c4e40;
    border: 1px solid #4c4e40;
    box-shadow: 0 0 .5rem #4c4e40;
    color: black;
}

#login, #register{
    padding: .7rem
}

.button:hover {
    background-color: #6b705c;
}

.search-bar {
    border-radius: 0.7vh;
    width: 40vw;
    height: 5vh;
    border: 1px solid #4c4e40;
    background-color: #b7b7a4;
    font-weight: bold;
    box-shadow: 0 0 .5rem #4c4e40;
}

a {
    text-decoration: none;
    color: black;
}
</style>