using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Data
{
    public class StorageArea
    {
        [Key]
        public int StorageAreaId { get; set; }
        [Required]
        public string NameOfStorageArea { get; set; }
        [Required]
        public string GameType { get; set; }

        public virtual ICollection<VideoGame> ListOfVideoGames { get; set; }
        public StorageArea()
        {
            ListOfVideoGames = new HashSet<VideoGame>();
        }
    }//end of class
}
