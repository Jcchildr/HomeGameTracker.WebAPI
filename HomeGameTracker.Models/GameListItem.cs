﻿using System;
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
        [Display(Name = "Title")]
        public string GameName { get; set; }
        [Display(Name = "Card game genre")]
        public string Genre { get; set; }
        [Display(Name = "Age Rating")]
        public int AgeRating { get; set; }
        [Display(Name = "Number Of Players")]
        [Range(1, 64, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int NumberOfPlayers { get; set; }
        [Display(Name = "Number of cards needed")]
        public string NumberOfCards { get; set; }
        [Display(Name = "Items needed other than the cards")]
        public string ExtraEquipmentUsed { get; set; }
        [Display(Name = "This is a gambling game")]
        public bool IsGamblingGame { get; set; }
        [Display(Name = "Average time required to complete game")]
        public int AvgPlayTimeInMin { get; set; }

    }//end of GameListItem
}
