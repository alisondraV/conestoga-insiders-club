using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    public partial class Review
    {
        public string UserId { get; set; }
        public int GameId { get; set; }
        public byte Rating { get; set; }
        public string Description { get; set; }
        public bool? Approved { get; set; }

        public Game Game { get; set; }
        public ApplicationUser User { get; set; }
    }
}
