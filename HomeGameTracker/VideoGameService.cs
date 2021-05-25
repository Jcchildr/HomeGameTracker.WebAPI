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
        public bool CreateNote(VideoGameCreate model)
        {
            var entity =
                new VideoGame()//Creating an instance of a new Game
                {
                    GameName = model.GameName,
                    AgeRating = model.AgeRating,
                    NumberOfPlayers = model.NumberOfPlayers,
                    PublishDate = model.PublishDate,
                    TeamGame = model.TeamGame,
                };
            using (var ctx = new ApplicationDbContext())//Saving the created game to the database 
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
