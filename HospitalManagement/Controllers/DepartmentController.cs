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
    public class DepartmentController : Controller
    {
        private DepartmentManager _departmentManager = new DepartmentManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();

        [HttpGet]
        public ActionResult ShowDepartments(int? page)
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel();
            int pagesize = 6, pageindex = 1;

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;

            var list = _projectDbContext.Departments.OrderByDescending(x => x.id).Where(u => u.status.Equals("Active")).ToList();
            //var list2 = _projectDbContext.Departments.Where(u => u.status.Equals("Active")).ToList();

            IPagedList<Department> departments = list.ToPagedList(pageindex, pagesize);
            //IPagedList<Department> departments2 = list2.ToPagedList(pageindex, pagesize);

            return View(departments);

            //DepartmentViewModel departmentViewModel=new DepartmentViewModel();
            //departmentViewModel.Departments = _departmentManager.GetAll();
            //return View(departmentViewModel);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            DepartmentViewModel departmentViewModel = new DepartmentViewModel();
            departmentViewModel.Departments = _departmentManager.GetAll();
            return View(departmentViewModel);
        }

        [HttpPost]
        public ActionResult AddDepartment(DepartmentViewModel departmentViewModel)
        {
            string message = "";
            departmentViewModel.status = "Active";
            departmentViewModel.createdAt = DateTime.Now;
            //Patient patient=new Patient();
            //patient.name = patientViewModel.name;
            //patient.phone = patientViewModel.phone;
            //patient.bloodGroup= patientViewModel.bloodGroup;
            //patient.gender = patientViewModel.gender;
            //patient.address = patientViewModel.address;
            Department department= Mapper.Map<Department>(departmentViewModel);
            if (ModelState.IsValid)
            {
                if (_departmentManager.Add(department))
                {
                    return RedirectToAction("ShowDepartments");
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
            departmentViewModel.Departments = _departmentManager.GetAll();
            return View(departmentViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int departmentId = Convert.ToInt32(id);
            var departmentInfo = _projectDbContext.Departments.Find(departmentId);
            return View(departmentInfo);
        }
        [HttpPost]
        public ActionResult Edit(DepartmentViewModel departmentViewModel)
        {
            string message = "";
            Department department = Mapper.Map<Department>(departmentViewModel);
            if (ModelState.IsValid)
            {
                if (_departmentManager.Update(department))
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
            int departmentId = Convert.ToInt32(id);
            var departmentInfo = _projectDbContext.Departments.Find(departmentId);
            return View(departmentInfo);
        }
        [HttpPost]
        public ActionResult Delete(DepartmentViewModel departmentViewModel)
        {
            string message = "";
            departmentViewModel.status = "Inactive";
            Department department = Mapper.Map<Department>(departmentViewModel);

            if (_departmentManager.Update(department))
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
        //    Department aDepartment = _projectDbContext.Departments.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aDepartment);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Department department)
        //{
        //    var aDepartment = _projectDbContext.Departments.Where(x => x.id == id).SingleOrDefault();
        //    if (aDepartment != null)
        //    {
        //        _projectDbContext.Departments.Remove(aDepartment);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("ShowDepartments");
        //}
    }
}