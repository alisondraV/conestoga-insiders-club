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
        [Key]
        [Column("user_id")]
        [StringLength(50)]
        public string UserId { get; set; }

        [Required]
        [Column("platform")]
        [StringLength(50)]
        public string Platform { get; set; }

        [Required]
        [Column("genre")]
        [StringLength(25)]
        public string Genre { get; set; }

        [Column("receive_promotional_emails")]
        public bool ReceivePromotionalEmails { get; set; }

        [Column("favourite_game_id")]
        public Game FavouriteGame { get; set; }

        [ForeignKey(nameof(Genre))]
        [InverseProperty(nameof(GameGenre.Preferences))]
        public virtual GameGenre GenreNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApplicationUser.Preference))]
        public virtual ApplicationUser UserIdNavigation { get; set; }
    }
}
