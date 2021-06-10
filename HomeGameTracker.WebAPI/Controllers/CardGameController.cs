using HomeGameTracker.Models;
using System.Web.Http;

namespace HomeGameTracker.WebAPI.Controllers
{
    [Authorize]

    public class CardGameController : ApiController
    {
        private CardGameService CreateCardGameService()
        {
            var cardGameService = new CardGameService();
            return cardGameService;
        }
        public IHttpActionResult Get()
        {
            CardGameService cardGameService = CreateCardGameService();
            var cardGames = cardGameService.GetCardGame();
            return Ok(cardGames);
        }
        public IHttpActionResult Post(CardGameCreate cardGame)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCardGameService();

            if (!service.CreateCardGame(cardGame))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CardGameService cardGameService = CreateCardGameService();
            var cardGame = cardGameService.GetCardGameById(id);
            return Ok(cardGame);
        }
        public IHttpActionResult Get(CardGameDetail model)
        {
            CardGameService cardGameService = CreateCardGameService();
            var cardGame = cardGameService.GetGameIfGambling(model);
            return Ok(cardGame);


        }

        public IHttpActionResult Put(CardGameEdit cardGame)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCardGameService();

            if (!service.UpdateCardGame(cardGame))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCardGameService();

            if (!service.DeleteCardGame(id))
                return InternalServerError();

            return Ok();
        }
    }
}
