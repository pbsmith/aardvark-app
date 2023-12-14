<template>
  <div class="contact">
    <h1>Contact Us</h1>
    <p>Feel free to get in touch with us using the form below:</p>
    <form @submit.prevent="submitForm">
      <label for="name">Your Name:</label>
      <input type="text" id="name" v-model="formData.name" required>
      <label for="email">Your Email:</label>
      <input type="email" id="email" v-model="formData.email" required>
      <label for="message">Your Message:</label>
      <textarea id="message" v-model="formData.message" rows="4" required></textarea>
      <button class="form-button" type="submit">Submit</button>
    </form>
  </div>
</template>
<script>
export default {
  name: 'Contact',
  data() {
    return {
      formData: {
        name: '',
        email: '',
        message: ''
      }
    };
  },
  methods: {
    submitForm() {
      console.log('Form submitted:', this.formData);
      this.formData = {
        name: '',
        email: '',
        message: ''
      };
    }
  }
};
</script>
<style scoped>
.contact {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

h1 {
  font-size: 2rem;
  color: black;
  text-align: center;
}

p {
  font-size: 1.2rem;
  line-height: 1.6;
  color: black;
  text-align: center;
}

form {
  margin-top: 1.5rem;
  max-width: 80%;
  justify-self: center;
}

label {
  margin-top: .5rem;
}

input,
textarea {
  width: 95%;
  padding: .5rem;
  margin-top:.5rem;
  margin-bottom: 1rem;
}

button {
  padding: .6rem 1rem;
  border-radius: .25rem;
  cursor: pointer;
  margin: 0;
}
</style>