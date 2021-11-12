using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class UserVM
    {
        [Required]
        [MinLength(2, ErrorMessage = "FirstName name should be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "FirstName name is too long")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "LastName name should be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "LastName name is too long")]
        public string LastName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "UserName name should be at least 2 characters long")]
        [MaxLength(256, ErrorMessage = "UserName name is too long")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(typeof(DateTime), "1/1/1920", "12/31/2010", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime BirthDay { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public Address MailingAddress { get; set; }

        public Address ShippingAddress { get; set; }

        public Gender? GenderName { get; set; }

        public ICollection<Card> Cards { get; set; }

        public static ApplicationUser ToModel(ApplicationUser user, UserVM userVM)
        {
            user.UserName = userVM.UserName;
            user.FirstName = userVM.FirstName;
            user.LastName = userVM.LastName;
            user.Email = userVM.Email;
            user.BirthDay = userVM.BirthDay;
            user.PhoneNumber = userVM.PhoneNumber;
            user.MailingAddress = userVM.MailingAddress;
            user.ShippingAddress = userVM.ShippingAddress;
            user.Gender = userVM.GenderName == Gender.NotSet ? null : userVM.GenderName;
            user.Cards = userVM.Cards;

            return user;
        }

        public static UserVM ToViewModel(ApplicationUser user)
        {
            return new UserVM
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDay = user.BirthDay,
                PhoneNumber = user.PhoneNumber,
                MailingAddress = user.MailingAddress,
                ShippingAddress = user.ShippingAddress,
                GenderName = user.Gender,
                Cards = user.Cards
            };
        }
    }
}
