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

        public IActionResult Confirmation()
        {
           
            return View(_eventRespository.GetAllAttendance());
        }

        [HttpGet]
        public IActionResult Register() 
        { 
          return View(new Attendee());
        }

        [HttpPost]
        public IActionResult Register(Attendee attendee,Event @event)
        {
           
            if(!ModelState.IsValid)
            {
                try
                {
                    _eventRespository.AddAttendee(attendee);
                    @event.EventMaxAttendees++;
                    _eventRespository.SaveChanges();
                    _eventRespository.UpdateAttendee(attendee);
                    return RedirectToAction("Confirmation");
                }
                catch(DbUpdateException ex)
                {
                  ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
   
            return RedirectToAction("index","Event");
        }
    }
}
