using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBookMVC.Models;

namespace PhoneBookMVC.Controllers
{
    public class HomeController : Controller
    {
        private DbManager manager = new DbManager();
        // GET: Home
        public ActionResult Index(int id = 0)
        {
            var people = manager.People;
            if (id != 0 )
            {
                people = people.Where(p => p.CategoryId == id);
            }
            return View(people);
        }

        public ActionResult Show(int id)
        {

            var person = manager.GetPerson(id);
            return View(person);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            manager.SavePerson(person);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var person = manager.GetPerson(id);
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            manager.SavePerson(person);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            manager.RemovePerson(id);              
            return RedirectToAction("Index");
        }
    }
}