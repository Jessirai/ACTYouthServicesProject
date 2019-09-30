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
        /*import database*/
        private ACTYouthServicesDatabaseEntities db = new ACTYouthServicesDatabaseEntities();
        /*allow lat lng to be called from front end.*/


        public ActionResult Index(string sortOrder, string searchString)
        {
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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
        /*Get Service types page*/
        public ActionResult Type()
        {
            ViewBag.Message = "Service types page.";

            return View();
        }
        /*Get Service Locations page*/
        public ActionResult Location()
        {
            ViewBag.Message = "Service locations page.";

            return View();
        }
        /*----------------------------------------------------------*/
        /*Service Locations-----------------------------------------*/
        /*----------------------------------------------------------*/
        public ActionResult Belconnen(string sortOrder, string searchString)
        {
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
        public ActionResult Tuggeranong(string sortOrder, string searchString)
        {
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
        public ActionResult Civic(string sortOrder, string searchString)
        {
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
        public ActionResult Woden(string sortOrder, string searchString)
        {
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
        public ActionResult Gungahlin(string sortOrder, string searchString)
        {
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
        /*----------------------------------------------------------*/
        /*Service Categories----------------------------------------*/
        /*----------------------------------------------------------*/
        public ActionResult Shelter(string sortOrder, string searchString)
        {
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

        public ActionResult Meals(string sortOrder, string searchString)
        {
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
        public ActionResult Health(string sortOrder, string searchString)
        {
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
        public ActionResult Diversity(string sortOrder, string searchString)
        {
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
        public ActionResult Jobs(string sortOrder, string searchString)
        {
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
        public ActionResult Legal(string sortOrder, string searchString)
        {
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
        public ActionResult Family(string sortOrder, string searchString)
        {
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
    }
}