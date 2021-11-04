using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("wished_items")]
    public partial class WishedItem
    {
        [Key]
        [Column("user_id")]
        [StringLength(450)]
        public string UserId { get; set; }
        [Key]
        [Column("game_id")]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        [InverseProperty("WishedItems")]
        public virtual Game Game { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApplicationUser.WishedItems))]
        public virtual ApplicationUser UserIdNavigation { get; set; }
    }
}
