using HomeGameTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class VideoGameList
    {
        //returning information on the game when it's part of a list
        [Display(Name = "Game Id")]
        public int GameId { get; set; }
        [Display(Name="Title")]
        public string GameName { get; set; }
        [Display(Name = "Publish Year")]
        public int PublishYear { get; set; }
        [Display(Name = "Age Range")]
        public int AgeRating { get; set; }
        [Display(Name = "Number Of Players")]
        public int MaxNumberOfPlayers { get; set; }
        [Display(Name = "Name of Console")]
        public string ConsoleType { get; set; }
        [Display(Name = "Genre of game")]
        public string Genre { get; set; }
        [Display(Name = "Storage Area")]
        public string NameOfStorageArea { get; set; }

    }//end of GameListItem
}
