using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class StorageAreaCreate
    {
        [Required]
        public string NameOfStorageArea { get; set; }

    }
}
