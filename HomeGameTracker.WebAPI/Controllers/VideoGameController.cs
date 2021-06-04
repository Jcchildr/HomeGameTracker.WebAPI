using HomeGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeGameTracker.WebAPI.Controllers
{
    [Authorize]
    public class VideoGameController : ApiController
    {
        public IHttpActionResult Get()
        {
            VideoGameService videoGameService = CreateVideoGameService();
            var videoGames = videoGameService.GetVideoGames();
            return Ok(videoGames);
        }

        public IHttpActionResult Post(VideoGameCreate videoGame)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVideoGameService();

            if (!service.CreateVideoGame(videoGame))
                return InternalServerError();

            return Ok();

        }
        
        private VideoGameService CreateVideoGameService()
        {
            var VideoGameService = new VideoGameService();
            return VideoGameService;
        }

        public IHttpActionResult Get(int id)
        {
            VideoGameService videoGameService = CreateVideoGameService();
            var videoGame = videoGameService.GetVideoGameById(id);
            return Ok(videoGame);
        }
        public IHttpActionResult Put(VideoGameEdit videoGame)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVideoGameService();

            if (!service.UpdateVideoGame(videoGame))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateVideoGameService();

            if (!service.DeleteVideoGame(id))
                return InternalServerError();

            return Ok();
        }

    }
}
