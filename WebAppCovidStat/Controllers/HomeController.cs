using System;
using System.Linq;
using System.Web.Mvc;
using WebAppCovidStat.Models;

namespace WebAppCovidStat.Controllers
{
    public class HomeController : Controller
    {
        private VacDBEntities _db = new VacDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Vacced.ToList());
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
            
            /*if (!ModelState.IsValid)

                return View();

            _db.AddToVacPersonSet(movieToCreate);

            _db.SaveChanges();

            return RedirectToAction("Index");*/

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

    }
}