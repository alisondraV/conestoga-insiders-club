using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    public partial class OrderItem
    {
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public int Quantity { get; set; }

        public Game Game { get; set; }
        public Order Order { get; set; }
    }
}
