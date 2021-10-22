using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class GameService : IGameService
    {
        public Task deleteGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<Game> getGame(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> getGames()
        {
            throw new NotImplementedException();
        }

        public Task<List<Game>> searchGames(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Game> updateGame(int gameId, Game newGame)
        {
            throw new NotImplementedException();
        }
    }
}
