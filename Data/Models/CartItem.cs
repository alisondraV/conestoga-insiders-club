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
        [Column("nickname")]
        [StringLength(50)]
        public string Nickname { get; set; }
        [Key]
        [Column("game_id")]
        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        [InverseProperty("CartItems")]
        public virtual Game Game { get; set; }
        [ForeignKey(nameof(Nickname))]
        [InverseProperty(nameof(User.CartItems))]
        public virtual User NicknameNavigation { get; set; }
    }
}
