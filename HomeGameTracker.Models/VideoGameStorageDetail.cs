using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class VideoGameStorageDetail
    {
        [Display(Name = "Game Id")]
        public int GameId { get; set; }
        [Display(Name = "Title")]
        public string GameName { get; set; }
    }
}
