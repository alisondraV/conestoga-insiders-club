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
        [Required]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Credit Card Number should contain exactly 16 digits")]
        public string CardNumber { get; set; }

        [Required]
        [Range(2021, 2030, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int ExpirationYear { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public int ExpirationMonth { get; set; }

        public static Card ToModel(CreditCardVM cardVM)
        {
            return new Card
            {
                CardNumber = cardVM.CardNumber,
                ExpirationYear = cardVM.ExpirationYear,
                ExpirationMonth = cardVM.ExpirationMonth
            };
        }

        public static CreditCardVM ToViewModel(Card card)
        {
            return new CreditCardVM
            {
                CardNumber = card.CardNumber,
                ExpirationYear = card.ExpirationYear,
                ExpirationMonth = card.ExpirationMonth
            };
        }
    }
}
