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
    public class AccountController : Controller
    {
        private AccountManager _accountManager=new AccountManager();
        private EmployeeManager _employeeManager=new EmployeeManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();
        [HttpGet]
        public ActionResult AddAccount()
        {
            AccountViewModel accountViewModel=new AccountViewModel();
            accountViewModel.Accounts = _accountManager.GetAll();
            accountViewModel.EmployeeSelectListItems = _employeeManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.employeeName
                }).ToList();

            return View(accountViewModel);
        }

        [HttpPost]
        public ActionResult AddAccount(AccountViewModel accountViewModel)
        {
            string message = "";
            accountViewModel.status = "Active";
            accountViewModel.createdAt = DateTime.Now;
            //Patient patient=new Patient();
            //patient.name = patientViewModel.name;
            //patient.phone = patientViewModel.phone;
            //patient.bloodGroup= patientViewModel.bloodGroup;
            //patient.gender = patientViewModel.gender;
            //patient.address = patientViewModel.address;

            if (ModelState.IsValid)
            {
                Account account = Mapper.Map<Account>(accountViewModel);
                if (_accountManager.Add(account))
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
            accountViewModel.Accounts = _accountManager.GetAll();
            accountViewModel.EmployeeSelectListItems = _employeeManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.employeeName
                }).ToList();
            return View(accountViewModel);
        }
        public ActionResult Details(int id)
        {
            int accountId = Convert.ToInt32(id);
            var accountInfo = _projectDbContext.Accounts.Find(accountId);
            return View(accountInfo);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int accountId = Convert.ToInt32(id);
            var accountInfo = _projectDbContext.Accounts.Find(accountId);
            return View(accountInfo);
        }
        [HttpPost]
        public ActionResult Edit(AccountViewModel accountViewModel)
        {
            string message = "";
            Account account = Mapper.Map<Account>(accountViewModel);
            if (ModelState.IsValid)
            {
                if (_accountManager.Update(account))
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
            int accountId = Convert.ToInt32(id);
            var accountInfo = _projectDbContext.Accounts.Find(accountId);
            return View(accountInfo);
        }
        [HttpPost]
        public ActionResult Delete(AccountViewModel accountViewModel)
        {
            string message = "";
            accountViewModel.status = "Inactive";
            Account account = Mapper.Map<Account>(accountViewModel);

            if (_accountManager.Update(account))
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
        //    Account aAccount = _projectDbContext.Accounts.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aAccount);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Account account)
        //{
        //    var aAccount = _projectDbContext.Accounts.Where(x => x.id == id).SingleOrDefault();
        //    if (account != null)
        //    {
        //        _projectDbContext.Accounts.Remove(aAccount);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("AddAccount");
        //}
    }
}