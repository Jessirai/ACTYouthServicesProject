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
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        private actyouthservicesdb_Entities db = new actyouthservicesdb_Entities();

        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            PopulateLocationsDropDownList();
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Phone,Address,Longitude,Latitude,Email,OpeningHours,Shelter,Food,Job,Family,Legal,Diversity,Health,Location,Accessability,Clientele,Referral,MinAge,MaxAge,Cost,Languages,Website")] Service service)
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
        [HttpGet]
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

            PopulateLocationsDropDownList();
            ViewBag.SelectedLocation = service.Location;
            return View(service);
        }

        private void PopulateLocationsDropDownList()
        {
            var items = new List<SelectListItem>();

            foreach (Location location in Enum.GetValues(typeof(Location)))
            {
                items.Add(new SelectListItem()
                {
                    Text = location.ToString(),
                    Value = location.ToString(),
                });
            }
            ViewBag.LocationsEnum = items;
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var serviceToUpdate = db.Services.Find(id);
            if (TryUpdateModel(serviceToUpdate, "",
               new string[] { "Name" , "Description", "Phone", "Address", "Longitude", "Latitude", "Email", "OpeningHours", "Shelter", "Food", "Job", "Family", "Legal", "Diversity", "Health","Location",
                "Accessability", "Clientele", "Referral", "MinAge", "MaxAge", "Cost", "Languages", "Website" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(serviceToUpdate);
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