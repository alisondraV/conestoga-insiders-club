using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ConestogaInsidersClub.Data.Models
{
    public partial class WishedItem
    {
        public string UserId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
