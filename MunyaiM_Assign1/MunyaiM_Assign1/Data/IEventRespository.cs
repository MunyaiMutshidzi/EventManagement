using MunyaiM_Assign1.Models;

namespace MunyaiM_Assign1.Data
{
    public interface IEventRespository
    {
        IQueryable<Event> GetAllEvents();
        IQueryable<Attendee> GetAllAttendance();
        Event GetDetails(int id);
        void AddAttendee(Attendee attendee);
        void UpdateAttendee(Attendee attendee);
        void SaveChanges();
    }
}
