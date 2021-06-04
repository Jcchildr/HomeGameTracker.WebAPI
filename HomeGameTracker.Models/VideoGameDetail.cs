using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class VideoGameDetail
    {
        //returning information on the game when it's part of a list
        [Display(Name = "Game Id")]
        public int GameId { get; set; }
        [Display(Name = "Title")]
        public string GameName { get; set; }
        [Display(Name = "Publish Year")]
        public int PublishYear { get; set; }
        [Display(Name = "Age Range")]
        public int AgeRating { get; set; }
        [Display(Name = "Number Of Players")]
        public int NumberOfPlayers { get; set; }
        [Display(Name = "Team Game?")]
        public bool TeamGame { get; set; }
        [Display(Name = "Genre of game")]
        public string Genre { get; set; }
        [Display(Name = "Name of Console")]
        public string ConsoleType { get; set; }
        [Display(Name = "Online Gameplay?")]
        public bool OnlineGamePlay { get; set; }
        [Display(Name = "Storage Area")]
        public string NameOfStorageArea { get; set; }
    }
}
