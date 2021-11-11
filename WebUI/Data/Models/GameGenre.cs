using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    public partial class GameGenre
    {
        public GameGenre()
        {
            Games = new HashSet<Game>();
            Preferences = new HashSet<Preference>();
        }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
        public ICollection<Preference> Preferences { get; set; }
    }
}
