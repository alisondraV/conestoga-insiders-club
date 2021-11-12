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
        private Review testReview;
        private List<ApplicationUser> users;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {

            using var context = new ApplicationDbContext(ContextOptions);

            var genre = new GameGenre
            {
                Name = "Indie"
            };

            testGame = await SeedEntities(
                new Game
                {
                    GameId = 1,
                    Name = "Age of Empires IV",
                    Description = "RTS Game",
                    GenreNavigation = genre
                });

            users = await SeedEntities(
                new ApplicationUser()
                {
                    Id = "d123",
                    UserName = "test",
                    NormalizedUserName = "TEST",
                    Email = "test@user.com"
                },
                new ApplicationUser()
                {
                    Id = "d124",
                    UserName = "fake",
                    NormalizedUserName = "FAKE",
                    Email = "fake@user.com"
                }
            );

            testReview = await SeedEntities(
                new Review()
                {
                    GameId = testGame.GameId,
                    UserId = users[0].Id,
                    Rating = 5,
                    Description = "good game",
                    Approved = null
                });

            await context.SaveChangesAsync();
        }

        [Test, Order(1)]
        public async Task GetReviews_GetTheReviewThatHasNotBeenApproved()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            //Act
            var reviews = await service.GetReviewsAwaitingApproval();
            //Assert
            Assert.IsNotNull(reviews);
            Assert.IsNull(reviews[0].Approved);
            Assert.That(reviews, Has.Count.EqualTo(1));
        }

        [Test, Order(2)]
        public async Task AddReviews_ShouldAddNewReview()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            Review review = new Review()
            {
                GameId = testGame.GameId,
                UserId = users[1].Id,
                Rating = 3,
                Description = "decent game",
                Approved = null
            };
            //Act
            await service.AddReview(review);
            var reviews = await service.GetReviewsAwaitingApproval();
            //Assert
            Assert.IsNotNull(reviews);
            Assert.That(reviews, Has.Count.EqualTo(2));
        }

        [Test, Order(3)]
        public async Task ApproveReview_ShouldApproveTheReview()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            var reviews = await service.GetReviewsAwaitingApproval();
            var review = reviews[1];
            //Act
            await service.ApproveReview(review);
            var approvedReview = context.Reviews.Where(a => a.Approved == true).ToList();
            //Assert
            Assert.IsNotNull(approvedReview);
            Assert.That(approvedReview, Has.Count.EqualTo(1));
        }

        [Test, Order(4)]
        public async Task RejectReview_ShouldRejectTheOtherReview()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            var reviews = await service.GetReviewsAwaitingApproval();
            var review = reviews[0];
            //Act
            await service.RejectReview(review);
            var approvedReview = context.Reviews.Where(a => a.Approved == false).ToList();
            //Assert
            Assert.IsNotNull(approvedReview);
            Assert.That(approvedReview, Has.Count.EqualTo(1));
        }

        [Test, Order(5)]
        public async Task GetRejectedReviews_ShouldGetListOfRejectedReviews()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            //Act
            var rejectedReviews = await service.GetRejectedReviews();
            //Assert
            Assert.IsNotNull(rejectedReviews);
            Assert.That(rejectedReviews, Has.Count.EqualTo(1));
        }

        [Test, Order(6)]
        public async Task GetApprovedReviews_ShouldGetAListOfApprovedReviews()
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

        [Test, Order(7)]
        public async Task GetReviewsByUser_ShouldGetTheReviewsMadeByUser()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            //Act
            var userReviews = await service.GetReviewsByUser(users[0].Id);
            //Assert
            Assert.IsNotNull(userReviews);
            Assert.That(userReviews, Has.Count.EqualTo(1));
        }

        [Test, Order(8)]
        public async Task GetAverage_GetTheAverageRatingOfTheGame()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            //Act
            var average = await service.GetAverageRating(testGame.GameId);
            //Assert
            Assert.IsNotNull(average);
            Assert.That(average, Is.EqualTo(3).Within(0.5));
        }

        [Test, Order(9)]
        public async Task RemoveReviews_ShouldRemoveTheReviews()
        {
            //Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new ReviewService(context);
            Review review = new Review()
            {
                GameId = testGame.GameId,
                UserId = users[1].Id,
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
