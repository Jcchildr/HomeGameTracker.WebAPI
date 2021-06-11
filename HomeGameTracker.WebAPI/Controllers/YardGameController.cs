using HomeGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HomeGameTracker.WebAPI.Controllers
{
    public class YardGameController : ApiController
    {
        //begin with an Authorize
        [Authorize]

        //build out our crud
        //start with create
        public IHttpActionResult Post(YardGameCreate yardGame)
        {
            //start by checking validity of the model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }//end of if model is not valid

            //create a service instance
            var service = new YardGameService();

            //now that the service exists, return an error if we can't create the yardGame

            if (!service.CreateYardGame(yardGame))
            {
                return InternalServerError();
            }//end of if doesnt save
            //to get here it had to work soo
            return Ok();

        }//end of method Post

        //now we need a get method to get all
        public IHttpActionResult Get()
        {

            YardGameService service = new YardGameService();
            var yardGames = service.GetYardGames();
            return Ok(yardGames);

        }//end of method get to get all

        //now for the get by id method
        public IHttpActionResult Get(int id)
        {
            var service = new YardGameService();
            var yardGame = service.GetYardGameById(id);
            return Ok(yardGame);

        }//end of method get by id

        //edit method to update existing yard game
        public IHttpActionResult Put(YardGameEdit yardGame)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }//end of is model not valid

            var service = new YardGameService();

            if (!service.UpdateYardGame(yardGame))
            {
                return InternalServerError();
            }//end of if not able to update

            //get here and ...
            return Ok();

        }//end of method put to change existing 

        //delete method
        public IHttpActionResult Delete(int id)
        {
            var service = new YardGameService();

            if(!service.DeleteYardGame(id))
            {
                return InternalServerError();
            }//end of if not able to delete

            //made it here with no problems
            return Ok();

        }//end of delete method by id



    }//end of class YardGameController
}
