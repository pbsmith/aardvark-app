<template>
    <nav id="nav-bar-display">
        <ul id="nav-bar-ul">
            <li id="logo">
                <router-link v-bind:to="{ name: 'home' }">
                    <img id="logo-img" src="../imgs/Aardvark.png" class="logo">
                </router-link>
            </li>
            <li id="title">
                <router-link v-bind:to="{ name: 'home' }">
                    AARDVARK
                </router-link>
            </li>
            <li id="search-bar">
                <input id="search-bar-input" type="text" placeholder="Search">
            </li>
            <li id="spacer">

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
        </ul>
    </nav>
</template>

<script>
export default {
}
</script>

<style scoped>
/** General Styling */

#title {
    font-size: xx-large;
    font-weight: bold;
    letter-spacing: .1rem;
    text-shadow: .05rem .05rem .2rem rgba(0, 0, 0, 0.7);
    color: #ddbea9;
}

#logo-img {
    width: 3.5rem;
}

/* Button Styling */

.button {
    padding: .5rem;
    border-radius: 0.5rem;
    font-size: large;
    background-color: #4c4e40;
    border: 1px solid #4c4e40;
    box-shadow: 0 0 .5rem #4c4e40;
    color: black;
}

#login {
    padding: .7rem;
}

.button:hover {
    background-color: #6b705c;
}

#search-bar-input {
    border-radius: 0.5rem;

    height: 2.5rem;
    border: 1px solid #4c4e40;
    background-color: #b7b7a4;
    font-weight: bold;
    box-shadow: 0 0 .5rem #4c4e40;
}

a {
    text-decoration: none;
    color: black;
}

/** Nav Bar Styling */

#nav-bar-display {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;

    background-color: #6b705c;
    font-size: medium;
}

#nav-bar-ul {
    list-style-type: none;
    margin-right: 1rem;
}

/** Conditional Displays */

@media only screen and (max-width: 37.5rem) {
    #nav-bar-ul {
        display: grid;
        grid-template-columns: .25fr 1fr .25fr 1fr;
        grid-template-areas:
            "logo title title ..."
            "search-bar search-bar add-button login";
        gap: .25rem;
        margin: .5rem;
    }

    #logo-img {
        grid-area: logo;
    }

    #title {
        grid-area: title;
    }

    #search-bar {
        grid-area: search-bar;
        margin-bottom: .2rem;
    }

    #add-button {
        grid-area: add-button;
    }

    #login {
        grid-area: login;
    }

    .button {
        border-radius: 0.5rem;
        font-size: small;
        background-color: #4c4e40;
        border: 1px solid #4c4e40;
        box-shadow: 0 0 .5rem #4c4e40;
        color: black;
        font-size: small;
        justify-self: center;
    }

}

@media only screen and (max-width:62rem) and (min-width:37.6rem) {
    #nav-bar-ul {
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;
        align-items: center;
        gap: 2rem;
    }

    #search-bar-input {
        width: 20vw;
    }

    #spacer {
        width:0vw;
    }
}

@media only screen and (min-width: 62rem) {

    #nav-bar-ul {
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;
        align-items: center;
        gap: 3rem;
    }

    #search-bar-input {
        width: 30vw;
    }

    #spacer {
        width:1vw;
    }
}
</style>