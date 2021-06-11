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


        //get by id method
        public IHttpActionResult Get(int id)
        {
            BoardGameService service = new BoardGameService();
            var boardGame = service.GetBoardGameById(id);
            return Ok(boardGame);

        }//end of method get by id

        //edit existing boardGaem in database

        public IHttpActionResult Put(BoardGameEdit boardGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }//end of if model is not valid

            var service = new BoardGameService();
            if (!service.UpdateBoardGame(boardGame))
            {
                return InternalServerError();
            }//end of if unable to update the boardGame

            //if we get here... good!
            return Ok();

        }//end of method put to change existing boardGame

        //finally the delete by id method
        public IHttpActionResult Delete(int id)
        {
            var service = new BoardGameService();

            if (!service.DeleteBoardGame(id))
            {
                return InternalServerError();
            }//end of if not able to delete

            //once again, we get here...
            return Ok();

        }//end of method delete by id

    }//end of class BoardGameController
}
