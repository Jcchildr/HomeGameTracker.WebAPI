using HomeGameTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class CardGameCreate : Game
    {
        [Required]
        public string NumberOfCards { get; set; }
        [Required]
        public string ExtraEquipmentUsed { get; set; }
        [Required]
        public bool IsGamblingGame { get; set; }
        [Required]
        public int AvgPlayTimeInMin { get; set; }
    }
}
