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
        [Column("nickname1")]
        [StringLength(50)]
        public string Nickname1 { get; set; }
        [Key]
        [Column("nickname2")]
        [StringLength(50)]
        public string Nickname2 { get; set; }
        [Column("created_at", TypeName = "date")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(Nickname1))]
        [InverseProperty(nameof(User.FriendshipNickname1Navigations))]
        public virtual User Nickname1Navigation { get; set; }
        [ForeignKey(nameof(Nickname2))]
        [InverseProperty(nameof(User.FriendshipNickname2Navigations))]
        public virtual User Nickname2Navigation { get; set; }
    }
}
