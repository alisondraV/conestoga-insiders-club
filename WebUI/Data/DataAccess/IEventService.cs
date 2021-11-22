using ConestogaInsidersClub.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    interface IEventService
    {
        Task AddEvent(Event @event);
        Task DeleteEvent(Event @event);
        Task UpdateEvent(Event @event);
        Task<Event> GetEvent(int eventId);
        Task<List<Event>> GetEvents();
        Task JoinEvent(Event @event, ApplicationUser user);

    }
}
