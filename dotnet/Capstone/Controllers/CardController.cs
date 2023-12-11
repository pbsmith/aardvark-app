using Capstone.DAO.Interface;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

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

        [HttpGet()]
        public ActionResult<List<Card>> GetAllCards()
        {
            List<Card> cards = cardDao.GetAllCards();
            return Ok(cards);
        }

        [HttpGet("deck/{deckId}")]
        public ActionResult<List<Card>> GetCards(int deckId)
        {
            List<Card> cards = cardDao.GetCardsByDeckId(deckId);
            return Ok(cards);
        }

        [HttpPost()]
        public ActionResult<Card> CreateCard(JsonCard card)
        {
            Card newCard = new Card();
            newCard.cardId = card.cardId;
            newCard.definition = card.definition;
            newCard.term = card.term;
            User user = userDao.GetUserByUsername(User.Identity.Name);
            newCard.userId = user.UserId;
            Card added = cardDao.CreateCard(newCard, card.deckId);
            return Created($"/card/{added.cardId}", added);
        }

        [HttpPut("{cardId}")]
        public ActionResult<Card> Card(Card changedCard)
        {
            Card newCard = cardDao.UpdateCard(changedCard);

            if (newCard == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newCard);
            }

        }

        [HttpDelete("{cardId}/{deckId}")]
        public ActionResult DeleteCard(int cardId, int deckId)
        {
            int numOfDeleted = cardDao.DeleteCardById(cardId, deckId);
            if(numOfDeleted==1)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
