using HomeGameTracker.Data;
using System.ComponentModel.DataAnnotations;

namespace HomeGameTracker.Models
{
    public class CardGameCreate : Game
    {
        [Required]
        public int NumberOfCards { get; set; }
        [Required]
        public string ExtraEquipmentUsed { get; set; }
        [Required]
        public bool IsGamblingGame { get; set; }
        [Required]
        public int AvgPlayTimeInMin { get; set; }
    }
}
