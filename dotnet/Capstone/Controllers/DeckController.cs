using Capstone.DAO.Interface;
using Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        public IDeckDao deckDao;
        public IUserDao userDao;

        public DeckController(IDeckDao deckDao, IUserDao userDao)
        {
            this.deckDao = deckDao;
            this.userDao = userDao;
        }

        [HttpGet()]
        public ActionResult<IList<Deck>> GetDecks()
        {
            return Ok(deckDao.GetDecks());
        }

        [HttpGet("{deckId}")]
        public ActionResult<Deck> GetDeckById(int deckId)
        {
            Deck deck = deckDao.GetDeckById(deckId);
            if (deck != null)
            {
                return Ok(deck);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost()]
        public ActionResult<Deck> CreateDeck(Deck deck)
        {
            User user = userDao.GetUserByUsername(User.Identity.Name);
            deck.userId = user.UserId;
            Deck added = deckDao.CreateDeck(deck);
            return Created($"/deck/{added.deckId}", added);
        }

        [HttpPut("{deckId}")]
        public ActionResult<Deck> UpdateDeck(Deck deck)
        {
            Deck newDeck = deckDao.UpdateDeck(deck);

            if (newDeck == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(newDeck);
            }
        }
    }
}
