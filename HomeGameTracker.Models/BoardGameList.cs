using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class BoardGameList
    {

        //the attributes coming from game

        [Display(Name = "Game Id")]
        public int GameId { get; set; }
        [Display(Name = "Title")]
        public string GameName { get; set; }
        [Display(Name = "Number Of Players")]
        public int NumberOfPlayers { get; set; }
        [Display(Name = "Genre of game")]
        public string Genre { get; set; }
        [Display(Name = "Storage Area")]
        public string NameOfStorageArea { get; set; }

        //now the pieces that are unique to yard games

        [Display(Name = "Average Play Time")]
        public int AveragePlayTimeMin { get; set; }
        [Display(Name = "Game Board Type")]
        public string GameBoardType { get; set; }

    }//end of class BoardGameList
}
