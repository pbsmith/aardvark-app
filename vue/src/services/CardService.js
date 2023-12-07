import axios from 'axios';

export default {

  createCard(card) {
    console.log('Reached createCards in deck service')
    return axios.post('/card', card)
  },

  getCardsByDeckId(deckId){
    return axios.get(`/card/deck/${deckId}`)
  },

  updateCard(card) {
    return axios.put('/card', card)
  }
}