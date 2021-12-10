using ConestogaInsidersClub.Data.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Pages.Shared
{
    public class DownloadModel : PageModel
    {
        IGameService gameService;
        IUserService userService;

        public DownloadModel(IGameService gameService, IUserService userService)
        {
            this.gameService = gameService;
            this.userService = userService;
        }

        public async Task<IActionResult> OnGet(string gameId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            try
            {
                var game = await gameService.GetGame(int.Parse(gameId));
                var user = await userService.GetUser(User.Identity.Name);
                if (!gameService.IsOwnedBy(game, user.Id))
                {
                    return Unauthorized();
                }
                return gameService.CreateDownloadFileOnPage(this, game);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
