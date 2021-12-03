using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConestogaInsidersClub.Data.Models
{
    public class Event
    {
        public Event()
        {
            Attendees = new HashSet<ApplicationUser>();
        }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public ICollection<ApplicationUser> Attendees { get; set; }
    }
}
