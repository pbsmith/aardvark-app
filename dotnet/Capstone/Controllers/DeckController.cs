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

        [HttpPost()]
        public ActionResult<Deck> CreateDeck(Deck deck)
        {
            User user = userDao.GetUserByUsername(User.Identity.Name);
            deck.userId = user.UserId;           
            Deck added = deckDao.createDeck(deck);
            return Created($"/deck/{added.deckId}", added);
        }
    }
}
