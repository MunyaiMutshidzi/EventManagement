using MunyaiM_Assign1.Models;

namespace MunyaiM_Assign1.Data
{
    public interface IEventRespository
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int eventId);
        Event GetEventWithAttendees(int eventId);
        void AddAttendee(Attendee attendee);
        void SaveChanges();
    }
}
