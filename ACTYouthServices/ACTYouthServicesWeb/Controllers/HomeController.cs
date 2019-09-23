using System;
using System.Collections.Generic;
using System.Data;
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

        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult Belconnen()
        {
            {
                return View(db.Services.ToList());
            }
        }
        /*----------------------------------------------------------*/
        /*Service Categories----------------------------------------*/
        /*----------------------------------------------------------*/
        public ActionResult Shelter()
        {
            {
                return View(db.Services.ToList());
            }
        }
        public ActionResult Meals()
        {
            {
                return View(db.Services.ToList());
            }
        }
    }
}