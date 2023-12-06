using Capstone.DAO.Interface;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : Controller
    {
        public ICardDao cardDao;
        public IUserDao userDao;

        public CardController(ICardDao cardDao, IUserDao userDao)
        {
            this.cardDao = cardDao;
            this.userDao = userDao;
        }

        [HttpPost()]
        public ActionResult<Card> CreateDeck(Card card)
        {
            User user = userDao.GetUserByUsername(User.Identity.Name);
            card.userId = user.UserId;
            Card added = cardDao.createCard(card);
            return Created($"/card/{added.cardId}", added);
        }

        [HttpGet("deck/{deckId}")]
        public ActionResult<List<Card>> GetCards(int deckId)
        {
            List<Card> cards = cardDao.GetCardsByDeckId(deckId);
            return Ok(cards);
        }
    }
}
