using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACTYouthServicesWeb.Models
{
    public class ServicesDatabaseHelper
    {
        /*import database*/
        private actyouthservicesdb_Entities db = new actyouthservicesdb_Entities();

        public List<Service> SearchAll(string searchString) {
            var services = from s in db.Services
                           select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()) || s.Description.ToUpper().Contains(searchString.ToUpper()));
            }
            services = services.OrderByDescending(s => s.Name);
            return services.ToList();
        }

        public Service SelectServiceByName(string name)
        {
            var services = from s in db.Services
                           select s;
            if (!string.IsNullOrEmpty(name))
            {
                services = services.Where(s => s.Name.ToUpper().Equals(name.ToUpper()));
                return services.ToList().First();
            }

            return null;
        }

        public Service Find(int? id)
        {
            return db.Services.Find(id);
        }

        public List<Service> SearchByLocation(string location, string searchString, string sortby, bool asc,
            bool? Shelter, bool? Food, bool? Diversity, bool? Family, bool? Job, bool? Health, bool? Legal)
        {
            var typeList = new List<String>();
            if (Shelter.Equals(true)) typeList.Add("Shelter = 1");
            if (Food.Equals(true)) typeList.Add("Food = 1");
            if (Diversity.Equals(true)) typeList.Add("Diversity = 1");
            if (Family.Equals(true)) typeList.Add("Family = 1");
            if (Job.Equals(true)) typeList.Add("Job = 1");
            if (Health.Equals(true)) typeList.Add("Health = 1");
            if (Legal.Equals(true)) typeList.Add("Legal = 1");

            string sqlQuery = "SELECT * FROM Service WHERE Location = '" + location + "'";

            if (typeList.Any()) {
                sqlQuery += " AND (";
                sqlQuery += string.Join(" OR ", typeList);
                sqlQuery += ")";
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                sqlQuery += " AND (Name LIKE '%" + searchString + "%' OR Description LIKE '%" + searchString + "%')";
            }

            if (!string.IsNullOrEmpty(sortby)) sqlQuery += " ORDER BY " + sortby;
            else sqlQuery += " ORDER BY Name";

            if (asc.Equals(true)) sqlQuery += " ASC";
            else sqlQuery += " DESC";

            var services = db.Services.SqlQuery(sqlQuery)
                        .ToList<Service>();

            return services;
        }

        public List<Service> SearchByCategory(string category, string searchString, string sortby, bool asc,
            bool? Belconnen, bool? Woden, bool? Civic, bool? Tuggeranong, bool? Gungahlin)
        {
            var locationList = new List<String>();
            if (Belconnen.Equals(true)) locationList.Add("Location = 'Belconnen'");
            if (Woden.Equals(true)) locationList.Add("Location = 'Woden'");
            if (Civic.Equals(true)) locationList.Add("Location = 'Civic'");
            if (Tuggeranong.Equals(true)) locationList.Add("Location = 'Tuggeranong'");
            if (Gungahlin.Equals(true)) locationList.Add("Location = 'Gungahlin'");

            string sqlQuery = "SELECT * FROM Service WHERE " + category + " = 1";

            if (locationList.Any())
            {
                sqlQuery += " AND (";
                sqlQuery += string.Join(" OR ", locationList);
                sqlQuery += ")";
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                sqlQuery += " AND (Name LIKE '%" + searchString + "%' OR Description LIKE '%" + searchString + "%')";
            }

            if (!string.IsNullOrEmpty(sortby)) sqlQuery += " ORDER BY " + sortby;
            else sqlQuery += " ORDER BY Name";

            if (asc.Equals(true)) sqlQuery += " ASC";
            else sqlQuery += " DESC";

            var services = db.Services.SqlQuery(sqlQuery)
                        .ToList<Service>();

            return services;
        }
    }
}