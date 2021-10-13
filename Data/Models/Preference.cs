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
        [Column("nickname")]
        [StringLength(50)]
        public string Nickname { get; set; }
        [Required]
        [Column("platform")]
        [StringLength(50)]
        public string Platform { get; set; }
        [Required]
        [Column("genre")]
        [StringLength(25)]
        public string Genre { get; set; }

        [ForeignKey(nameof(Genre))]
        [InverseProperty(nameof(GameGenre.Preferences))]
        public virtual GameGenre GenreNavigation { get; set; }
        [ForeignKey(nameof(Nickname))]
        [InverseProperty(nameof(User.Preference))]
        public virtual User NicknameNavigation { get; set; }
    }
}
