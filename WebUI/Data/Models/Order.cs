using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderType OrderType { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
