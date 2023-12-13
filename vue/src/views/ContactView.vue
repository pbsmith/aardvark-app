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
        <button type="submit">Submit</button>
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
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
  }
  h1 {
    font-size: 2rem;
    color: #333;
    text-align: center;
  }
  p {
    font-size: 1.2rem;
    line-height: 1.6;
    color: #0A0909;
    text-align: center;
  }
  form {
    margin-top: 20px;
    max-width: 100rem;
  }
  label {
    display: block;
    margin-top: 10px;
  }
  input,
  textarea {
    width: 100%;
    padding: 8px;
    margin-top: 5px;
    margin-bottom: 15px;
  }
  button {
    background-color: #4CAF50;
    color: white;
    padding: 10px 15px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }
  </style>