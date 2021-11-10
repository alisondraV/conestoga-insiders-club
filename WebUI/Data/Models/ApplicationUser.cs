using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("users")]
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            CartItems = new HashSet<CartItem>();
            Orders = new HashSet<Order>();
            Reviews = new HashSet<Review>();
            WishedItems = new HashSet<WishedItem>();
            Cards = new HashSet<Card>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender? Gender { get; set; }
        public int? MailingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }
        public Address MailingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public Preference Preference { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<WishedItem> WishedItems { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
