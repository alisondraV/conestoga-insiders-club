using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    interface IGameService
    {
        Task<List<Game>> getGames();
        Task<Game> getGame(int gameId);
        Task<List<Game>> searchGames(string name);
        Task<Game> updateGame(int gameId, Game newGame);
        Task deleteGame(int gameId);
    }
}
