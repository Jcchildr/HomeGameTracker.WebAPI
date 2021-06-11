using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Data
{
    public class YardGame : Game
    {   [Required]
        public String SurfaceType { get; set; }
        [Required] 
        public Boolean BallGame { get; set; }
        [Required] 
        public int AreaOfPlayInFt { get; set; }

    }//end of class YardGame
}
