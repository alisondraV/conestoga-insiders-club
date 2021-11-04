using System.ComponentModel.DataAnnotations;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class PreferenceVM
    {
        [StringLength(50)]
        [MinLength(3, ErrorMessage = "Platform name should be at least 3 characters long")]
        public string Platform { get; set; }

        [StringLength(25)]
        [MinLength(3, ErrorMessage = "Genre name should be at least 3 characters long")]
        public string Genre { get; set; }

        public bool ReceivePromotionalEmails { get; set; }

        public static Preference ToModel(Preference preference, PreferenceVM preferenceVM)
        {
            preference.Genre = preferenceVM.Genre;
            preference.Platform = preferenceVM.Platform;
            preference.ReceivePromotionalEmails = preferenceVM.ReceivePromotionalEmails;

            return preference;
        }

        public static PreferenceVM ToViewModel(Preference preference)
        {
            return new PreferenceVM
            {
                Platform = preference.Platform,
                Genre = preference.Genre,
                ReceivePromotionalEmails = preference.ReceivePromotionalEmails
            };
        }
    }
}
