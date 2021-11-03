using System;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(50, ErrorMessage = "UserName name is too long")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime BirthDay { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }

        public static ApplicationUser ToModel(UserVM userVM)
        {
            return new ApplicationUser
            {
                UserName = userVM.UserName,
                FirstName = userVM.FirstName,
                LastName = userVM.LastName,
                Email = userVM.Email,
                BirthDay = userVM.BirthDay,
                PhoneNumber = userVM.PhoneNumber,
                Address = userVM.Address
            };
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
                Address = user.Address
            };
        }
    }
}
