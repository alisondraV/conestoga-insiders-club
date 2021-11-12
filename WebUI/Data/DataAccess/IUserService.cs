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
        Task CreateFriendship(string userId1, string userId2);
        Task<List<ApplicationUser>> GetFriends(ApplicationUser user);
        Task DeleteFriendship(string userId1, string userId2);
        Task<ApplicationUser> GetUserWithRelatedData(string userName);
        Task<List<Card>> GetCards(string userId);
        Task DeleteCard(Card card);
    }
}