<template>
    <div class="about">
      <h1>About Aardvark Flashcards</h1>
      <p>
        Welcome to Aardvark Flashcards, an innovative learning tool crafted with dedication by a team of passionate developers — myself, Sara, and Pendle. This endeavor emerged during our capstone project, where our shared enthusiasm for education and technology converged to birth a unique and captivating flashcard application, centered around the extraordinary Aardvark.
      </p>
      <div class="key-features">
        <h2>Key Features</h2>
        <ul>
          <li>
            <strong>User-Friendly Interface:</strong>
            Aardvark Flashcards prides itself on a clean and user-friendly interface, ensuring a seamless learning experience for users of all ages.
          </li>
          <li>
            <strong>Customizable Decks:</strong>
            Tailor your learning experience by creating custom decks based on your specific needs and preferences. Personalize your study sessions to focus on what matters most to you.
          </li>
          <li>
            <strong>Rich Multimedia Support:</strong>
            Immerse yourself in learning with multimedia support, including images, audio, and video. Aardvark Flashcards goes beyond text-based flashcards to provide a comprehensive and engaging learning environment.
          </li>
          <li>
            <strong>Smart Progress Tracking:</strong>
            Stay motivated with our intelligent progress tracking feature. Monitor your performance, track achievements, and celebrate learning milestones with ease.
          </li>
        </ul>
      </div>
      <div class="our-journey">
        <h2>Our Journey as a Team</h2>
        <p>
          The evolution of Aardvark Flashcards was a collaborative journey fueled by our shared commitment to creating a valuable educational tool. From exhilarating brainstorming sessions to late-night coding marathons, each step reflects our unwavering dedication to making learning accessible and enjoyable.
        </p>
      </div>
      <div class="meet-the-team">
        <h2>Meet the Team</h2>
        <ul>
          <li>
            <strong>Abdirahman</strong>
          </li>
          <li>
            <strong>Sara</strong>
          </li>
          <li>
            <strong>Pendle</strong>
          </li>
        </ul>
      </div>
      <div class="join-us">
        <h2>Join Us on the Learning Adventure</h2>
        <p>
          Embark on a learning adventure with Aardvark Flashcards! Whether you're a student, teacher, or lifelong learner, our app is meticulously designed to inspire curiosity and foster a genuine love for learning. Download Aardvark Flashcards today and unlock the joy of interactive and effective studying.
        </p>
      </div>
    </div>
  </template>
  <script>
  export default {
    name: 'About',
  };
  </script>
  <style scoped>
  .about {
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
  }
  h1 {
    font-size: 2.5rem;
    color: #333;
    margin-bottom: 20px;
  }
  p {
    font-size: 1.2rem;
    line-height: 1.6;
    color: #1A1818;
    margin-bottom: 20px;
  }
  .key-features,
  .our-journey,
  .meet-the-team,
  .join-us {
    margin-bottom: 40px;
  }
  h2 {
    font-size: 2rem;
    color: #121111;
    margin-bottom: 15px;
  }
  ul {
    list-style: none;
    padding: 0;
  }
  li {
    margin-bottom: 15px;
  }
  </style>