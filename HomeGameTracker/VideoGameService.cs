using HomeGameTracker.Data;
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
                };
            using (var ctx = new ApplicationDbContext())//Saving the created game to the database 
            {
                ctx.VideoGames.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }//End public CreateVideoGame

        public IEnumerable<VideoGameListItem> GetVideoGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .VideoGames
                        .Select(
                            e =>
                                new VideoGameListItem
                                {
                                    GameId = e.GameId,
                                    GameName = e.GameName,
                                    AgeRating= e.AgeRating,
                                    PublishYear = e.PublishYear,
                                    NumberOfPlayers = e.NumberOfPlayers,
                                    ConsoleType = e.ConsoleType,
                                    Genre = e.Genre,
                                }
                            );
                return query.ToArray();
            }
        }

    }
}
