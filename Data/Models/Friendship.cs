using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    [Table("friendships")]
    public partial class Friendship
    {
        [Key]
        [Column("user_id1")]
        [StringLength(50)]
        public string UserId1 { get; set; }
        [Key]
        [Column("user_id2")]
        [StringLength(50)]
        public string UserId2 { get; set; }
        [Column("created_at", TypeName = "date")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId1))]
        [InverseProperty(nameof(ApplicationUser.FriendshipUserId1Navigations))]
        public virtual ApplicationUser UserId1Navigation { get; set; }
        [ForeignKey(nameof(UserId2))]
        [InverseProperty(nameof(ApplicationUser.FriendshipUserId2Navigations))]
        public virtual ApplicationUser UserId2Navigation { get; set; }
    }
}
