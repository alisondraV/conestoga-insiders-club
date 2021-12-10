using ConestogaInsidersClub.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public interface IGameService
    {
        Task<List<Game>> GetGames();
        Task<Game> GetGame(int gameId);
        Task<List<Game>> SearchGames(string name);
        Task AddGame(Game game);
        Task UpdateGame(Game game);
        Task DeleteGame(Game game);
        bool IsOwnedBy(Game game, string userId);
        FileContentResult CreateDownloadFileOnPage(PageModel page, Game game);
    }
}
