using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACTYouthServicesWeb.Models;


namespace ACTYouthServicesWeb.Controllers
{
    public class HomeController : Controller
    {
        /*google maps experiment page*/
        public ActionResult GMapsAPITest()
        {
            return View();
        }
        /*import database*/
        private actyouthservicesdb_Entities db = new actyouthservicesdb_Entities();
        

        /*end of google maps experiment page*/
        public ActionResult Index(string sortOrder, string searchString)
        {
            /*
            /*code for search and sort/filters*/
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    services = services.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    services = services.OrderBy(s => s.Description);
                    break;
                default:
                    services = services.OrderBy(s => s.Name);
                    break;
            }
            return View(services.ToList());
        }
        /*services menu page, where user can choose to find by location or type*/
        public ActionResult ServicesMenu()
        {
            ViewBag.Message = "Services page.";

            return View();
        }

        public ActionResult About(string sortOrder, string searchString)
        {
            /*code for search and sort/filters*/
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    services = services.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    services = services.OrderBy(s => s.Description);
                    break;
                default:
                    services = services.OrderBy(s => s.Name);
                    break;
            }
            /*get map*/
            actyouthservicesdb_Entities DE = new actyouthservicesdb_Entities();
            return View(services.ToList());
        }

        /*controller method to search on map*/
        [HttpPost]
        public ActionResult Search(string Services)
        {
            actyouthservicesdb_Entities DE = new actyouthservicesdb_Entities();
            var result = DE.Services.Where(x => x.Name.StartsWith(Services)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /*Interstate page*/
        public ActionResult Interstate()
        {
            ViewBag.Message = "Interstate page.";

            return View();
        }

        /* GET: Services/Details/N - dynamic service page*/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
       
    }
}