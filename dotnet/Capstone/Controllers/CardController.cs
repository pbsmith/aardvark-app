using Capstone.DAO.Interface;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
