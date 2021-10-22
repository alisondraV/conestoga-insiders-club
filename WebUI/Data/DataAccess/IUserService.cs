using ConestogaInsidersClub.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUser(string userName);
        Task<List<ApplicationUser>> GetUsers();
        Task UpdateUser(ApplicationUser user);
    }
}