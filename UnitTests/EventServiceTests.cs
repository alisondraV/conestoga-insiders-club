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
    class EventServiceTests : TestBase
    {
        private List<Event> testEvents;
        private Event testEvent;
        private ApplicationUser testUser;

        [OneTimeSetUp]
        public async Task BeforeAll()
        {

            using var context = new ApplicationDbContext(ContextOptions);

            testEvent = await SeedEntities(
                new Event()
                {
                    EventName = "Smash Bros Tournament",
                    Description = "Prize of $1",
                    Location = "Somewhere",
                    Capacity = 100
                });

            testUser = await SeedEntities(
                new ApplicationUser()
                {
                    Id = "d125",
                    UserName = "test",
                    NormalizedUserName = "TEST",
                    Email = "test@user.com"
                }
            );
        }


        //Task DeleteEvent(Event @event);


        [Test, Order(1)]
        public async Task GetEvents_ShouldGetAllEvents()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new EventService(context);

            // Act
            var events = await service.GetEvents();

            // Assert
            Assert.NotNull(events);
            Assert.That(events, Has.Count.EqualTo(1));
        }

        [Test, Order(2)]
        public async Task AddEvent_ShouldAddNewEvent()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new EventService(context);
            var _event = new Event()
            {
                EventName = "Mario Kart Tournament",
                Description = "Prize of $1",
                Location = "Somewhere",
                Capacity = 150
            };

            // Act
            await service.AddEvent(_event);
            var events = await service.GetEvents();

            // Assert
            Assert.NotNull(events);
            Assert.That(events, Has.Count.EqualTo(2));
        }

        [Test, Order(3)]
        public async Task UpdateEvent_ShouldChangeEventInfo()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new EventService(context);
            var _event = context.Events.Where(e => e.EventId == 2).FirstOrDefault();
            _event.EventName = "Street Fighter Tournament";
            // Act
            await service.UpdateEvent(_event);
            var events = await service.GetEvent(2);

            // Assert
            Assert.NotNull(events);
            Assert.That(events.EventName, Is.EqualTo("Street Fighter Tournament"));
        }
        [Test, Order(4)]
        public async Task GetEvent_ShouldGetSpecificEvent()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new EventService(context);

            // Act
            var events = await service.GetEvent(1);

            // Assert
            Assert.NotNull(events);
            Assert.That(events.EventName, Is.EqualTo(testEvent.EventName));
        }

        [Test, Order(5)]
        public async Task JoinEvent_ShouldAddUserToEvent()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new EventService(context);

            // Act
            await service.JoinEvent(1, testUser);
            var events = await service.GetEvent(1);

            // Assert
            Assert.NotNull(events);
            Assert.That(events.Attendees, Has.Count.EqualTo(1));
        }

        [Test, Order(6)]
        public async Task DeleteEvents_ShouldDeleteAllEvents()
        {
            // Arrange
            using var context = new ApplicationDbContext(ContextOptions);
            var service = new EventService(context);
            var events = await service.GetEvents();

            // Act
            foreach (var item in events)
            {
                await service.DeleteEvent(item);
            }
            events = await service.GetEvents();

            // Assert
            Assert.NotNull(events);
            Assert.That(events, Has.Count.EqualTo(0));
        }

    }
}
