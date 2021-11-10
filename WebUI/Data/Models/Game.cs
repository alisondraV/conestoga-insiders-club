using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
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

        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string GenreName { get; set; }

        public GameGenre Genre { get; set; }
        public ICollection<Preference> Preferences { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<WishedItem> WishedItems { get; set; }
    }
}
