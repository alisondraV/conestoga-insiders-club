using System;
using System.ComponentModel.DataAnnotations;
using ConestogaInsidersClub.Data.Models;

namespace ConestogaInsidersClub.Pages.ViewModels
{
    public class EventVM
    {
        public EventVM(Event _event)
        {
            EventName = _event.EventName;
            Description = _event.Description;
            Location = _event.Location;
            Capacity = _event.Capacity;
        }
        [Required(ErrorMessage = "Event Name is required")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Event Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Event Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Event Capacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Event Capacity should be greater than 0")]
        public int Capacity { get; set; }

        public Event ToModel(Event _event)
        {
            _event.EventName = EventName;
            _event.Description = Description;
            _event.Location = Location;
            _event.Capacity = Capacity;

            return _event;
        }
    }
}
