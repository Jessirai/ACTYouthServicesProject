using ACTYouthServicesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACTYouthServicesWeb.Controllers
{
    public class CategoriesController : Controller
    {
        ServicesDatabaseHelper servicesDatabase = new ServicesDatabaseHelper();

        // GET: Types
        public ActionResult Index()
        {
            ViewBag.Message = "Service categories page.";

            return View();
        }

        public ActionResult Shelter(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            var services = servicesDatabase.SearchByCategory("Shelter", searchString, sortOrder, false, Belconnen, Woden, Civic, Tuggeranong, Gungahlin);

            return View(services);
        }

        public ActionResult Meals(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            var services = servicesDatabase.SearchByCategory("Food", searchString, sortOrder, false, Belconnen, Woden, Civic, Tuggeranong, Gungahlin);

            return View(services);
        }

        public ActionResult Health(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            var services = servicesDatabase.SearchByCategory("Health", searchString, sortOrder, false, Belconnen, Woden, Civic, Tuggeranong, Gungahlin);

            return View(services);
        }

        public ActionResult Diversity(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            var services = servicesDatabase.SearchByCategory("Diversity", searchString, sortOrder, false, Belconnen, Woden, Civic, Tuggeranong, Gungahlin);

            return View(services);
        }

        public ActionResult Jobs(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            var services = servicesDatabase.SearchByCategory("Job", searchString, sortOrder, false, Belconnen, Woden, Civic, Tuggeranong, Gungahlin);

            return View(services);
        }
        public ActionResult Legal(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            var services = servicesDatabase.SearchByCategory("Legal", searchString, sortOrder, false, Belconnen, Woden, Civic, Tuggeranong, Gungahlin);

            return View(services);
        }

        public ActionResult Family(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            var services = servicesDatabase.SearchByCategory("Family", searchString, sortOrder, false, Belconnen, Woden, Civic, Tuggeranong, Gungahlin);

            return View(services);
        }
    }
}