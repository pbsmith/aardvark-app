using System.Collections.Generic;
using Capstone.Models;


namespace Capstone.DAO.Interface
{
    public interface ICardDao
    {
        Card createCard(Card card, int deckId);
        List<Card> GetCardsByDeckId(int deckId);
        Card UpdateCard(Card updatedCard);
    }
}
