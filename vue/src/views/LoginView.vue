<template>
  <div class="container">
    <div id="login" class="login-form">
      <form v-on:submit.prevent="login" class="form">
        <h1>Please Sign In</h1>
        <div role="alert" v-if="invalidCredentials">
          Invalid username and password!
        </div>
        <div role="alert" v-if="this.$route.query.registration">
          Thank you for registering, please sign in.
        </div>
        <div class="form-input-group">
          <label for="username">Username</label>
          <input type="text" id="username" v-model="user.username" required autofocus />
        </div>
        <div class="form-input-group">
          <label for="password">Password</label>
          <input type="password" id="password" v-model="user.password" required />
        </div>
        <button type="submit">Sign in</button>
        <p>
          <router-link v-bind:to="{ name: 'register' }">Need an account? Sign up.</router-link>
        </p>
      </form>
    </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;600&display=swap');
.login-form {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  width: 120vw;
}
form {
  background-color: #fff;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.3);
  max-width: 400px;
  width: 100%;
  font-family: "Poppins", sans-serif;
}
form h1 {
  text-align: center;
  color: #333;
  font-size: 24px;
  margin-bottom: 20px;
}
form label {
  display: block;
  margin-bottom: 8px;
  color: #555;
}

form input {
  width: 90%;
  padding: 10px;
  margin-bottom: 16px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
form button {
  width: 95%;
  margin-top: 15px;
  padding: 15px;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}
form button:hover {
  background-color: #0056b3;
}

</style>