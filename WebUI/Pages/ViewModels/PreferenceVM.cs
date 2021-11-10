using System.ComponentModel.DataAnnotations;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class PreferenceVM
    {
        public PreferenceVM(Preference preference)
        {
            Platform = preference.Platform;
            GenreName = preference.GenreName;
            ReceivePromotionalEmails = preference.ReceivePromotionalEmails ?? false;
            FavouriteGameId = preference.FavouriteGameId;
        }

        [StringLength(50)]
        [MinLength(3, ErrorMessage = "Platform name should be at least 3 characters long")]
        public string Platform { get; set; }

        public string GenreName { get; set; }

        public bool ReceivePromotionalEmails { get; set; }

        public int? FavouriteGameId { get; set; }

        public Preference ToModel(Preference preference)
        {
            preference.GenreName = this.GenreName == "" ? null : this.GenreName;
            preference.Platform = this.Platform;
            preference.ReceivePromotionalEmails = this.ReceivePromotionalEmails;
            preference.FavouriteGameId = this.FavouriteGameId;

            return preference;
        }
    }
}
