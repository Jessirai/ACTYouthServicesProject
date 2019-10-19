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
    public class ServicesController : Controller
    {
        //private actyouthservicesdb_Entities db = new actyouthservicesdb_Entities();
        ServicesDatabaseHelper servicesDatabase = new ServicesDatabaseHelper();

        // GET: Services
        public ActionResult Index(int? id, string name)
        {
            if (id == null && string.IsNullOrEmpty(name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else if (id != null)
            {
                Service service = servicesDatabase.Find(id);
                if (service == null)
                {
                    return HttpNotFound();
                }
                return View(service);
            }
            else {
                Service service = servicesDatabase.SelectServiceByName(name);
                if (service == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(service);
                }
            }
            
        }
    }
}
