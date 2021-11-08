using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.Models
{
    public class Card
    {
        public int CardId { get; set; }

        public string CardNumber { get; set; }

        public int ExpirationYear { get; set; }

        public int ExpirationMonth { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
