using HomeGameTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class CardGameEdit : Game
    {
        public int NumberOfCards { get; set; }
        public string ExtraEquipmentUsed { get; set; }
        public bool IsGamblingGame { get; set; }
        public int AvgPlayTimeInMin { get; set; }
    }
}
