using MunyaiM_Assign1.Models;
using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace MunyaiM_Assign1.Data
{
    public class EventRespository : IEventRespository
    {
        private readonly AppDbContext _EventRespository;

        public EventRespository(AppDbContext eventRespository)
        {
            _EventRespository = eventRespository;
        }

        public void AddAttendee(Attendee attendee)
        {
            _EventRespository.Add(attendee);
        }
       
        public Event GetDetails(int id)
        {
            return _EventRespository.Events.FirstOrDefault(x => x.EventId == id);
        }

        public void SaveChanges()
        {
            _EventRespository.SaveChanges();
        }

        public void UpdateAttendee(Attendee attendee)
        {
            _EventRespository.Update(attendee);
        }

        public IQueryable<Event> GetAllEvents()
        {
            return _EventRespository.Events;
        }

        public IQueryable<Attendee> GetAllAttendance()
        {
            return _EventRespository.Attendees;
        }

       
    }
}
