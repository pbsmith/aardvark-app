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
        public IDeckDao dao;

        public DeckController(IDeckDao deckDao)
        {
            dao = deckDao;
        }

        [HttpGet()]
        public ActionResult<IList<Deck>> GetDecks()
        {
            return Ok(dao.GetDecks());
        }
    }
}
