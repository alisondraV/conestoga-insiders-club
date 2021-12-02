using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext context;

        public ReportService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Order>> OrdersReport(DateTime date)
        {
            return await context.Orders.Include(U => U.User).Include(i => i.OrderItems).ThenInclude(g => g.Game).Where(o => o.CreatedAt.Date == date.Date).ToListAsync();
        }
        public async Task<List<Game>> GamesAndWishlistReport()
        {
            return await context.Games.Include(w => w.WishedItems).ToListAsync();
        }
        public async Task<List<ApplicationUser>> CustomerInfoReport()
        {
            return await context.Users.Include(a => a.MailingAddress).ToListAsync();
        }
        public async Task<Dictionary<string, int>> PlatformReport()
        {
            Dictionary<string, int> reportData = new Dictionary<string, int>();
            var preferences = await context.Preferences.ToListAsync();
            foreach (var item in preferences)
            {
                if (!reportData.ContainsKey(item.Platform))
                {
                    reportData.Add(item.Platform,
                        context.Preferences.Where(a => a.Platform == item.Platform)
                        .ToList().Count);
                }
                else
                {
                    continue;
                }
            }
            return reportData;
        }
    }
}
