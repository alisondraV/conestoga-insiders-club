using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class ReviewService : IReviewService
    {
        public Task AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Task ApproveReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReview(Review review)
        {
            throw new NotImplementedException();
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

        public Task RejectReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
