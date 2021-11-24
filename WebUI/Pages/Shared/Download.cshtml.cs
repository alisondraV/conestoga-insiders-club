using ConestogaInsidersClub.Data.DataAccess;
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

        public DownloadModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public async Task<IActionResult> OnGet(string gameId)
        {
            try
            {
                var game = await gameService.GetGame(int.Parse(gameId));
                var content = $"{game.Name}\n{game.Description}";
                var bytes = Encoding.ASCII.GetBytes(content);
                return File(bytes, "application/octet-stream", $"{game.Name}.txt");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
