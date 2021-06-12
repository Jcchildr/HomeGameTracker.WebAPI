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
                    MaxNumberOfPlayers = model.MaxNumberOfPlayers,
                    MinNumberOfPlayers = model.MinNumberOfPlayers,
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
                                    MaxNumberOfPlayers = e.MaxNumberOfPlayers,
                                    MinNumberOfPlayers = e.MinNumberOfPlayers,
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

        //method to get yard game by id
        public YardGameDetail GetYardGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .YardGames
                    .Single(e => e.GameId == id);
                return
                    new YardGameDetail
                    {
                        GameId = entity.GameId,
                        GameName = entity.GameName,
                        PublishYear = entity.PublishYear,
                        AgeRating = entity.AgeRating,
                        MaxNumberOfPlayers = entity.MaxNumberOfPlayers,
                        MinNumberOfPlayers = entity.MinNumberOfPlayers,
                        TeamGame = entity.TeamGame,
                        Genre = entity.Genre,
                        SurfaceType = entity.SurfaceType,
                        BallGame = entity.BallGame,
                        AreaOfPlayInFt = entity.AreaOfPlayInFt,
                        StorageAreaId = entity.StorageArea.StorageAreaId,
                        NameOfStorageArea = entity.StorageArea.NameOfStorageArea,
                    };//end of new YardGameDetail definition

            }//end of using

        }//end of get yard game by id

        //method to edit existing YardGame in database
        public bool UpdateYardGame(YardGameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.YardGames
                    .Single(e => e.GameId == model.GameId);

                entity.GameName = model.GameName;
                entity.PublishYear = model.PublishYear;
                entity.AgeRating = model.AgeRating;
                entity.MaxNumberOfPlayers = model.MaxNumberOfPlayers;
                entity.MinNumberOfPlayers = model.MinNumberOfPlayers;
                entity.TeamGame = model.TeamGame;
                entity.Genre = model.Genre;
                entity.SurfaceType = model.SurfaceType;
                entity.BallGame = model.BallGame;
                entity.AreaOfPlayInFt = model.AreaOfPlayInFt;
                entity.StorageId = model.StorageId;

                return ctx.SaveChanges() == 1;

            }//end of using 

        }//end of method UpdateYardGame


        //delete a particular YardGame
        public bool DeleteYardGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .YardGames
                    .Single(e => e.GameId == gameId);
                ctx.YardGames.Remove(entity);

                return ctx.SaveChanges() == 1;

            }//end of using

        }//end of method DeleteYardGame


    }//end of YardGameService
}
