using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            AssignmentEntities db = new AssignmentEntities();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Edit(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            Category categery = db.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            db.Dispose();
            return View(categery);
        }

        public ActionResult Details(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            Category categery = db.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            db.Dispose();
            return View(categery);
        }

        public ActionResult Delete(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            Category categery = db.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            db.Dispose();
            return View(categery);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Add(Category categery)
        {
            AssignmentEntities db = new AssignmentEntities();
            db.Categories.Add(categery);
            db.SaveChanges();
            db.Dispose();
            return Redirect("Index");
        }

        public ActionResult Save(Category categoryEdited)
        {
            AssignmentEntities db = new AssignmentEntities();
            Category category = db.Categories.Where(x => x.CategoryId == categoryEdited.CategoryId).FirstOrDefault();
            category.CategoryName = categoryEdited.CategoryName;
            db.SaveChanges();
            db.Dispose();
            return Redirect("Index");
        }

        public ActionResult Remove(Category categoryEdited)
        {
            AssignmentEntities db = new AssignmentEntities();
            Category category = db.Categories.Where(x => x.CategoryId == categoryEdited.CategoryId).FirstOrDefault();
            db.Categories.Remove(category);
            db.SaveChanges();
            db.Dispose();
            return Redirect("Index");
        }
    }
}