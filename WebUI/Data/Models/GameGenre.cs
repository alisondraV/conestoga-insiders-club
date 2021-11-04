using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("game_genres")]
    public partial class GameGenre
    {
        public GameGenre()
        {
            Games = new HashSet<Game>();
            Preferences = new HashSet<Preference>();
        }

        [Key]
        [Column("name")]
        [StringLength(25)]
        public string Name { get; set; }

        [InverseProperty(nameof(Game.GenreNavigation))]
        public virtual ICollection<Game> Games { get; set; }
        [InverseProperty(nameof(Preference.Genre))]
        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
