using System.Collections.Generic;
using Capstone.Models;


namespace Capstone.DAO.Interface
{
    public interface ICardDao
    {
        Card createCard(Card card);
    }
}
