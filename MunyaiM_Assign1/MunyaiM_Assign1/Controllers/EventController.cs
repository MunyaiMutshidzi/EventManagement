using Microsoft.AspNetCore.Mvc;
using MunyaiM_Assign1.Data;
using MunyaiM_Assign1.Models;

namespace MunyaiM_Assign1.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRespository _eventRespository;

        public EventController(IEventRespository eventRespository)
        {
            this._eventRespository = eventRespository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var events = _eventRespository.GetAllEvents().
                         OrderBy(e => e.EventStartDate);
            return View(events);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var events = _eventRespository.GetDetails(id);
            if(events == null) { return NotFound(); }
            return View(events);
        }
    }
}
