﻿using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext context;

        public GameService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<List<Game>> GetGames()
        {
            return context.Games.ToListAsync();
        }

        public Task<Game> GetGame(int gameId)
        {
            return context.Games.FindAsync(gameId).AsTask();
        }

        public Task<List<Game>> SearchGames(string name)
        {
            return context.Games.Where(g => g.Name == name).ToListAsync();
        }

        public async Task AddGame(Game newGame)
        {
            await context.Games.AddAsync(newGame);
            await context.SaveChangesAsync();
        }

        public async Task UpdateGame(int gameId, Game newGame)
        {
            context.Games.Update(newGame);
            await context.SaveChangesAsync();
        }

        public async Task DeleteGame(Game game)
        {
            context.Games.Remove(game);
            await context.SaveChangesAsync();
        }
    }
}