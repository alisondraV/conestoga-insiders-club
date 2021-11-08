using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("users")]
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            CartItems = new HashSet<CartItem>();
            FriendshipUserId1Navigations = new HashSet<Friendship>();
            FriendshipUserId2Navigations = new HashSet<Friendship>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            WishedItems = new HashSet<WishedItem>();
        }

        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [InverseProperty("UserIdNavigation")]
        public virtual Address Address { get; set; }

        public Preference Preference { get; set; }
        [Column("birthday")]
        public DateTime BirthDay { get; set; }

        [InverseProperty(nameof(CartItem.UserIdNavigation))]
        public virtual ICollection<CartItem> CartItems { get; set; }
        [InverseProperty(nameof(Friendship.UserId1Navigation))]
        public virtual ICollection<Friendship> FriendshipUserId1Navigations { get; set; }
        [InverseProperty(nameof(Friendship.UserId2Navigation))]
        public virtual ICollection<Friendship> FriendshipUserId2Navigations { get; set; }
        [InverseProperty(nameof(Order.UserIdNavigation))]
        public virtual ICollection<Order> Orders { get; set; }
        [InverseProperty(nameof(Review.UserIdNavigation))]
        public virtual ICollection<Review> Reviews { get; set; }
        [InverseProperty(nameof(WishedItem.UserIdNavigation))]
        public virtual ICollection<WishedItem> WishedItems { get; set; }
    }
}
