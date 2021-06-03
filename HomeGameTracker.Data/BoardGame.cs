using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Data
{
    public class BoardGame: Game
    {
        [Required]
        public int AveragePlayTimeMin { get; set; }
        [Required]
        public string GameBoardType { get; set; }


    }//end of class BoardGame
}
