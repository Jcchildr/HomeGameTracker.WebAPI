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
     
        public string NumberOfCards { get; set; }
    
        public string ExtraEquipmentUsed { get; set; }
   
        public bool IsGamblingGame { get; set; }
      
        public int AvgPlayTimeInMin { get; set; }
    }//end of class CardGame
}
