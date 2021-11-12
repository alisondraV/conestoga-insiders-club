using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class PreferenceService : IPreferenceService
    {
        private readonly ApplicationDbContext context;
        private readonly IUserService userService;

        public PreferenceService(ApplicationDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public async Task<Preference> GetPreference(string userName)
        {
            var user = await userService.GetUserWithRelatedData(userName);
            return user.Preference;
        }

        public async Task UpdatePreference(Preference preference)
        {
            context.Preferences.Update(preference);
            await context.SaveChangesAsync();
        }
    }
}
