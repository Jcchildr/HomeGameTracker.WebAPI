﻿using HomeGameTracker.Data;
using HomeGameTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker
{
    public class VideoGameService
    {

        public bool CreateVideoGame(VideoGameCreate model)
        {
            var entity =
                new VideoGame()//Creating an instance of a new VideoGame
                {
                    GameName = model.GameName,
                    AgeRating = model.AgeRating,
                    NumberOfPlayers = model.NumberOfPlayers,
                    PublishYear = model.PublishYear,
                    TeamGame = model.TeamGame,
                    ConsoleType = model.ConsoleType,
                    OnlineGamePlay = model.OnlineGamePlay,
                    Genre = model.Genre,
                    StorageId = model.StorageId,
                };
            using (var ctx = new ApplicationDbContext())//Saving the created game to the database 
            {
                //ctx.Games.Add(entity);
                ctx.VideoGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }//End public CreateVideoGame

        public IEnumerable<VideoGameList> GetVideoGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .VideoGames
                        .Select(
                            e =>
                                new VideoGameList
                                {
                                    GameId = e.GameId,
                                    GameName = e.GameName,
                                    AgeRating = e.AgeRating,
                                    NumberOfPlayers = e.NumberOfPlayers,
                                    PublishYear = e.PublishYear,
                                    Genre = e.Genre,
                                    ConsoleType = e.ConsoleType,
                                    NameOfStorageArea = e.StorageArea.NameOfStorageArea,

                                }
                            );
                return query.ToArray();
            }
        }// End GetVideoGames

        public VideoGameDetail GetVideoGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .VideoGames
                        .Single(e => e.GameId == id);
                return
                    new VideoGameDetail
                    {
                        GameId = entity.GameId,
                        GameName = entity.GameName,
                        PublishYear = entity.PublishYear,
                        AgeRating = entity.AgeRating,
                        NumberOfPlayers = entity.NumberOfPlayers,
                        TeamGame = entity.TeamGame,
                        Genre = entity.Genre,
                        ConsoleType = entity.ConsoleType,
                        OnlineGamePlay = entity.OnlineGamePlay,
                        NameOfStorageArea = entity.StorageArea.NameOfStorageArea,
                    };
            }
        }// End GetVideoGames by Id

        public bool UpdateVideoGame(VideoGameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .VideoGames
                        .Single(e => e.GameId == model.GameId);

                entity.GameName = model.GameName;
                entity.PublishYear = model.PublishYear;
                entity.AgeRating = model.AgeRating;
                entity.NumberOfPlayers = model.NumberOfPlayers;
                entity.TeamGame = model.TeamGame;
                entity.Genre = model.Genre;
                entity.ConsoleType = model.ConsoleType;
                entity.OnlineGamePlay = model.OnlineGamePlay;
                entity.StorageId = model.StorageId;

                return ctx.SaveChanges() == 1;
            }
        }// End UpdateVideoGame
        public bool DeleteVideoGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .VideoGames
                        .Single(e => e.GameId == gameId);

                ctx.VideoGames.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }//End of DeleteVideoGame
    }//End of VideoGameService
}
