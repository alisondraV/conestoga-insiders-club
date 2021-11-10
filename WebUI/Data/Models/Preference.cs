using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    public partial class Preference
    {
        public string UserId { get; set; }
        public string Platform { get; set; }
        public bool? ReceivePromotionalEmails { get; set; }
        public int? FavouriteGameId { get; set; }
        public string GenreName { get; set; }

        public ApplicationUser User { get; set; }
        public Game FavouriteGame { get; set; }
        public GameGenre Genre { get; set; }
    }
}
