using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("reviews")]
    public partial class Review
    {
        [Key]
        [Column("user_id")]
        [StringLength(50)]
        public string UserId { get; set; }
        [Key]
        [Column("game_id")]
        public int GameId { get; set; }
        [Column("rating")]
        public byte Rating { get; set; }
        [Column("description")]
        [StringLength(512)]
        public string Description { get; set; }
        [Column("approved")]
        public bool Approved { get; set; }

        [ForeignKey(nameof(GameId))]
        [InverseProperty("Reviews")]
        public virtual Game Game { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApplicationUser.Reviews))]
        public virtual ApplicationUser UserIdNavigation { get; set; }
    }
}
