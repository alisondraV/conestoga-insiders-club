using ConestogaInsidersClub.Data;
using ConestogaInsidersClub.Data.DataAccess;
using ConestogaInsidersClub.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTests
{
    class ReviewServiceTests : TestBase
    {
        private Game testGame;
        private ApplicationUser testUser;
        private ApplicationUser testUser2;
        private Review testReview;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {

            using var context = new ApplicationDbContext(ContextOptions);

            testGame = new Game()
            {
                GameId = 1,
                Name = "Age of Empires IV",
                Description = "RTS Game"
            };
            await context.Set<Game>().AddAsync(testGame);

            testUser = new ApplicationUser()
            {
                Id = "d123",
                UserName = "test",
                NormalizedUserName = "TEST",
                Email = "test@user.com"
            };
            testUser2 = new ApplicationUser()
            {
                Id = "d124",
                UserName = "fake",
                NormalizedUserName = "FAKE",
                Email = "fake@user.com"
            };
            await context.Set<ApplicationUser>().AddAsync(testUser);

            await context.Set<ApplicationUser>().AddAsync(testUser2);


            testReview = new Review() 
            { 
                GameId = testGame.GameId,
                UserId = testUser.Id,
                Rating = 5,
                Description = "good game",
                Approved = false 
            };
            await context.Set<Review>().AddAsync(testReview);

            await context.SaveChangesAsync();
        }

        //Task DeleteReview(Review review);
        //Task<double> GetAverageRating(int gameId);

        [Test, Order(1)]
        public async Task GetReviews()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            //Act
            var reviews = await service.GetReviews();
            //Assert
            Assert.IsNotNull(reviews);
            Assert.That(reviews, Has.Count.EqualTo(1));
        }

        [Test, Order(2)]
        public async Task AddReviews()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            Review review = new Review()
            {
                GameId = testGame.GameId,
                UserId = testUser2.Id,
                Rating = 3,
                Description = "decent game",
                Approved = false
            };
            //Act
            await service.AddReview(review);
            var reviews = await service.GetReviews();
            //Assert
            Assert.IsNotNull(reviews);
            Assert.That(reviews, Has.Count.EqualTo(2));
        }

        [Test, Order(3)]
        public async Task ApproveReview()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            var reviews = await service.GetReviews();
            var review = reviews[1];
            //Act
            await service.ApproveReview(review);
            var approvedReview = context.Reviews.Where(a => a.Approved == true).ToList();
            //Assert
            Assert.IsNotNull(approvedReview);
            Assert.That(approvedReview, Has.Count.EqualTo(1));
        }

        [Test, Order(4)]
        public async Task RejectReview()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            var reviews = await service.GetReviews();
            var review = reviews[0];
            //Act
            await service.RejectReview(review);
            var approvedReview = context.Reviews.Where(a => a.Approved == false).ToList();
            //Assert
            Assert.IsNotNull(approvedReview);
            Assert.That(approvedReview, Has.Count.EqualTo(1));
        }

        [Test, Order(5)]
        public async Task GetApprovedReviews()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            //Act
            var approvedReviews = await service.GetApprovedGameReviews(testGame.GameId);
            //Assert
            Assert.IsNotNull(approvedReviews);
            Assert.That(approvedReviews, Has.Count.EqualTo(1));
        }

        [Test, Order(6)]
        public async Task GetReviewsByUser()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            //Act
            var userReviews = await service.GetReviewsByUser(testUser.Id);
            //Assert
            Assert.IsNotNull(userReviews);
            Assert.That(userReviews, Has.Count.EqualTo(1));
        }

        [Test, Order(7)]
        public async Task GetAverage()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            //Act
            var average = await service.GetAverageRating(testGame.GameId);
            //Assert
            Assert.IsNotNull(average);
            Assert.AreEqual(3, average);
        }

        [Test, Order(8)]
        public async Task RemoveReviews()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            Review review = new Review()
            {
                GameId = testGame.GameId,
                UserId = testUser2.Id,
                Rating = 3,
                Description = "decent game",
                Approved = true
            };
            //Act
            await service.DeleteReview(review);
            await service.DeleteReview(testReview);
            var reviews = context.Reviews.ToList();
            //Assert
            Assert.NotNull(reviews);
            Assert.False(reviews.Any());
        }
    }
}
