using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("games")]
    public partial class Game
    {
        public Game()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
            Reviews = new HashSet<Review>();
            WishedItems = new HashSet<WishedItem>();
            Preferences = new HashSet<Preference>();
        }

        [Key]
        [Column("game_id")]
        public int GameId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("description")]
        [StringLength(100)]
        public string Description { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Required]
        [Column("genre")]
        [StringLength(25)]
        public string Genre { get; set; }

        public ICollection<Preference> Preferences { get; set; }

        [ForeignKey(nameof(Genre))]
        [InverseProperty(nameof(GameGenre.Games))]
        public virtual GameGenre GenreNavigation { get; set; }
        [InverseProperty(nameof(CartItem.Game))]
        public virtual ICollection<CartItem> CartItems { get; set; }
        [InverseProperty(nameof(OrderItem.Game))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [InverseProperty(nameof(Review.Game))]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty(nameof(WishedItem.Game))]
        public virtual ICollection<WishedItem> WishedItems { get; set; }
    }
}
