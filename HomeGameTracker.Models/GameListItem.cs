using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class GameListItem
    {
        //returning information on the game when it's part of a list
        public int GameId { get; set; }
        [Display(Name="Title")]
        public int GameName { get; set; }
        [Display(Name = "Age Range")]
        public string AgeRange { get; set; }
        [Display(Name = "Number Of Players")]
        [Range(1, 64, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public object NumberOfPlayers { get; set; }

    }//end of GameListItem
}
