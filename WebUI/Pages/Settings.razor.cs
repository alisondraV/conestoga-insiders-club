using ConestogaInsidersClub.Data.DataAccess;
using ConestogaInsidersClub.Data.Models;
using ConestogaInsidersClub.Pages.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Pages
{
    public partial class Settings
    {
        [Inject]
        IPreferenceService preferenceService { get; set; }

        [Inject]
        IGameService gameService { get; set; }

        [Inject]
        IGameGenreService gameGenreService { get; set; }

        [Inject]
        IUserService userService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [CascadingParameter(Name = "user")]
        protected ApplicationUser user { get; set; }

        [CascadingParameter(Name = "userViewModel")]
        public UserVM userViewModel { get; set; }

        public Preference preference;
        public List<Game> games;
        public List<GameGenre> gameGenres;
        public PreferenceVM preferenceViewModel;
        public bool editPreferenceMode = false;

        protected override async Task OnInitializedAsync()
        {
            preference = await preferenceService.GetPreference(user.UserName);
            games = await gameService.GetGames();
            gameGenres = await gameGenreService.GetGameGenres();

            preferenceViewModel = new PreferenceVM(preference);
        }

        public async void HandlePreferenceSubmit()
        {
            Preference updatedPreference = preferenceViewModel.ToModel(preference);
            await preferenceService.UpdatePreference(updatedPreference);
            FlipEditPreferenceMode();
            StateHasChanged();
        }

        public async void HandleMailingAddressSubmit(Address newAddress)
        {
            userViewModel.MailingAddress = newAddress;
            ApplicationUser updatedUser = userViewModel.ToModel(user);
            await userService.UpdateUser(updatedUser);
        }

        public async void HandleShippingAddressSubmit(Address newAddress)
        {
            userViewModel.ShippingAddress = newAddress;
            ApplicationUser updatedUser = userViewModel.ToModel(user);
            await userService.UpdateUser(updatedUser);
        }

        public void GoToCreditCardPage()
        {
            NavigationManager.NavigateTo("credit-card");
        }

        public void FlipEditPreferenceMode()
        {
            editPreferenceMode = !editPreferenceMode;
        }
    }
}
