using HomeGameTracker.Data;
using HomeGameTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeGameTracker
{
    public class BoardGameService
    {

        //going to put our crud in here, to interact with our database using models

        //create
        public bool CreateBoardGame(BoardGameCreate model)
        {
            var entity =
                new BoardGame()//create an instance of
                {
                    GameName = model.GameName,
                    AgeRating = model.AgeRating,
                    MinNumberOfPlayers = model.MinNumberOfPlayers,
                    MaxNumberOfPlayers = model.MaxNumberOfPlayers,
                    PublishYear = model.PublishYear,
                    TeamGame = model.TeamGame,
                    Genre = model.Genre,
                    AveragePlayTimeMin = model.AveragePlayTimeMin,
                    GameBoardType = model.GameBoardType,
                    StorageId = model.StorageId,

                };//multi line object creation for ease of reading
            using (var ctx = new ApplicationDbContext())//create a database context to save the game to
            {
                ctx.BoardGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }//end of using


        }//end of method CreateBoardGame


        //get all method to return a list
        public IEnumerable<BoardGameList> GetBoardGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                  ctx
                  .BoardGames
                  .Select(
                      e =>
                      new BoardGameList
                      {
                          GameId = e.GameId,
                          GameName = e.GameName,
                          MaxNumberOfPlayers = e.MaxNumberOfPlayers,
                          MinNumberOfPlayers = e.MaxNumberOfPlayers,
                          Genre = e.Genre,
                          NameOfStorageArea = e.StorageArea.NameOfStorageArea,
                          AveragePlayTimeMin = e.AveragePlayTimeMin,
                          GameBoardType = e.GameBoardType,
                      }//end of new GameBoardList

                      );//end of select
                return query.ToArray();
            }//end of using

        }//end of method GetBoardGames


        //need a get by id


        //need an edit


        //need a delete





    }//end of class BoardGameService
}
