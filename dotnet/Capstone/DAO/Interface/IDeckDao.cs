using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interface
{
    public interface IDeckDao
    {
        List<Deck> GetDecks();
        Deck CreateDeck(Deck deck);
        Deck GetDeckById(int deckId);

        Deck UpdateDeck(Deck deck);

    }
}
