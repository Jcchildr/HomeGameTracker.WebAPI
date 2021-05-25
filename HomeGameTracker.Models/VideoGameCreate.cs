using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class VideoGameCreate
    {
        [Required]
        public string GameName { get; set; }
        [Required]
        public int AgeRating { get; set; }
        [Required]
        [Range(1, 64, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public object NumberOfPlayers { get; set; }
        [Required]
        [Range(typeof(DateTime), "1/1/1900", "6/12/2021",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public object PublishDate { get; set; }
        [Required]
        public bool TeamGame { get; set; }
        [Required]
        public string ConsoleType { get; set; }
        [Required]
        public bool OnlineGamePlay { get; set; }
        [Required]
        public string Genre { get; set; }
    }
}
