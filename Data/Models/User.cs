using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("users")]
    public partial class User
    {
        public User()
        {
            CartItems = new HashSet<CartItem>();
            FriendshipNickname1Navigations = new HashSet<Friendship>();
            FriendshipNickname2Navigations = new HashSet<Friendship>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            WishedItems = new HashSet<WishedItem>();
        }

        [Key]
        [Column("nickname")]
        [StringLength(50)]
        public string Nickname { get; set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [InverseProperty("NicknameNavigation")]
        public virtual Address Address { get; set; }
        [InverseProperty("NicknameNavigation")]
        public virtual Preference Preference { get; set; }
        [InverseProperty(nameof(CartItem.NicknameNavigation))]
        public virtual ICollection<CartItem> CartItems { get; set; }
        [InverseProperty(nameof(Friendship.Nickname1Navigation))]
        public virtual ICollection<Friendship> FriendshipNickname1Navigations { get; set; }
        [InverseProperty(nameof(Friendship.Nickname2Navigation))]
        public virtual ICollection<Friendship> FriendshipNickname2Navigations { get; set; }
        [InverseProperty(nameof(Order.NicknameNavigation))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(Review.NicknameNavigation))]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty(nameof(WishedItem.NicknameNavigation))]
        public virtual ICollection<WishedItem> WishedItems { get; set; }
    }
}
