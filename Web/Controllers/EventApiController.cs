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

namespace CliqueUp.Controllers
{
    public class EventApiController : ApiController
    {
        private CliqueUpContext db = new CliqueUpContext();

        // GET api/EventApi
        public IEnumerable<CategoryEvent> GetEvents()
        {
            return db.CategoryEvents.AsEnumerable<CategoryEvent>();
        }

        // GET api/EventApi/5
        public CategoryEvent GetEvent(Guid id)
        {
            CategoryEvent ev = db.CategoryEvents.Find(id);
            if (ev == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ev;
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

        // POST api/EventApi
        public HttpResponseMessage PostEvent(CategoryEvent ev)
        {
            if (ModelState.IsValid)
            {
                db.CategoryEvents.Add(ev);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ev);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ev.Id }));
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