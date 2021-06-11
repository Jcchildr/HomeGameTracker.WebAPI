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


        //method to get board game by id
        public BoardGameDetail GetBoardGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .BoardGames
                    .Single(e => e.GameId == id);
                return
                    new BoardGameDetail
                    {
                        GameId = entity.GameId,
                        GameName = entity.GameName,
                        PublishYear = entity.PublishYear,
                        AgeRating = entity.AgeRating,
                        MaxNumberOfPlayers = entity.MaxNumberOfPlayers,
                        MinNumberOfPlayers = entity.MinNumberOfPlayers,
                        TeamGame = entity.TeamGame,
                        Genre = entity.Genre,
                        AveragePlayTimeInMin = entity.AveragePlayTimeMin,
                        GameBoardType = entity.GameBoardType,
                        StorageAreaId = entity.StorageArea.StorageAreaId,
                        NameOfStorageArea = entity.StorageArea.NameOfStorageArea,
                    };//end of new BoardGameDetail definition

            }//end of using

        }//end of get board game by id

        //method to edit existing BoardGame in database
        public bool UpdateBoardGame(BoardGameEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.BoardGames
                    .Single(e => e.GameId == model.GameId);

                entity.GameName = model.GameName;
                entity.PublishYear = model.PublishYear;
                entity.AgeRating = model.AgeRating;
                entity.MaxNumberOfPlayers = model.MaxNumberOfPlayers;
                entity.MinNumberOfPlayers = model.MinNumberOfPlayers;
                entity.TeamGame = model.TeamGame;
                entity.Genre = model.Genre;
                entity.AveragePlayTimeMin = model.AveragePlayTimeMin;
                entity.GameBoardType = model.GameBoardType;
                entity.StorageId = model.StorageId;

                return ctx.SaveChanges() == 1;

            }//end of using 

        }//end of method UpdateBoardGame


        //delete a particular BoardGame
        public bool DeleteBoardGame(int gameId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .BoardGames
                    .Single(e => e.GameId == gameId);
                ctx.BoardGames.Remove(entity);

                return ctx.SaveChanges() == 1;

            }//end of using

        }//end of method DeleteBoardGame


    }//end of class BoardGameService
}
