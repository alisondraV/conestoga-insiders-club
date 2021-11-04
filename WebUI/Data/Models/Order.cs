using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("orders")]
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Required]
        [Column("user_id")]
        [StringLength(450)]
        public string UserId { get; set; }
        [Column("created_at", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(ApplicationUser.Orders))]
        public virtual ApplicationUser UserIdNavigation { get; set; }
        [InverseProperty(nameof(OrderItem.Order))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
