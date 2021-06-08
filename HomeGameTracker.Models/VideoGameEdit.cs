using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class VideoGameEdit
    {
        [Required]
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int AgeRating { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public int PublishYear { get; set; }
        public string Genre { get; set; }
        public bool TeamGame { get; set; }
        public string ConsoleType { get; set; }
        public bool OnlineGamePlay { get; set; }
        public int StorageId { get; set; }
    }
}
