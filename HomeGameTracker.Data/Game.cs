﻿using System;
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
        public string AgeRange { get; set; }
        [Required]
        public string NumberOfPlayers { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public bool TeamGame { get; set; }

        [ForeignKey(nameof(StorageArea))]
        public int StorageId { get; set; }
        public virtual StorageArea StorageArea { get; set; }
    }
}
