using ConestogaInsidersClub.Data.DataAccess;
using ConestogaInsidersClub.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Text;
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
            this.userService=userService;
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
                return CreateFile(game);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        private IActionResult CreateFile(Game game)
        {
            var content = $"{game.Name}\n{game.Description}";
            var bytes = Encoding.ASCII.GetBytes(content);
            return File(bytes, "application/octet-stream", $"{game.Name}.txt");
        }
    }
}
