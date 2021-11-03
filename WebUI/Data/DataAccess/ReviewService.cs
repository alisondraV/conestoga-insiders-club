using ConestogaInsidersClub.Data.Models;
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

        public Task<List<Review>> GetApprovedGameReviews(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAverageRating(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetReviews()
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetReviewsByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task RejectReview(Review review)
        {
            review.Approved = false;
            context.Reviews.Update(review);
            await context.SaveChangesAsync();
        }
    }
}
