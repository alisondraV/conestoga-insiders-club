using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("cart_items")]
    public partial class CartItem
    {
        [Key]
        [Column("user_id")]
        [StringLength(450)]
        public string UserId { get; set; }
        [Key]
        [Column("game_id")]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        [InverseProperty("CartItems")]
        public virtual Game Game { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApplicationUser.CartItems))]
        public virtual ApplicationUser UserIdNavigation { get; set; }
    }
}
