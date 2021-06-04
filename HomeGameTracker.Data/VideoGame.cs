using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Data
{
    public class VideoGame : Game
    {
      
        public string ConsoleType { get; set; }
      
        public bool OnlineGamePlay { get; set; }

    }//end class
}
