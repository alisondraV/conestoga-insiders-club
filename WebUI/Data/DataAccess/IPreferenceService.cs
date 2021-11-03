using ConestogaInsidersClub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public interface IPreferenceService
    {
        Task<Preference> GetPreference(string userId);
        Task UpdatePreference(Preference preference);
    }
}
