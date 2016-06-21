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
        public ActionResult Index()
        {
            @ViewBag.Title = "Home";
            var people = manager.People;       
            return View(people);
        }

        public ActionResult ShowCategory(int id)
        {        
            var people = manager.People.Where(p => p.CategoryId == id);
            var cat = manager.Categories.Where(c=>c.Id == id).First();
            @ViewBag.Title = cat==null?"Empty category":cat.Name;
            return View(people);
        }

        public ActionResult Show(int id)
        {
            @ViewBag.Title = "Details";
            var person = manager.GetPerson(id);
            return View(person);
        }

        [HttpGet]
        public ActionResult Create()
        {
            @ViewBag.Title = "Add new person";
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
            @ViewBag.Title = "Edit info";
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