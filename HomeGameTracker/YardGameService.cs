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
                return ctx.SaveChanges() == 1;
            }
        }//end of method CreateYardGame

        //now lets have a get all

        public IEnumerable<YardGameList> GetYardGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .YardGames
                        .Select(
                            e =>
                                new YardGameList
                                {
                                    GameId = e.GameId,
                                    GameName = e.GameName,
                                    NumberOfPlayers = e.NumberOfPlayers,
                                    Genre = e.Genre,
                                    NameOfStorageArea = e.StorageArea.NameOfStorageArea,
                                    SurfaceType = e.SurfaceType,
                                    BallGame = e.BallGame,
                                    AreaOfPlayInFt = e.AreaOfPlayInFt

                                }
                            );
                return query.ToArray();
            }//end of using 
        }//end of method getYardGames

        //need a get by id

        //need an edit


        //need a delete





    }//end of YardGameService
}
