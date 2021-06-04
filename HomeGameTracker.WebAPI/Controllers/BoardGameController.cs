using HomeGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeGameTracker.WebAPI.Controllers
{
    public class BoardGameController : ApiController
    {
        //begin with an Authorize
        [Authorize]

        //build out our crud
        //start with create
        public IHttpActionResult Post(BoardGameCreate boardGame)
        {
            //start by checking validity of the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }//end of if model is not valid

            //create a service instance
            var service = new BoardGameService();

            //now that the service exists, return an error if we can't create the boardGame

            if (!service.CreateBoardGame(boardGame))
            {
                return InternalServerError();
            }//end of if doesnt save
            //to get here it had to work soo
            return Ok();

        }//end of method Post

        //now we need a get method to get all
        public IHttpActionResult Get()
        {


            BoardGameService service = new BoardGameService();
            var boardGames = service.GetBoardGames();
            return Ok(boardGames);


        }//end of method get to get all


    }//end of class BoardGameController
}
