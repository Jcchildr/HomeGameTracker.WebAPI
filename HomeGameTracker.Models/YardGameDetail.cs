using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class YardGameDetail
    {
        [Display(Name = "Game Id")]
        public int GameId { get; set; }
        [Display(Name = "Title")]
        public string GameName { get; set; }
        [Display(Name = "Publish Year")]
        public int PublishYear { get; set; }
        [Display(Name = "Age Range")]
        public int AgeRating { get; set; }
        [Display(Name = "Maximum Number Of Players")]
        public int MaxNumberOfPlayers { get; set; }
        [Display(Name = "Minimum Number Of Players")]
        public int MinNumberOfPlayers { get; set; }
        [Display(Name = "Team Game?")]
        public bool TeamGame { get; set; }
        [Display(Name = "Genre of game")]
        public string Genre { get; set; }
        [Display(Name = "Type of Surface Played On")]
        public string SurfaceType { get; set; }
        [Display(Name = "Ball Game")]
        public bool BallGame { get; set; }
        [Display(Name = "Area of Playing Field in Feet")]
        public int AreaOfPlayInFt { get; set; }
        public int StorageAreaId { get; set; }
        [Display(Name = "Storage Area")]
        public string NameOfStorageArea { get; set; }
    }//end of class YardGameDetail
}
