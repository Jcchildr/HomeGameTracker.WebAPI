using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Data
{
    public class CardGame : Game
    {
        [Required]
        public string NumberOfCards { get; set; }
        [Required]
        public string ExtraEquipmentUsed { get; set; }
        [Required]
        public bool IsGamblingGame { get; set; }
        [Required]
        public int AvgPlayTimeInMin { get; set; }
    }//end of class CardGame
}
