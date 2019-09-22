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
        private ACTYouthServiceDatabaseEntities1 db = new ACTYouthServiceDatabaseEntities1();

        // GET: Services, sorted by search term

        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParm = sortOrder == "Name" ? "Description" : "ServiceID";
            var Services = from s in db.Services
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Services = Services.Where(s => s.Description.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    Services = Services.OrderByDescending(s => s.Description);
                    break;
                case "Description":
                    Services = Services.OrderBy(s => s.ServiceID);
                    break;
                case "ServiceID":
                    Services = Services.OrderByDescending(s => s.ServiceID);
                    break;
                default:
                    Services = Services.OrderBy(s => s.Description);
                    break;
            }

            return View(Services.ToList());
        }
        /*ServicesMenu Page*/
        public ActionResult ServicesMenu()
        {
            ViewBag.Message = "Services Menu Page.";

            return View();
        }
        /*ServicesType Page*/
        public ActionResult ServicesType()
        {
            ViewBag.Message = "Services Type Page.";

            return View();
        }
        /*ServicesLocation Page*/
        public ActionResult ServicesLocation()
        {
            ViewBag.Message = "Services Location Page.";

            return View();
        }
        /*belconnen services*/
        public ActionResult Belconnen()
        {
            ViewBag.Message = "Belconnen Services Page.";

            return View();
        }
        /*woden services*/
        public ActionResult Woden()
        {
            ViewBag.Message = "Woden Services Page.";

            return View();
        }
        /*gungahlin services*/
        public ActionResult Gungahlin()
        {
            ViewBag.Message = "Gungahlin Services Page.";

            return View();
        }
        /*tuggeranong services*/
        public ActionResult Tuggeranong()
        {
            ViewBag.Message = "Tuggeranong Services Page.";

            return View();
        }
        /*civic services*/
        public ActionResult Civic()
        {
            ViewBag.Message = "Civic Services Page.";

            return View();
        }
        /*Get meals and food services*/
        public ActionResult MealsFood()
        {
            ViewBag.Message = "Meals and food page.";

            return View();
        }
        /*Get inlcusion and diversity services*/
        public ActionResult InclusionDiversity()
        {
            ViewBag.Message = "Inclusion and diversity services.";

            return View();
        }
        /*Get health and wellbeing services*/
        public ActionResult HealthWellbeing()
        {
            ViewBag.Message = "Health and Wellbeing page";

            return View();
        }
        /*Get jobs and employment services*/
        public ActionResult JobsEmployment()
        {
            ViewBag.Message = "Jobs and employment services";

            return View();
        }
        //GET: Shelter Services
        public ViewResult Shelter(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParm = sortOrder == "Name" ? "Description" : "ServiceID";
            var Services = from s in db.Services
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Services = Services.Where(s => s.Location.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    Services = Services.OrderByDescending(s => s.Description);
                    break;
                case "Description":
                    Services = Services.OrderBy(s => s.ServiceID);
                    break;
                case "ServiceID":
                    Services = Services.OrderByDescending(s => s.ServiceID);
                    break;
                default:
                    Services = Services.OrderBy(s => s.Description);
                    break;
            }

            return View(Services.ToList());
        }
        //GET: Health Services
        public ViewResult Health(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParm = sortOrder == "Name" ? "Description" : "ServiceID";
            var Services = from s in db.Services
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Services = Services.Where(s => s.Location.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    Services = Services.OrderByDescending(s => s.Description);
                    break;
                case "Description":
                    Services = Services.OrderBy(s => s.ServiceID);
                    break;
                case "ServiceID":
                    Services = Services.OrderByDescending(s => s.ServiceID);
                    break;
                default:
                    Services = Services.OrderBy(s => s.Description);
                    break;
            }

            return View(Services.ToList());
        }
        //GET: Food Services
        public ViewResult Food(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParm = sortOrder == "Name" ? "Description" : "ServiceID";
            var Services = from s in db.Services
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Services = Services.Where(s => s.Location.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    Services = Services.OrderByDescending(s => s.Description);
                    break;
                case "Description":
                    Services = Services.OrderBy(s => s.ServiceID);
                    break;
                case "ServiceID":
                    Services = Services.OrderByDescending(s => s.ServiceID);
                    break;
                default:
                    Services = Services.OrderBy(s => s.Description);
                    break;
            }

            return View(Services.ToList());
        }
        //GET: Legal Services
        public ViewResult LegalFinancial(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParm = sortOrder == "Name" ? "Description" : "ServiceID";
            var Services = from s in db.Services
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Services = Services.Where(s => s.Location.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    Services = Services.OrderByDescending(s => s.Description);
                    break;
                case "Description":
                    Services = Services.OrderBy(s => s.ServiceID);
                    break;
                case "ServiceID":
                    Services = Services.OrderByDescending(s => s.ServiceID);
                    break;
                default:
                    Services = Services.OrderBy(s => s.Description);
                    break;
            }

            return View(Services.ToList());
        }
        //GET: Family Services
        public ViewResult FamilyCommunity(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewBag.DateSortParm = sortOrder == "Name" ? "Description" : "ServiceID";
            var Services = from s in db.Services
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                Services = Services.Where(s => s.Location.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    Services = Services.OrderByDescending(s => s.Description);
                    break;
                case "Description":
                    Services = Services.OrderBy(s => s.ServiceID);
                    break;
                case "ServiceID":
                    Services = Services.OrderByDescending(s => s.ServiceID);
                    break;
                default:
                    Services = Services.OrderBy(s => s.Description);
                    break;
            }

            return View(Services.ToList());
        }
        /*Navigate to the page to show homelessness serivces directories for other states and territories*/
        public ActionResult Interstate()
        {
            ViewBag.Message = "Interstate directories.";

            return View();
        }




        // GET: Services/Details/5
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

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,Name,Description,Latitude,Longitude,Location,Shelter,Health,Food,Legal,Family")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,Name,Description,Latitude,Longitude,Location,Shelter,Health,Food,Legal,Family")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
