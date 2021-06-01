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
        public int NumberOfPlayers { get; set; }
        [Required]
        public int PublishYear { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public bool TeamGame { get; set; }
        [Required]
        public string ConsoleType { get; set; }
        [Required]
        public bool OnlineGamePlay { get; set; }
        [Required]
        public int StorageId { get; set; }
    }
}
