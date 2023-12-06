import axios from 'axios';

export default {

  createCard(card) {
    console.log('Reached createCards in deck service')
    return axios.post('/card', card)
  }
}