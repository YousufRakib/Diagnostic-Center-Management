using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using PagedList.Mvc;
using HospitalManagement.Model.Model;
using HospitalManagement.BLL.BLL;
using HospitalManagement.Models;
using HospitalManagement.DatabaseContext.DatabaseContext;

using AutoMapper;
using System.Web.SessionState;

namespace HospitalManagement.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class RoleController : Controller
    {
        private RoleManager _roleManager = new RoleManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();

        public ActionResult ShowRoles()
        {
            if (Session["email"] != null && Session["RoleId"].ToString() == "1")
            {
                int? page = 1;
                RoleViewModel roleViewModel = new RoleViewModel();
                int pagesize = 1, pageindex=1;

                pageindex = page.HasValue ? Convert.ToInt32(page) : 1;

                var list = _projectDbContext.Roles.OrderByDescending(x => x.id).Where(u => u.status.Equals("Active")).ToList();

                IPagedList<Role> roles = list.ToPagedList(pageindex, pagesize);
                //ViewBag.BlogList =ToPagedList(page, 10);
                //Session["email"];
                return View(roles);
            }
            else
            {
                
                return RedirectToAction("Login","Employee");
            }



            //RoleViewModel roleViewModel=new RoleViewModel();
            //roleViewModel.Roles = _roleManager.GetAll();
            //return View(roleViewModel);
        }
        [HttpGet]
        public ActionResult AddRole()
        {
            RoleViewModel roleViewModel = new RoleViewModel();
            roleViewModel.Roles = _roleManager.GetAll();
            return View(roleViewModel);
        }

        [HttpPost]
        public ActionResult AddRole(RoleViewModel roleViewModel)
        {
            string message = "";
            roleViewModel.status = "Active";
            roleViewModel.createdAt=DateTime.Now;
            //Patient patient=new Patient();
            //patient.name = patientViewModel.name;
            //patient.phone = patientViewModel.phone;
            //patient.bloodGroup= patientViewModel.bloodGroup;
            //patient.gender = patientViewModel.gender;
            //patient.address = patientViewModel.address;
            Role role = Mapper.Map<Role>(roleViewModel);
            if (ModelState.IsValid)
            {
                if (_roleManager.Add(role))
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
            roleViewModel.Roles = _roleManager.GetAll();
            return View(roleViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int roleId = Convert.ToInt32(id);
            var roleInfo = _projectDbContext.Roles.Find(roleId);
            return View(roleInfo);
        }
        [HttpPost]
        public ActionResult Edit(RoleViewModel roleViewModel)
        {
            string message = "";
            Role role = Mapper.Map<Role>(roleViewModel);
            if (ModelState.IsValid)
            {
                if (_roleManager.Update(role))
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
            int roleId = Convert.ToInt32(id);
            var roleInfo = _projectDbContext.Roles.Find(roleId);
            return View(roleInfo);
        }
        [HttpPost]
        public ActionResult Delete(RoleViewModel roleViewModel)
        {
            string message = "";
            roleViewModel.status = "Inactive";
            Role role = Mapper.Map<Role>(roleViewModel);

            if (_roleManager.Update(role))
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
        //    Role aRole = _projectDbContext.Roles.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aRole);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Role role)
        //{
        //    var aRole = _projectDbContext.Roles.Where(x => x.id == id).SingleOrDefault();
        //    if (role != null)
        //    {
        //        _projectDbContext.Roles.Remove(aRole);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("AddRole");
        //}
    }
}