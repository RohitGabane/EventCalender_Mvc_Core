using EventCalender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EventCalender.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventDbContext _dbContext;
        public HomeController(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetEvents()
        {   
                List<Event> events = _dbContext.Event.ToList();
                return new JsonResult(events);       
        }

        [HttpPost]
        public JsonResult SaveEvent([FromBody] Event e)
        {
            var status = false;
            try
            {
                if (e.EventID > 0)
                {
                    // Update the event
                    var existingEvent = _dbContext.Event.Find(e.EventID);
                    if (existingEvent != null)
                    {
                        existingEvent.Subject = e.Subject;
                        existingEvent.StartDate = e.StartDate;
                        existingEvent.EndDate = e.EndDate;
                        existingEvent.Description = e.Description;
                        existingEvent.ThemeColor = e.ThemeColor;
                        existingEvent.IsFullDay = e.IsFullDay;

                        _dbContext.Entry(existingEvent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                }
                else
                {
                    // Add a new event
                    _dbContext.Event.Add(e);
                }

                _dbContext.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }

            return new JsonResult(new { status = status });
        }

        [HttpPost]
        //DeleteEvent
        public JsonResult DeleteEvent(int EventID)

        {


            var status = false;
            try
            {
                var existingEvent = _dbContext.Event.Find(EventID);

                if (existingEvent != null)
                {
                    _dbContext.Event.Remove(existingEvent);
                    _dbContext.SaveChanges();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }

            return new JsonResult(new { status = status });
        }
     

    }
}
