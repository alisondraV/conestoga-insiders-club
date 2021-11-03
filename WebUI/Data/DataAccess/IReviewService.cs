using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    interface IReviewService
    {
        Task<List<Review>> GetReviews();
        Task<List<Review>> GetApprovedGameReviews(int gameId);
        Task ApproveReview(Review review);
        Task RejectReview(Review review);
        Task AddReview(Review review);
        Task DeleteReview(Review review);
        Task<List<Review>> GetReviewsByUser(int userId);
        Task<int> GetAverageRating(int gameId);

    }
}
