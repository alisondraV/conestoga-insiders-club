using System;
using System.ComponentModel.DataAnnotations;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class UserVM
    {
        public UserVM(ApplicationUser user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            BirthDay = user.BirthDay;
            PhoneNumber = user.PhoneNumber;
            MailingAddress = user.MailingAddress;
            ShippingAddress = user.ShippingAddress;
        }

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

        public DateTime BirthDay { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public Address MailingAddress { get; set; }

        public Address ShippingAddress { get; set; }

        public ApplicationUser ToModel(ApplicationUser user)
        {
            user.UserName = this.UserName;
            user.FirstName = this.FirstName;
            user.LastName = this.LastName;
            user.Email = this.Email;
            user.BirthDay = this.BirthDay;
            user.PhoneNumber = this.PhoneNumber;
            user.MailingAddress = this.MailingAddress;
            user.ShippingAddress = this.ShippingAddress;

            return user;
        }
    }
}
