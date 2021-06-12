using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class YardGameList
    {
        //this is the object to hold a couple details of yard game for display in a list

        //the attributes coming from game

        [Display(Name = "Game Id")]
        public int GameId { get; set; }
        [Display(Name = "Title")]
        public string GameName { get; set; }
        [Display(Name = "Maximum Number Of Players")]
        public int MaxNumberOfPlayers { get; set; }
        [Display(Name = "Minimum Number Of Players")]
        public int MinNumberOfPlayers { get; set; }
        [Display(Name = "Genre of game")]
        public string Genre { get; set; }
        [Display(Name = "Storage Area")]
        public string NameOfStorageArea { get; set; }
        
        //now the pieces that are unique to yard games
        
        [Display(Name = "Play Surface")]
        public string SurfaceType { get; set; }
        [Display(Name = "Ball Game")]
        public bool BallGame { get; set; }
        [Display(Name = "Play Area")]
        public int AreaOfPlayInFt { get; set; }
        

    }//end of class YardGameList
}
