using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAppCovidStat.Models;
using PagedList;
using System.Text;
using System.Globalization;

namespace WebAppCovidStat.Controllers
{
    public class HomeController : Controller
    {
        private VacDBEntities _db = new VacDBEntities();
        // GET: Home
        public ActionResult Index(string sortOrder, string searchString)
        {
            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SortingName = String.IsNullOrEmpty(sortOrder) ? "Name_Description" : "";
            ViewBag.SortingDate = sortOrder == "Date_Enroll" ? "Date_Description" : "Date_Enroll";

            ViewBag.CurrentFilter = searchString;          

            var vaced = from s in _db.Vacced 
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                vaced = vaced.Where(s => s.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name_Description":
                    vaced = vaced.OrderByDescending(s => s.LastName);
                    break;
                case "Date_Enroll":
                    vaced = vaced.OrderBy(s => s.DayOfVaccination);
                    break;
                case "Date":
                    vaced = vaced.OrderBy(s => s.DayOfVaccination);
                    break;
                case "Date_Description":
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
            var vaced = _db.Database.SqlQuery<StatInfo>("SELECT City AS Name, COUNT(*) AS Count FROM Vacced GROUP BY City ORDER BY Count DESC").ToList();            
            return View(vaced);                                 
        }

        public ActionResult AboutVaccineTypes()
        {
            var vaced = _db.Database.SqlQuery<StatInfo>("SELECT Vaccine AS Name, COUNT(*) AS Count FROM Vacced GROUP BY Vaccine ORDER BY Count DESC").ToList();
            return View(vaced);
        }

        public ActionResult AboutVaccineCount()
        {
            var vaced = _db.Database.SqlQuery<StatIntInfo>("SELECT VaccineDose AS Name, COUNT(*) AS Count FROM Vacced GROUP BY VaccineDose ORDER BY Count DESC").ToList();
            return View(vaced);
        }

        [HttpPost]
        public FileResult Export()
        {
            VacDBEntities entities = new VacDBEntities();
            List<object> vacced = (from v in entities.Vacced.ToList()
                                   select new[] {v.Id.ToString(),
                                                v.FirstName.ToString(),
                                                v.LastName.ToString(),
                                                v.Birthday.ToString(),
                                                v.City.ToString(),
                                                v.DayOfVaccination.ToString(),
                                                v.Vaccine,
                                                v.VaccineDose.ToString()
                                }).ToList<object>();

            //Insert the Column Names.
            vacced.Insert(0, new string[8] { "Person ID", "First Name", "Last Name", "Birthday", "City", "Day of Vaccination", "Vaccine", "Vaccine Dose" });

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < vacced.Count; i++)
            {
                string[] vacP = (string[])vacced[i];
                for (int j = 0; j < vacP.Length; j++)
                {
                    //Append data with separator.
                    sb.Append(vacP[j] + ';');
                }

                //Append new line character.
                sb.Append("\r\n");

            }


            return File(Encoding.GetEncoding(1251).GetBytes(sb.ToString()), "text/csv", "Grid.csv");
        }
    }

    

}

