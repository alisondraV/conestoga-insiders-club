using ConestogaInsidersClub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.DataAccess
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext context;
        public EventService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task AddEvent(Event @event)
        {
            await context.Events.AddAsync(@event);
            await context.SaveChangesAsync();
        }

        public async Task DeleteEvent(Event @event)
        {
            context.Events.Remove(@event);
            await context.SaveChangesAsync();
        }

        public Task<Event> GetEvent(int eventId)
        {
            return context.Events.Include(a => a.Attendees).Where(e => e.EventId == eventId).FirstOrDefaultAsync();
        }

        public Task<List<Event>> GetEvents()
        {
            return context.Events.Include(a => a.Attendees).ToListAsync();
        }

        public async Task JoinEvent(Event @event, ApplicationUser user)
        {
            @event.Attendees.Add(user);
            context.Users.Attach(user);
            context.Update(@event);
            await context.SaveChangesAsync();
        }

        public async Task LeaveEvent(Event @event, ApplicationUser user)
        {
            @event.Attendees.Remove(user);
            context.Update(@event);
            await context.SaveChangesAsync();
        }

        public async Task UpdateEvent(Event @event)
        {
            context.Events.Update(@event);
            await context.SaveChangesAsync();
        }
    }
}
