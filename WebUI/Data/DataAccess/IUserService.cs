using ConestogaInsidersClub.Data.Models;
using System.Collections.Generic;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public interface IUserService
    {
        ApplicationUser GetUser(string userName);
        List<ApplicationUser> GetUsers();
    }
}