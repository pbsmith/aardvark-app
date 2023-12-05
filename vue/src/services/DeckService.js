import axios from 'axios';

export default {

  getDecks() {
    console.log('Reached getdecks in deck service')
    return axios.get('/deck');
  },

  createDeck(deck) {
    console.log('Reached createDeck in deck service')
    return axios.post('/deck', deck)
  },

}
