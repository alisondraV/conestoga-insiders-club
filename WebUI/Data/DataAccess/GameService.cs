using ConestogaInsidersClub.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext context;

        public GameService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<Game>> GetGames()
        {
            return context.Games.ToListAsync();
        }

        public Task<Game> GetGame(int gameId)
        {
            return context.Games
                .Include(g => g.OrderItems)
                .ThenInclude(oi => oi.Order)
                .FirstOrDefaultAsync(g => g.GameId == gameId);
        }

        public Task<List<Game>> SearchGames(string name)
        {
            return context.Games.Where(g => g.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task AddGame(Game newGame)
        {
            await context.Games.AddAsync(newGame);
            await context.SaveChangesAsync();
        }

        public async Task UpdateGame(Game game)
        {
            context.Games.Update(game);
            await context.SaveChangesAsync();
        }

        public async Task DeleteGame(Game game)
        {
            context.Games.Remove(game);
            await context.SaveChangesAsync();
        }

        public bool IsOwnedBy(Game game, string userId)
        {
            return game.OrderItems.Any(oi => oi.Order.UserId == userId);
        }

        public FileContentResult CreateDownloadFileOnPage(PageModel page, Game game)
        {
            var content = $"{game.Name}\n{game.Description}";
            var bytes = Encoding.ASCII.GetBytes(content);
            return page.File(bytes, "application/octet-stream", $"{game.Name}.txt");
        }
    }
}
