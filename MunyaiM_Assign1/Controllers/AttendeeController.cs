using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MunyaiM_Assign1.Data;
using MunyaiM_Assign1.Models;

namespace MunyaiM_Assign1.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IEventRespository _eventRespository;
        
        public AttendeeController(IEventRespository eventRespository)
        {
            _eventRespository = eventRespository;
        }

        [HttpGet]
        public IActionResult Register(int eventId) 
        {
            //Add an attendee to the clicked(selected) event
            var eventDetails = _eventRespository.GetEventById(eventId);
           if(eventDetails == null)
            {
                return NotFound();
            }
           var attendee = new Attendee { EventId = eventId };
          return View(attendee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Attendee attendee)
        {
           
            if(ModelState.IsValid)
            {
                try
                {
                  var Event = _eventRespository.GetEventById(attendee.EventId);
                    if ((Event != null))
                    {
                        Event.EventRegistrations++;
                    }
                    _eventRespository.AddAttendee(attendee);
                    _eventRespository.SaveChanges();
                    return RedirectToAction("Confirmation", new { eventId = attendee.EventId });
                }
                catch(DbUpdateException)
                {
                  ModelState.AddModelError("","Unable to save changes."
                      +"Try again, and if the problem persists," +
                      "contact your system administrator");
                }
            }
   
          return View(attendee);
        }
        [HttpGet]
        public IActionResult Confirmation(int eventId)
        {
            var Event = _eventRespository.GetEventWithAttendees(eventId);
            if (Event == null)
            {
                return NotFound();    
            }
            return View(Event);
        }
    }
}
