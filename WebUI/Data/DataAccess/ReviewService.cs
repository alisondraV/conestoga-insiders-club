using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext context;

        public ReviewService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddReview(Review review)
        {
            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
        }

        public async Task ApproveReview(Review review)
        {
            review.Approved = true;
            context.Reviews.Update(review);
            await context.SaveChangesAsync();
        }

        public async Task DeleteReview(Review review)
        {
            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
        }

        public async Task<List<Review>> GetApprovedGameReviews(int gameId)
        {
            return await context.Reviews.Where(a => a.GameId == gameId && a.Approved == true).ToListAsync();
        }

        public async Task<int> GetAverageRating(int gameId)
        {
            List<Review> reviews = await context.Reviews.Where(a => a.GameId == gameId && a.Approved == true).ToListAsync();
            reviews.Select(r => r.Rating).Average()
            

        }

        public async Task<List<Review>> GetReviews()
        {
            return await context.Reviews.Where(a => a.Approved == null).ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByUser(int userId)
        {
            return await context.Reviews.Where(a => a.UserId == userId.ToString()).ToListAsync();
        }

        public async Task RejectReview(Review review)
        {
            review.Approved = false;
            context.Reviews.Update(review);
            await context.SaveChangesAsync();
        }
    }
}
