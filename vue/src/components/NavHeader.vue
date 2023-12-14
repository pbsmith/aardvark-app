<template>
    <nav id="nav-bar-display">
        <ul id="nav-bar-ul">
            <div id="nav-bar-left">
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
            </div>
            <div id="nav-bar-right">
                <li id="about" class="button"><router-link class="link" :to="{ name: 'about' }">About</router-link></li>
                <li id="contact" class="button"><router-link class="link" :to="{ name: 'contact' }">Contact</router-link></li>

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
            </div>
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
    text-shadow: .05rem .05rem 1rem #2D1800;

}

#logo-img {
    width: 3.5rem;
}

/* Button Styling */

.button {
    padding: .5rem;
    border-radius: 0.5rem;
    font-size: large;
    background-color: #1C0B00;
    border: 1px solid #1C0B00;
    box-shadow: 0 0 .5rem #2D1800;
}

#login {
    padding: .7rem;
}

.button:hover {
    background-color: #2D1800;
}

#search-bar-input {
    border-radius: 0.5rem;

    height: 2.5rem;
    border: 1px solid #2D1800;
    background-color: #E5AC65;
    font-weight: bold;
    box-shadow: 0 0 .5rem #2D1800;
}

a {
    text-decoration: none;
    color: #E5AC65;
}

/** Nav Bar Styling */

#nav-bar-display {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;

    background-color: #262a13;
    font-size: medium;
}

#nav-bar-ul {
    list-style-type: none;
    margin-right: 1rem;
}

/** Conditional Displays */

/** 19.9rem = 320px */
@media only screen and (max-width: 27.9rem) {
    #nav-bar-ul {
        display: flex;
        flex-direction: column;
        gap: .25rem;
    }

    #nav-bar-left {
        display: grid;
        grid-template-columns: 1fr 3.5fr;
        grid-template-areas:
            "logo title"
            "logo search-bar";
    }

    #nav-bar-right {
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
        gap: 1rem;
    }

    #logo {
        grid-area: logo;
        align-self: center;
        max-width: 3rem;
    }

    #logo-img {
        width: 100%;
    }

    #title {
        grid-area: title;
        font-size: x-large;
        align-self: center;
    }

    #search-bar {
        grid-area: search-bar;
        margin-bottom: .2rem;
        max-width: 95%;
    }

    #search-bar-input {
        width: 100%;
    }

    #add-button {
        grid-area: add-button;
    }

    #login {
        grid-area: login;
    }

    .button {
        font-size: small;
    }

}

/**  41.9rem = 670px, 27.9rem = 320px */
@media only screen and (max-width: 41.9rem) and (min-width:28rem) {
    #nav-bar-ul {
        display: grid;
        grid-template-columns: 1fr .25fr;
        grid-template-areas:
            "nav-bar-left nav-bar-right";
        gap: .25rem;
        margin: .5rem;
        padding: .5rem;
    }

    #nav-bar-left {
        grid-area: nav-bar-left;
        display: grid;
        grid-template-columns: .5fr 1fr 1fr;
        grid-template-areas:
            "logo title title"
            "logo search-bar search-bar";
        grid-column-gap: 1.5rem;
    }

    #logo {
        grid-area: logo;
        align-self: center;
    }

    #logo-img {
        width: 100%;
    }

    #title {
        grid-area: title;
    }

    #search-bar {
        grid-area: search-bar;
        margin-bottom: .2rem;
    }

    #search-bar-input {
        width: 80%;
    }

    #nav-bar-right {
        grid-area: nav-bar-right;
        display: grid;
        grid-template-columns: 1fr 1fr;
        grid-template-areas: 
            "about contact"
            "add-button login";
        gap: .25rem;
        justify-content: center;
        align-content: center;
    }

    #add-button {
        grid-area: add-button;
        width: fit-content;
        height: fit-content;
        align-self: center;
    }

    #login {
        grid-area: login;
        width: fit-content;
        height: fit-content;
        align-self: center;
    }

    #about {
        grid-area: about;
        width: fit-content;
    }

    #contact {
        grid-area: contact;
        width: fit-content;
    }

    .button {
        font-size: small;
    }

}

/** 60rem = 960px,  42rem = 672px */
@media only screen and (max-width:59.9rem) and (min-width:42rem) {
    #nav-bar-ul {
        display: grid;
        grid-template-columns: 1fr .25fr;
        grid-template-areas:
            "nav-bar-left nav-bar-right";
        gap: .25rem;
        margin: .5rem;
        padding: .5rem;
    }

    #nav-bar-left {
        grid-area: nav-bar-left;
        display: grid;
        grid-template-columns: .5fr 1fr 1fr;
        grid-template-areas:
            "logo title title"
            "logo search-bar search-bar";
        grid-column-gap: 1.5rem;
    }

    #nav-bar-right {
        grid-area: nav-bar-right;
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
        gap: 1rem;
    }

    #logo {
        grid-area: logo;
        align-self: center;
        justify-self: center;
    }

    #logo-img {
        width: 100%;
        max-width: 4rem;
    }

    #title {
        grid-area: title;
    }

    #search-bar {
        grid-area: search-bar;
        margin-bottom: .2rem;
    }

    #search-bar-input {
        width: 90%;
    }

    #add-button {
        grid-area: add-button;
    }

    #login {
        grid-area: login;
    }

    .button {
        font-size: small;
    }
}

/** 60rem = 960px */
@media only screen and (min-width: 60rem) {

    #nav-bar-ul {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        flex-wrap: nowrap;
    }

    #nav-bar-left {
        display: flex;
        flex-direction: row;
        flex-wrap: nowrap;
        align-items: center;
        gap: 1rem;
    }

    #search-bar-input {
        width: 100%;
    }

    #search-bar {
        min-width: 30vw;
    }

    #nav-bar-right {
        display: flex;
        flex-direction: row;
        align-items: center;
        justify-content: flex-end;
        gap: 1rem;
    }

}
</style>