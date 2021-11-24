using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    interface IReportService
    {
        public Task<List<Order>> OrdersReport();
        public Task<List<Game>> GamesAndWishlistReport();
        public Task<List<ApplicationUser>> CustomerInfoReport();
        public Task<Dictionary<string, int>> PlatformReport();
    }
}
