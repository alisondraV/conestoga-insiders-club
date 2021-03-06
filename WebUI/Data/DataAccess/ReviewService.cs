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
            return await context.Reviews.Where(a => a.GameId == gameId && a.Approved == true)
                .Include(r => r.User).Include(r => r.Game).ToListAsync();
        }

        public async Task<double> GetAverageRating(int gameId)
        {
            var reviews = await context.Reviews.Where(a => a.GameId == gameId).ToArrayAsync();
            return reviews.Count() == 0 ? 0 : reviews.Average(a => a.Rating);
        }

        public async Task<List<Review>> GetReviewsAwaitingApproval()
        {
            return await context.Reviews.Where(a => a.Approved == null)
                .Include(r => r.User).Include(r => r.Game).ToListAsync();
        }

        public async Task<List<Review>> GetRejectedReviews()
        {
            return await context.Reviews.Where(a => a.Approved == false)
                .Include(r => r.User).Include(r => r.Game).ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByUser(string userId)
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
