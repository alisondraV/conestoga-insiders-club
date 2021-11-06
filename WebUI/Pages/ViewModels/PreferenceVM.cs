using System.ComponentModel.DataAnnotations;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class PreferenceVM
    {
        [StringLength(50)]
        [MinLength(3, ErrorMessage = "Platform name should be at least 3 characters long")]
        public string Platform { get; set; }

        public string GenreName { get; set; }

        public bool ReceivePromotionalEmails { get; set; }

        public int? FavouriteGameId { get; set; }

        public static Preference ToModel(Preference preference, PreferenceVM preferenceVM)
        {
            preference.GenreName = preferenceVM.GenreName == "" ? null : preferenceVM.GenreName;
            preference.Platform = preferenceVM.Platform;
            preference.ReceivePromotionalEmails = preferenceVM.ReceivePromotionalEmails;
            preference.FavouriteGameId = preferenceVM.FavouriteGameId;

            return preference;
        }

        public static PreferenceVM ToViewModel(Preference preference)
        {
            return new PreferenceVM
            {
                Platform = preference.Platform,
                GenreName = preference.GenreName,
                ReceivePromotionalEmails = preference.ReceivePromotionalEmails ?? false,
                FavouriteGameId = preference.FavouriteGameId
            };
        }
    }
}
