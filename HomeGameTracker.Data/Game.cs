using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string AgeRange { get; set; }
        public string NumberOfPlayers { get; set; }
        public DateTime PublishDate { get; set; }
        public bool TeamGame { get; set; }

        public virtual ICollection<StorageArea> ListOfStorageAreas { get; set; }

        public Game()
        {
            ListOfStorageAreas = new HashSet<StorageArea>();
        }
    }
}
