using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using HospitalManagement.Model.Model;
using HospitalManagement.BLL.BLL;
using HospitalManagement.Models;
using HospitalManagement.DatabaseContext.DatabaseContext;

using AutoMapper;

namespace HospitalManagement.Controllers
{
    public class ExpenseController : Controller
    {
        private ExpenseManager _expenseManager = new ExpenseManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();

        [HttpGet]
        public ActionResult ShowExpenses(int? page)
        {
            ExpenseViewModel ecpenseViewModel = new ExpenseViewModel();
            int pagesize = 6, pageindex = 1;

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;

            var list = _projectDbContext.Expenses.OrderByDescending(x => x.id).Where(u => u.status.Equals("Active")).ToList();

            IPagedList<Expense> expenses = list.ToPagedList(pageindex, pagesize);

            return View(expenses);

            //ExpenseViewModel expenseViewModel=new ExpenseViewModel();
            //expenseViewModel.Expenses = _expenseManager.GetAll();
            //return View(expenseViewModel);
        }
        [HttpGet]
        public ActionResult AddExpense()
        {
            ExpenseViewModel expenseViewModel = new ExpenseViewModel();
            expenseViewModel.Expenses = _expenseManager.GetAll();
            return View(expenseViewModel);
        }

        [HttpPost]
        public ActionResult AddExpense(ExpenseViewModel expenseViewModel)
        {
            string message = "";
            expenseViewModel.status = "Active";           
            expenseViewModel.createdAt = DateTime.Now;
            Expense expense = Mapper.Map<Expense>(expenseViewModel);
            if (ModelState.IsValid)
            {
                if (_expenseManager.Add(expense))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "Please full up the field correctly";
            }


            ViewBag.Message = message;
            expenseViewModel.Expenses = _expenseManager.GetAll();
            return View(expenseViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int expenseId = Convert.ToInt32(id);
            var expenseInfo = _projectDbContext.Expenses.Find(expenseId);
            return View(expenseInfo);
        }
        [HttpPost]
        public ActionResult Edit(ExpenseViewModel expenseViewModel)
        {
            string message = "";
            Expense expense = Mapper.Map<Expense>(expenseViewModel);
            if (ModelState.IsValid)
            {
                if (_expenseManager.Update(expense))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "Please full up the field correctly";
            }


            ViewBag.Message = message;
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            int expenseId = Convert.ToInt32(id);
            var expenseInfo = _projectDbContext.Expenses.Find(expenseId);
            return View(expenseInfo);
        }
        [HttpPost]
        public ActionResult Delete(ExpenseViewModel expenseViewModel)
        {
            string message = "";
            expenseViewModel.status = "Inactive";
            Expense expense = Mapper.Map<Expense>(expenseViewModel);

            if (_expenseManager.Update(expense))
            {
                message = "Updated";
            }
            else
            {
                message = "Not Updated";
            }

            ViewBag.Message = message;
            return View();
        }







        //public ActionResult Delete(int id)
        //{
        //    Expense aExpense = _projectDbContext.Expenses.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aExpense);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Expense expense)
        //{
        //    var aExpense = _projectDbContext.Expenses.Where(x => x.id == id).SingleOrDefault();
        //    if (aExpense != null)
        //    {
        //        _projectDbContext.Expenses.Remove(aExpense);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("ShowExpenses");
        //}
    }
}