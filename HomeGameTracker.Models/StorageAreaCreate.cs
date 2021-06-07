﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeGameTracker.Models
{
    public class StorageAreaEdit
    {
        [Required]
        public int StorageAreaId { get; set; }
        [Required]
        public string NameOfStorageArea { get; set; }
        [Required]
        public string GameType { get; set; }

    }
}
