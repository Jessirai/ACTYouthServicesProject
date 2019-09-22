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

        // GET: Index page
        public ActionResult Index()
        {
            ViewBag.Message = "Woden Services Page.";

            return View();
        }
    }
}
