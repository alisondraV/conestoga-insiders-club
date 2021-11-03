using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    interface IPreferenceService
    {
        Task<Preference> GetPreference(string userName);
        Task UpdatePreference(Preference preference);
    }
}
