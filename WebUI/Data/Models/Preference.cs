using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("preferences")]
    public partial class Preference
    {
        [Column("user_id")]
        [StringLength(450)]
        public string UserId { get; set; }

        [Required]
        [Column("platform")]
        [StringLength(50)]
        public string Platform { get; set; }

        [Column("receive_promotional_emails")]
        public bool ReceivePromotionalEmails { get; set; }

        [Column("favourite_game_id")]
        public int FavouriteGameId { get; set; }

        [Required]
        [Column("genre")]
        [StringLength(25)]
        public string GenreName { get; set; }

        public ApplicationUser User { get; set; }
        public Game FavouriteGame { get; set; }
        public GameGenre Genre { get; set; }
    }
}
