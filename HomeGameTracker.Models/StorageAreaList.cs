using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class StorageAreaList
    {
        [Display(Name = "Storage Id")]
        public int StorageAreaId { get; set; }
        [Display(Name = "Storage Area Name")]
        public string NameOfStorageArea { get; set; }
        [Display(Name = "Game Type Stored")]
        public string GameType { get; set; }

    }
}
