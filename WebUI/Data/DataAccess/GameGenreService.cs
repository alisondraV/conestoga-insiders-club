using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class GameGenreService : IGameGenreService
    {
        private readonly ApplicationDbContext context;

        public GameGenreService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<GameGenre>> GetGameGenres()
        {
            return context.GameGenres.ToListAsync();
        }
    }
}
