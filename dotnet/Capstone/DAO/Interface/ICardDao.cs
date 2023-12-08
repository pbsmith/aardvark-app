using System.Collections.Generic;
using Capstone.Models;


namespace Capstone.DAO.Interface
{
    public interface ICardDao
    {
        List<Card> GetAllCards();
        Card CreateCard(Card card, int deckId);
        List<Card> GetCardsByDeckId(int deckId);
        Card UpdateCard(Card updatedCard);
        int DeleteCardById(int cardId);

    }
}
