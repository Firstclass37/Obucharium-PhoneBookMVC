using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBookMVC.Models;

namespace PhoneBookMVC.Controllers
{
    public class CategoryController : Controller
    {
        DbManager db = new DbManager();
        // GET: Category
        public ActionResult Index()
        {
            @ViewBag.Title = "Catigories";
            var catedories = db.Categories.ToList();
            return View(catedories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            @ViewBag.Title = "Add new category";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cat)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.SaveCategory(cat);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch 
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            @ViewBag.Title = "Edit category";
            var category = db.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SaveCategory(category);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch 
            {
                return View();
            }

        }

        public ActionResult Remove(int id)
        {
            db.RemoveCategory(id);
            return RedirectToAction("Index");
        }
    }
}