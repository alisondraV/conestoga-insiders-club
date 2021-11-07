using ConestogaInsidersClub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public interface IGameGenreService
    {
        Task<GameGenre> GetGameGenre(int genreId);
        Task<List<GameGenre>> GetGameGenres();
    }
}
