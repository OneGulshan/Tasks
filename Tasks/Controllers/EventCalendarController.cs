using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tasks.Data;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class EventCalendarController : Controller
    {
        private readonly DataContext _context;

        public EventCalendarController(DataContext context)
        {
            _context = context;
        }        
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            var events = _context.Events.ToList();
            return new JsonResult(events, new JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            string mydate = e.Start.Date.ToString();
            var dd = DateTime.ParseExact(mydate, "d/M/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
            e.Start = dd;
            var status = false;

            if (e.EventId > 0)
            {
                var v = _context.Events.Where(a => a.EventId == e.EventId).FirstOrDefault();
                if (v != null)
                {
                    v.Subject = e.Subject;
                    v.Start = e.Start;
                    v.Description = e.Description;
                    v.ThemeColor = e.ThemeColor;
                }
            }
            else
            {
                _context.Events.Add(e);
            }
            _context.SaveChanges();
            status = true;
            return new JsonResult(status, new JsonSerializerSettings());
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            var v = _context.Events.Where(a => a.EventId == eventID).FirstOrDefault();
            if (v != null)
            {
                _context.Events.Remove(v);
                _context.SaveChanges();
                status = true;
            }
            return new JsonResult(status, new JsonSerializerSettings());
        }
    }
}
