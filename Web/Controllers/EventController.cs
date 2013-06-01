using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CliqueUp.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /NewEvent/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() 
        {
            return View();
        }

        public ActionResult Remove(int id)
        {
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
