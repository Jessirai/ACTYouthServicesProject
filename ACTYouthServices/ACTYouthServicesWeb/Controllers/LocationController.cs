using ACTYouthServicesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACTYouthServicesWeb.Controllers
{
    public class LocationController : Controller
    {
        ServicesDatabaseHelper servicesDatabase = new ServicesDatabaseHelper();

        // GET: Location
        public ActionResult Index()
        {
            ViewBag.Message = "Service locations page.";

            return View();
        }

        public ActionResult Belconnen(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Jobs, bool? Health, bool? Legal)
        {

            var services = servicesDatabase.SearchByLocation("Belconnen", searchString, sortOrder, false, Shelter, Meals, Diversity, Family, Jobs, Health, Legal);

            return View(services);
        }

        public ActionResult Tuggeranong(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Jobs, bool? Health, bool? Legal)
        {
            var services = servicesDatabase.SearchByLocation("Tuggeranong", searchString, sortOrder, false, Shelter, Meals, Diversity, Family, Jobs, Health, Legal);

            return View(services);
        }

        public ActionResult Civic(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Jobs, bool? Health, bool? Legal)
        {
            var services = servicesDatabase.SearchByLocation("Civic", searchString, sortOrder, false, Shelter, Meals, Diversity, Family, Jobs, Health, Legal);

            return View(services);
        }

        public ActionResult Woden(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Jobs, bool? Health, bool? Legal)
        {
            var services = servicesDatabase.SearchByLocation("Woden", searchString, sortOrder, false, Shelter, Meals, Diversity, Family, Jobs, Health, Legal);

            return View(services);
        }
        public ActionResult Gungahlin(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Jobs, bool? Health, bool? Legal)
        {
            var services = servicesDatabase.SearchByLocation("Gungahlin", searchString, sortOrder, false, Shelter, Meals, Diversity, Family, Jobs, Health, Legal);

            return View(services);
        }
    }
}