using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class YardGameEdit
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public int AgeRating { get; set; }
        [Required]
        public int MinNumberOfPlayers { get; set; }
        [Required]
        public int MaxNumberOfPlayers { get; set; }
        [Required]
        public int PublishYear { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public bool TeamGame { get; set; }
        [Required]
        public int StorageId { get; set; }
        [Required]
        public string SurfaceType { get; set; }
        [Required]
        public bool BallGame { get; set; }
        [Required]
        public int AreaOfPlayInFt { get; set; }
    }//end of class YardGameEdit
}
