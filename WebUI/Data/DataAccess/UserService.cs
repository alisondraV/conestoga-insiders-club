﻿using ConestogaInsidersClub.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ApplicationUser> GetUsers()
        {
            return context.Users.ToList<ApplicationUser>();
        }

        public ApplicationUser GetUser(string userName)
        {
            return context.Users.Where(u => u.UserName == userName).First();
        }
    }
}