using HomeGameTracker.Data;
using HomeGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker
{
    public class YardGameService
    {
        //start with our create method

        public bool CreateYardGame(YardGameCreate model)
        {
            var entity =
                new YardGame()//Creating an instance of a new YardGame
                {
                    GameName = model.GameName,
                    AgeRating = model.AgeRating,
                    NumberOfPlayers = model.NumberOfPlayers,
                    PublishYear = model.PublishYear,
                    TeamGame = model.TeamGame,
                    SurfaceType = model.SurfaceType,
                    BallGame = model.BallGame,
                    AreaOfPlayInFt = model.AreaOfPlayInFt,
                    Genre = model.Genre,
                    StorageId = model.StorageId,
                };
            using (var ctx = new ApplicationDbContext())//create DbContext to add an entity
            {
                ctx.YardGames.Add(entity);
                //ctx.Games.Add(entity);//trying to not do this
                return ctx.SaveChanges() == 1;
            }
        }//End public CreateVideoGame

        //now lets have a get all









    }//end of YardGameService
}
