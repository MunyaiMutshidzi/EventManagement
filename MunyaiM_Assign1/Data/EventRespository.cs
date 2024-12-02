using MunyaiM_Assign1.Models;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace MunyaiM_Assign1.Data
{
    public class EventRepository : IEventRespository
    {
        private readonly AppDbContext _EventRepository;

        public EventRepository(AppDbContext eventRepository)
        {
            _EventRepository = eventRepository;
        }

        public void AddAttendee(Attendee attendee)
        {
            _EventRepository.Add(attendee);
        }
       
        public Event GetEventById(int eventId)
        {
            //Returns the details of the Event based on it's Id value
            return _EventRepository.Events.FirstOrDefault(x => x.EventId == eventId);
        }
        public Event GetEventWithAttendees(int evenId)
        {
            //Returns an event at the attendees
            return _EventRepository.Events
                                   .Include(e => e.Attendees)
                                   .FirstOrDefault(e => e.EventId == evenId);

        }

        public void SaveChanges()
        {
            _EventRepository.SaveChanges();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _EventRepository.Events;
        }
    }
}
