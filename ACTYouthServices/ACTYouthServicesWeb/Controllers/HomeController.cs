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
        public ActionResult Belconnen(string sortOrder, string searchString, bool? Shelter, 
            bool? Meals, bool? Diversity, bool? Family, bool? Job, bool? Health, bool? Legal)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*code for shelter filter*/
            if (Shelter == true)
            {
                services = services.Where(s => s.Shelter.Equals(true));
            }
            /*code for meals and foof filter*/
            if (Meals == true)
            {
                services = services.Where(s => s.Food.Equals(true));
            }
            /*code for diversity filter*/
            if (Diversity == true)
            {
                services = services.Where(s => s.Diversity.Equals(true));
            }
            /*code for family filter*/
            if (Family== true)
            {
                services = services.Where(s => s.Family.Equals(true));
            }
            /*code for Jobs filter*/
            if (Job == true)
            {
                services = services.Where(s => s.Job.Equals(true));
            }
            /*code for legal filter*/
            if (Legal == true)
            {
                services = services.Where(s => s.Legal.Equals(true));
            }
            /*code for health filter*/
            if (Health == true)
            {
                services = services.Where(s => s.Health.Equals(true));
            }
            /*code to check if matches search*/
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
            /*code to implement dynamic markers*/

            return View(services.ToList());
        }
        public ActionResult Tuggeranong(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Job, bool? Health, bool? Legal)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*code for shelter filter*/
            if (Shelter == true)
            {
                services = services.Where(s => s.Shelter.Equals(true));
            }
            /*code for meals and foof filter*/
            if (Meals == true)
            {
                services = services.Where(s => s.Food.Equals(true));
            }
            /*code for diversity filter*/
            if (Diversity == true)
            {
                services = services.Where(s => s.Diversity.Equals(true));
            }
            /*code for family filter*/
            if (Family == true)
            {
                services = services.Where(s => s.Family.Equals(true));
            }
            /*code for Jobs filter*/
            if (Job == true)
            {
                services = services.Where(s => s.Job.Equals(true));
            }
            /*code for legal filter*/
            if (Legal == true)
            {
                services = services.Where(s => s.Legal.Equals(true));
            }
            /*code for health filter*/
            if (Health == true)
            {
                services = services.Where(s => s.Health.Equals(true));
            }
            /*code to check if matches search*/
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
        public ActionResult Civic(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Job, bool? Health, bool? Legal)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*code for shelter filter*/
            if (Shelter == true)
            {
                services = services.Where(s => s.Shelter.Equals(true));
            }
            /*code for meals and foof filter*/
            if (Meals == true)
            {
                services = services.Where(s => s.Food.Equals(true));
            }
            /*code for diversity filter*/
            if (Diversity == true)
            {
                services = services.Where(s => s.Diversity.Equals(true));
            }
            /*code for family filter*/
            if (Family == true)
            {
                services = services.Where(s => s.Family.Equals(true));
            }
            /*code for Jobs filter*/
            if (Job == true)
            {
                services = services.Where(s => s.Job.Equals(true));
            }
            /*code for legal filter*/
            if (Legal == true)
            {
                services = services.Where(s => s.Legal.Equals(true));
            }
            /*code for health filter*/
            if (Health == true)
            {
                services = services.Where(s => s.Health.Equals(true));
            }
            /*code to check if matches search*/
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
        public ActionResult Woden(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Job, bool? Health, bool? Legal)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*code for shelter filter*/
            if (Shelter == true)
            {
                services = services.Where(s => s.Shelter.Equals(true));
            }
            /*code for meals and foof filter*/
            if (Meals == true)
            {
                services = services.Where(s => s.Food.Equals(true));
            }
            /*code for diversity filter*/
            if (Diversity == true)
            {
                services = services.Where(s => s.Diversity.Equals(true));
            }
            /*code for family filter*/
            if (Family == true)
            {
                services = services.Where(s => s.Family.Equals(true));
            }
            /*code for Jobs filter*/
            if (Job == true)
            {
                services = services.Where(s => s.Job.Equals(true));
            }
            /*code for legal filter*/
            if (Legal == true)
            {
                services = services.Where(s => s.Legal.Equals(true));
            }
            /*code for health filter*/
            if (Health == true)
            {
                services = services.Where(s => s.Health.Equals(true));
            }
            /*code to check if matches search*/
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
        public ActionResult Gungahlin(string sortOrder, string searchString, bool? Shelter,
            bool? Meals, bool? Diversity, bool? Family, bool? Job, bool? Health, bool? Legal)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*code for shelter filter*/
            if (Shelter == true)
            {
                services = services.Where(s => s.Shelter.Equals(true));
            }
            /*code for meals and foof filter*/
            if (Meals == true)
            {
                services = services.Where(s => s.Food.Equals(true));
            }
            /*code for diversity filter*/
            if (Diversity == true)
            {
                services = services.Where(s => s.Diversity.Equals(true));
            }
            /*code for family filter*/
            if (Family == true)
            {
                services = services.Where(s => s.Family.Equals(true));
            }
            /*code for Jobs filter*/
            if (Job == true)
            {
                services = services.Where(s => s.Job.Equals(true));
            }
            /*code for legal filter*/
            if (Legal == true)
            {
                services = services.Where(s => s.Legal.Equals(true));
            }
            /*code for health filter*/
            if (Health == true)
            {
                services = services.Where(s => s.Health.Equals(true));
            }
            /*code to check if matches search*/
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
        public ActionResult Shelter(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*filter by location*/
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            if (Belconnen == true)
            {
                services = services.Where(s => s.Location.Contains("Belconnen"));
            }
            if (Gungahlin == true)
            {
                services = services.Where(s => s.Location.Contains("Gunghalin"));
            }
            if (Woden == true)
            {
                services = services.Where(s => s.Location.Contains("Woden"));
            }
            if (Tuggeranong == true)
            {
                services = services.Where(s => s.Location.Contains("Tuggeranong"));
            }
            if (Civic == true)
            {
                services = services.Where(s => s.Location.Contains("Civic"));
            }
            /*sort order for listing*/
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

        public ActionResult Meals(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*filter by location*/
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            if (Belconnen == true)
            {
                services = services.Where(s => s.Location.Contains("Belconnen"));
            }
            if (Gungahlin == true)
            {
                services = services.Where(s => s.Location.Contains("Gunghalin"));
            }
            if (Woden == true)
            {
                services = services.Where(s => s.Location.Contains("Woden"));
            }
            if (Tuggeranong == true)
            {
                services = services.Where(s => s.Location.Contains("Tuggeranong"));
            }
            if (Civic == true)
            {
                services = services.Where(s => s.Location.Contains("Civic"));
            }
            /*sort order for listing*/
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
        public ActionResult Health(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*filter by location*/
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            if (Belconnen == true)
            {
                services = services.Where(s => s.Location.Contains("Belconnen"));
            }
            if (Gungahlin == true)
            {
                services = services.Where(s => s.Location.Contains("Gunghalin"));
            }
            if (Woden == true)
            {
                services = services.Where(s => s.Location.Contains("Woden"));
            }
            if (Tuggeranong == true)
            {
                services = services.Where(s => s.Location.Contains("Tuggeranong"));
            }
            if (Civic == true)
            {
                services = services.Where(s => s.Location.Contains("Civic"));
            }
            /*sort order for listing*/
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
        public ActionResult Diversity(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            /*filter by location*/
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            if (Belconnen == true)
            {
                services = services.Where(s => s.Location.Contains("Belconnen"));
            }
            if (Gungahlin == true)
            {
                services = services.Where(s => s.Location.Contains("Gunghalin"));
            }
            if (Woden == true)
            {
                services = services.Where(s => s.Location.Contains("Woden"));
            }
            if (Tuggeranong == true)
            {
                services = services.Where(s => s.Location.Contains("Tuggeranong"));
            }
            if (Civic == true)
            {
                services = services.Where(s => s.Location.Contains("Civic"));
            }
            /*sort order for listing*/
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
        public ActionResult Jobs(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*filter by location*/
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            if (Belconnen == true)
            {
                services = services.Where(s => s.Location.Contains("Belconnen"));
            }
            if (Gungahlin == true)
            {
                services = services.Where(s => s.Location.Contains("Gunghalin"));
            }
            if (Woden == true)
            {
                services = services.Where(s => s.Location.Contains("Woden"));
            }
            if (Tuggeranong == true)
            {
                services = services.Where(s => s.Location.Contains("Tuggeranong"));
            }
            if (Civic == true)
            {
                services = services.Where(s => s.Location.Contains("Civic"));
            }
            /*sort order for listing*/
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
        public ActionResult Legal(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*filter by location*/
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            if (Belconnen == true)
            {
                services = services.Where(s => s.Location.Contains("Belconnen"));
            }
            if (Gungahlin == true)
            {
                services = services.Where(s => s.Location.Contains("Gunghalin"));
            }
            if (Woden == true)
            {
                services = services.Where(s => s.Location.Contains("Woden"));
            }
            if (Tuggeranong == true)
            {
                services = services.Where(s => s.Location.Contains("Tuggeranong"));
            }
            if (Civic == true)
            {
                services = services.Where(s => s.Location.Contains("Civic"));
            }
            /*sort order for listing*/
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
        public ActionResult Family(string sortOrder, string searchString, bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            var services = from s in db.Services
                           select s;
            /*filter by location*/
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            if (Belconnen == true)
            {
                services = services.Where(s => s.Location.Contains("Belconnen"));
            }
            if (Gungahlin == true)
            {
                services = services.Where(s => s.Location.Contains("Gunghalin"));
            }
            if (Woden == true)
            {
                services = services.Where(s => s.Location.Contains("Woden"));
            }
            if (Tuggeranong == true)
            {
                services = services.Where(s => s.Location.Contains("Tuggeranong"));
            }
            if (Civic == true)
            {
                services = services.Where(s => s.Location.Contains("Civic"));
            }
            /*sort order for listing*/
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