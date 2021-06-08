using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class BoardGameCreate
    {

        [Required]
        public string GameName { get; set; }
        [Required]
        public int AgeRating { get; set; }
        [Required]
        public int NumberOfPlayers { get; set; }
        [Required]
        public int PublishYear { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public bool TeamGame { get; set; }
        [Required]
        public int StorageId { get; set; }
        //specific attributes of BoardGame
        [Required]
        public int AveragePlayTimeMin { get; set; }
        [Required]
        public string GameBoardType { get; set; }


    }//end of class BoardGameCreate
}
