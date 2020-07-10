using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyManager.Models;

namespace MoneyManager.Controllers
{
    public class MoneyController : Controller
    {
        // GET: Money
        public ActionResult Index()
        {
            AssignmentEntities db = new AssignmentEntities();
            List<view_Expense> expences = db.view_Expense.ToList();
            db.Dispose();
            return View(expences);
        }
        public ActionResult Details(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            view_Expense expences2 = db.view_Expense.Where(x => x.ExpenseId == id).FirstOrDefault();
            db.Dispose();
            return View(expences2);
        }

        public ActionResult Edit(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            view_Expense expences2 = db.view_Expense.Where(x => x.ExpenseId == id).FirstOrDefault();
            db.Dispose();
            return View(expences2);
        }

        public ActionResult Delete(int id)
        {
            AssignmentEntities db = new AssignmentEntities();
            view_Expense expences2 = db.view_Expense.Where(x => x.ExpenseId == id).FirstOrDefault();
            db.Dispose();
            return View(expences2);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(view_Expense UpdatedExpenses)
        {
            AssignmentEntities db = new AssignmentEntities();
            Expense expenses = db.Expenses.Where(x => x.ExpenseId == UpdatedExpenses.ExpenseId).FirstOrDefault();
            expenses.Description = UpdatedExpenses.Description;
            expenses.Date = UpdatedExpenses.Date;
            expenses.Amount = UpdatedExpenses.Amount;

            Category category = db.Categories.Where(x => x.CategoryName == UpdatedExpenses.CategoryName).FirstOrDefault();
            if (category == null)
            {
                Category new_category = new Category();
                new_category.CategoryName = UpdatedExpenses.CategoryName;
                db.Categories.Add(new_category);
                db.SaveChanges();
                category = db.Categories.Where(x => x.CategoryName == UpdatedExpenses.CategoryName).FirstOrDefault();
            }

            expenses.CategoryId = category.CategoryId;

            db.SaveChanges();

            db.Dispose();
            return Redirect("Index");
        }

        public ActionResult Add(view_Expense UpdatedExpenses)
        {
            AssignmentEntities db = new AssignmentEntities();
            Expense expenses = new Expense();
            expenses.Description = UpdatedExpenses.Description;
            expenses.Date = UpdatedExpenses.Date;
            expenses.Amount = UpdatedExpenses.Amount;

            Category category = db.Categories.Where(x => x.CategoryName == UpdatedExpenses.CategoryName).FirstOrDefault();
            if (category == null)
            {
                Category new_category = new Category();
                new_category.CategoryName = UpdatedExpenses.CategoryName;
                db.Categories.Add(new_category);
                db.SaveChanges();
                category = db.Categories.Where(x => x.CategoryName == UpdatedExpenses.CategoryName).FirstOrDefault();
            }

            expenses.CategoryId = category.CategoryId;
            db.Expenses.Add(expenses);
            db.SaveChanges();

            db.Dispose();
            return Redirect("Index");
        }


        public ActionResult Remove(view_Expense UpdatedExpenses)
        {
            AssignmentEntities db = new AssignmentEntities();
            Expense expences = db.Expenses.Where(x => x.ExpenseId == UpdatedExpenses.ExpenseId).FirstOrDefault();
            db.Expenses.Remove(expences);
            db.SaveChanges();
            db.Dispose();
            return Redirect("Index");
        }

    }
}