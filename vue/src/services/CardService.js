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
    return axios.put(`/card/${card.cardId}`, card)
  },

  getAllCards() {
    return axios.get('/card')
  },

  deleteCardFromDeck(card) {
    console.log("reached delete card from deck in card service", card)
    return axios.delete(`/card/${card.cardId}/${card.deckId}`)
  }
}