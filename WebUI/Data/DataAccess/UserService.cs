﻿using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<ApplicationUser>> GetUsers()
        {
            return context.Users.ToListAsync();
        }

        public Task<ApplicationUser> GetUser(string userName)
        {
            return context.Users.Where(u => u.UserName == userName).SingleAsync();
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }

        public Task CreateFriendship(string userId1, string userId2)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteFriendship(string userId1, string userId2)
        {
            throw new System.NotImplementedException();
        }
    }
}
