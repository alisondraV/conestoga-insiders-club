using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class EventService : IEventService
    {
        public Task AddEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEvents()
        {
            throw new NotImplementedException();
        }

        public Task JoinEvent(Event @event, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEvent(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
