using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CliqueUpModel.Model;
using Models.Model;
using System.Collections.Specialized;
using DataServiceLayer.Implementation;
using System.Net.Http.Formatting;
using System.Web.Security;

namespace CliqueUp.Controllers
{
    public class EventApiController : ApiController
    {
        EventService eventService = new EventService();

        private CliqueUpContext db = new CliqueUpContext();

        // GET api/EventApi
        public string GetEvents()
        {
            var tempVal = "";
            var events = db.CategoryEvents.AsEnumerable<CategoryEvent>();
            
            var tblBegin = "<table class='table table-striped table-condensed'>"+
                        "<thead><tr><th>Event</th></tr></thead><tbody>" ; 
            var tblEnd = "<tbody></table>";
            tempVal+=tblBegin;
            
            foreach (CategoryEvent cEvent  in events)
            {
                tempVal += String.Format("<script>addMarkerToMap({0}, {1}, {2})</script>", "map", cEvent.Latitude, cEvent.Longitude);
                tempVal += "<tr><td><a href='#' onclick=\"popEvent('" + cEvent.Id + "')\"  >" + cEvent.Title + "</td></tr>";
            }
            tempVal += tblEnd;
            return tempVal;
        }

        // GET api/EventApi/5
        public string GetEvent(Guid id)
        {
            var retval = "";
            CategoryEvent ev = db.CategoryEvents.Find(id);
            //if (ev == null)
            //{
            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            //}
            retval += "<h3>" + ev.Title + "<h3>";
            retval += "<ul>";
            retval += "<li><label>Description:</label>" + ev.Description + "</li>";
            retval += "<li><label>Created:</label>" + ev.CreateOn.ToString() + "</li>";
            retval += "<li><label></label>" + ev.StartTime.ToString() + "</li>";
            retval += "<li><label></label>" + ev.EndTime.ToString() + "</li>";
            retval += "</ul>";
            return retval;
        }

        // PUT api/EventApi/5
        public HttpResponseMessage PutEvent(Guid id, CategoryEvent ev)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != ev.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(ev).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //POST api/EventApi/
        public HttpResponseMessage PostEvent(FormDataCollection formData)
        {
            var currUser = Membership.GetUser();
            
            var name = formData.Get("evName");
            var locData = formData.Get("evLoc");
            var loc = eventService.ReverseGeocode(locData);
            var poc = formData.Get("pocIn");
            var desc = formData.Get("descIn");


            var ev = new CategoryEvent()
            {
                Title = name,
                Description = desc,
                Latitude = loc.Latitude,
                Longitude = loc.Longitude,
                CreateOn = DateTime.Now,
                StartTime = DateTime.Now,
                EndTime =  DateTime.Now
            };
            //evName
            //evLoc
            //pocIn
            if (ModelState.IsValid)
            {
                db.CategoryEvents.Add(ev);
                db.SaveChanges();
                var user = db.Users.Where(x => x.Id==ev.Id).FirstOrDefault();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ev);
                response.Headers.Location = new Uri(Url.Link("Event", new { userId =user.Id = ev.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/EventApi/5
        public HttpResponseMessage DeleteEvent(Guid id)
        {
            CategoryEvent ev = db.CategoryEvents.Find(id);
            if (ev == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.CategoryEvents.Remove(ev);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ev);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}