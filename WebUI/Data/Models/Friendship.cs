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
        public string UserId1 { get; set; }
        public string UserId2 { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicationUser User1 { get; set; }
        public ApplicationUser User2 { get; set; }
    }
}
