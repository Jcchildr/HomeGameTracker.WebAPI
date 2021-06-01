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
    }
}
