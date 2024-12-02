using Microsoft.AspNetCore.Mvc;
using MunyaiM_Assign1.Data;
using MunyaiM_Assign1.Models;

namespace MunyaiM_Assign1.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRespository _eventRepository;

        public EventController(IEventRespository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Ordered events 
            var events = _eventRepository.GetAllEvents().
                         OrderBy(e => e.EventStartDate);
            return View(events);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var events = _eventRepository.GetEventById(id);
            if(events == null) { return NotFound(); }
            return View(events);
        }
    }
}
