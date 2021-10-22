using ConestogaInsidersClub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    interface IGameService
    {
        Task<List<Game>> GetGames();
        Task<Game> GetGame(int gameId);
        Task<List<Game>> SearchGames(string name);
        Task AddGame(Game game);
        Task UpdateGame(int gameId, Game newGame);
        Task DeleteGame(Game game);
    }
}
