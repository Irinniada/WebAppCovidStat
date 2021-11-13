using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAppCovidStat.Models;
using PagedList;

namespace WebAppCovidStat.Controllers
{
    public class HomeController : Controller
    {
        private VacDBEntities _db = new VacDBEntities();
        // GET: Home
        public ActionResult Index(string sortOrder, string searchString)
        {
            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";            

            ViewBag.CurrentFilter = searchString;          

            var vaced = from s in _db.Vacced 
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vaced = vaced.Where(s => s.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    vaced = vaced.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    vaced = vaced.OrderBy(s => s.Birthday);
                    break;
                case "date_desc":
                    vaced = vaced.OrderByDescending(s => s.DayOfVaccination);
                    break;
                default:
                    vaced = vaced.OrderBy(s => s.LastName);
                    break;
            }
            
            return View(vaced.ToList());
        }

        // GET: /Home/Details/5 

        public ActionResult Details(int id)

        {

            return View();

        }

        //

        // GET: /Home/Create 

        public ActionResult Create()

        {          
            
            return View();
        }

        //

        // POST: /Home/Create 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Create([Bind(Exclude = "Id")] VacPerson personToAdd)
        {            
                if (ModelState.IsValid)
                {
                    _db.Vacced.Add(personToAdd);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }            
            
                return View(personToAdd);
        }

        //

        // GET: /Home/Edit/5

        public ActionResult Edit(int id)

        {

            return View();

        }

        //

        // POST: /Home/Edit/5 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(int id, FormCollection collection)

        {

            try

            {

                // TODO: Add update logic here

                return RedirectToAction("Index");

            }

            catch

            {

                return View();

            }

        }

        public ActionResult AboutCity()
        {
            string query = "SELECT COUNT(City) FROM Vacced GROUP BY City";
            //string query = "SELECT v.* FROM Vacced as v";
            //string query = "select ID,FirstName,LastName,Birthday, COUNT(CITY) OVER (PARTITION BY CITY) from VACCED ";
            using (var context = new VacDBEntities())
            {
                var blogs = context.Database.SqlQuery<int>(query).ToList();
                return View(blogs);
            }
                     
        }

    }
    public class CityCount
    {
        public int Count { get; set; }
        public string City { get; set; }
    }
}

