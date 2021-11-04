using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class PreferenceService : IPreferenceService
    {
        private readonly ApplicationDbContext context;

        public PreferenceService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<Preference> GetPreference(string userName)
        {
            return Task.FromResult(new Preference
            {
                UserId = "1",
                Platform = "Windows",
                Genre = "Action"
            });
        }

        public async Task UpdatePreference(Preference preference)
        {

        }
    }
}
