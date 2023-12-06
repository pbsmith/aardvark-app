<template>
    <div id="nav-bar"> <!-- logo/home, search bar, add plus sign, login, register -->
        <div id="logo" >
            <router-link v-bind:to="{ name: 'home' }">
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
import '@fortawesome/fontawesome-free/css/all.css';
export default {
}
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');

/* grid setup */
div#nav-bar {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    padding: 1px 15px 1px 20px;
    display: flex;  
    align-items: center;
    transition: 0.3s ease-out;
    background-color: #cb997e;
}

#logo {
    grid-area: logo;
    font-size: 14px;
    font-weight: bold;
    color: #3498db; 
    text-transform: uppercase;
    letter-spacing: 4px;
    text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.7);
    font-family: "Poppins", sans-serif;
    margin-right: 50px;
}


/* other styling */

#login,
#register {
    padding: 1.3vh;
    border: 0.05rem solid black;
    border-radius: 1vh;
    font-size: large;
    margin-left: 20px;
    background-color: #cb997e;

}

.search-bar{
    border-radius: 1vh;
    width: 30vw;
    height: 4.8vh;
    border: 1px solid black;
    padding-left: 10px;
    margin-right: 230px;
}
.addBtn{
    margin-left: 200px;
    margin-right: 10px;
    border-radius: 5px;
    padding-top: 2px;
}
a {
    text-decoration: none;
}

</style>