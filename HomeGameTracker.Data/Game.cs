using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Data
{
    public abstract class Game
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public int AgeRating { get; set; }
        [Required]
        [Range(1, 64, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public object NumberOfPlayers { get; set; }
        [Required]
        [Range(typeof(int), "1900", "2021",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public object PublishYear { get; set; }
        [Required]
        public bool TeamGame { get; set; }
        [Required]
        public string Genre { get; set; }

        [ForeignKey(nameof(StorageArea))]
        public int StorageId { get; set; }
        public virtual StorageArea StorageArea { get; set; }
    }
}
