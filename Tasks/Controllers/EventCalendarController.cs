using Microsoft.AspNetCore.Mvc;
using Tasks.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace Tasks.Controllers
{
    public class EventCalendarController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

        public IActionResult Index() => View();

        public JsonResult GetEvents() => new(_context.Events.AsNoTracking().ToList(), new JsonSerializerOptions());

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
                _context.Events.Update(v);
            }
            else
            {
                _context.Events.Add(e);
            }
            _context.SaveChanges();
            status = true;
            return new(status, new JsonSerializerOptions());
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
            return new(status, new JsonSerializerOptions());
        }
    }
}
