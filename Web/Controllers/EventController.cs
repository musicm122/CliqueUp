using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CliqueUp.Models;
using DataServiceLayer.Implementation;

namespace CliqueUp.Controllers
{
    public class EventController : Controller
    {
        // GET: /NewEvent/
        EventService _eventService { get; set; }
        public EventController()
        {
            _eventService = new EventService(); 
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Create(NewEventModel model) 
        {
            if (ModelState.IsValid)
            {
                _eventService.CreateEvent(model.Title, model.Description, model.Categories, model.EventStart, model.EventEnd, model.Latitude, model.Longititude);
                ViewBag.StatusMessage = "Your event has been created successfully.";
            }
            else 
            {
                ModelState.AddModelError("Error", "Invalid Event Submitted . Please Check your form.");
                return View(model);
            }
            return View();
        }

        public ActionResult Close(Guid userId, Guid eventId)
        {
            if (ModelState.IsValid) 
            {
                _eventService.CloseEvent(userId, eventId);
            }
            else
            {
                ModelState.AddModelError("Error", "Invalid info.");
                return View();
            }
            return View();
        }
        
        //public ActionResult Update(int id, model)
        //{
        //    return View();
        //}
        
        public ActionResult Delete()
        {
            return View();
        }


    }
}
