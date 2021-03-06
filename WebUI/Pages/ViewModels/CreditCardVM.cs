using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class CreditCardVM
    {
        public CreditCardVM(Card card)
        {
            CardNumber = card.CardNumber;
            ExpirationYear = card.ExpirationYear;
            ExpirationMonth = card.ExpirationMonth;
        }

        [Required]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Credit Card Number should contain exactly 16 digits")]
        public string CardNumber { get; set; }

        [Required]
        [Range(2022, 2030, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int ExpirationYear { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int ExpirationMonth { get; set; }

        public Card ToModel(Card card)
        {
            card.CardNumber = CardNumber;
            card.ExpirationYear = ExpirationYear;
            card.ExpirationMonth = ExpirationMonth;

            return card;
        }
    }
}
