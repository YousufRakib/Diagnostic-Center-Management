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
    public class EmployeeController : Controller
    {
        private EmployeeManager _employeeManager = new EmployeeManager();
        private RoleManager _roleManager=new RoleManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();
        [HttpGet]
        public ActionResult ShowEmployees()
        {
            // && Session["RoleId"].Equals(22)
            if (Session["email"] != null && Session["RoleId"].ToString() == "1")
            {
                int? page = 1;
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();
                int pagesize = 6, pageindex = 1;

                pageindex = page.HasValue ? Convert.ToInt32(page) : 1;

                var list = _projectDbContext.Employees.OrderByDescending(x => x.id).Where(u => u.status.Equals("Active")).ToList();

                IPagedList<Employee> employees = list.ToPagedList(pageindex, pagesize);

                return View(employees);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //[HttpGet]
        //public ActionResult ShowEmployees(int? page)
        //{
        //    // && Session["RoleId"].Equals(22)
        //    if (Session["email"] != null && Session["RoleId"].ToString() == "2")
        //    {
        //        EmployeeViewModel employeeViewModel = new EmployeeViewModel();
        //        int pagesize = 6, pageindex = 1;

        //        pageindex = page.HasValue ? Convert.ToInt32(page) : 1;

        //        var list = _projectDbContext.Employees.OrderByDescending(x => x.id).Where(u => u.status.Equals("Active")).ToList();

        //        IPagedList<Employee> employees = list.ToPagedList(pageindex, pagesize);

        //        return View(employees);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}

        [HttpPost]
        public ActionResult ShowEmployees(EmployeeViewModel employeeViewModel,string search)
        {
            if (Session["email"] != null && Session["RoleId"].ToString()=="2")
            {
                if (search == "Search")
                {
                    var employees = _employeeManager.GetAll();

                    if (employeeViewModel.employeeName != null)
                    {
                        employees = employees.Where(c => c.employeeName.Contains(employeeViewModel.employeeName)).ToList();
                    }
                    employeeViewModel.Employees = employees;
                    employeeViewModel.RoleSelectListItems = _roleManager
                        .GetAll()
                        .Select(c => new SelectListItem()
                        {
                            Value = c.id.ToString(),
                            Text = c.roleName
                        }).ToList();
                    return View(employeeViewModel);
                }

                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Employees = _employeeManager.GetAll();
            employeeViewModel.RoleSelectListItems = _roleManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.roleName
                }).ToList();

            return View(employeeViewModel);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeViewModel employeeViewModel)
        {
            string message = "";
            employeeViewModel.status = "Active";
            employeeViewModel.createdAt = DateTime.Now;
            Employee employee = Mapper.Map<Employee>(employeeViewModel);
            if (ModelState.IsValid)
            {
                if (_employeeManager.Add(employee))
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
            employeeViewModel.Employees = _employeeManager.GetAll();
            employeeViewModel.RoleSelectListItems = _roleManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.roleName
                }).ToList();
            return View(employeeViewModel);
        }
        public ActionResult Details(int id)
        {
            int employeeId = Convert.ToInt32(id);
            var employeeInfo = _projectDbContext.Employees.Find(employeeId);
            return View(employeeInfo);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int employeeId = Convert.ToInt32(id);
            var employeeInfo = _projectDbContext.Employees.Find(employeeId);
            return View(employeeInfo);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            string message = "";
            Employee employee = Mapper.Map<Employee>(employeeViewModel);
            if (ModelState.IsValid)
            {
                if (_employeeManager.Update(employee))
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
        public ActionResult Login()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Employees = _employeeManager.GetAll();
            employeeViewModel.Employees = _employeeManager.GetAll();
            employeeViewModel.RoleSelectListItems = _roleManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.roleName
                }).ToList();
            return View(employeeViewModel);
        }
        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            EmployeeViewModel employeeViewModel=new EmployeeViewModel();
            string message = "";
            if (ModelState.IsValid)
            {
                //.Where(u => u.email.Equals(employeeViewModel.email)).
                var user = _projectDbContext.Employees
                    .Where(u => u.email.Equals(employee.email) && u.RoleId.Equals(employee.RoleId)).FirstOrDefault();
                if (user != null)
                {
                    Session["employeeName"] = user.employeeName.ToString();
                    Session["email"] = user.email.ToString();
                    Session["RoleId"] = user.RoleId.ToString();
                    return RedirectToAction("ShowEmployees");
                    //message = "Login Successfully";
                }
                else
                {
                    message = "Login Failed";
                    ViewBag.Message = message;
                    employeeViewModel.Employees = _employeeManager.GetAll();
                    employeeViewModel.RoleSelectListItems = _roleManager
                        .GetAll()
                        .Select(c => new SelectListItem()
                        {
                            Value = c.id.ToString(),
                            Text = c.roleName
                        }).ToList();
                    return View(employeeViewModel);
                }
            }
            else
            {
                message = "Login Failed";
                ViewBag.Message = message;
                employeeViewModel.Employees = _employeeManager.GetAll();
                employeeViewModel.RoleSelectListItems = _roleManager
                    .GetAll()
                    .Select(c => new SelectListItem()
                    {
                        Value = c.id.ToString(),
                        Text = c.roleName
                    }).ToList();
                return View(employeeViewModel);
            }
            //ViewBag.Message = message;
            //employeeViewModel.Employees = _employeeManager.GetAll();
            //employeeViewModel.RoleSelectListItems = _roleManager
            //    .GetAll()
            //    .Select(c => new SelectListItem()
            //    {
            //        Value = c.id.ToString(),
            //        Text = c.roleName
            //    }).ToList();
            //return View(employeeViewModel);
        }
        public ActionResult Logout()
        {
            Session["email"] = null;
            Session["RoleId"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            int employeeId = Convert.ToInt32(id);
            var employeeInfo = _projectDbContext.Employees.Find(employeeId);
            return View(employeeInfo);
        }
        [HttpPost]
        public ActionResult Delete(EmployeeViewModel employeeViewModel)
        {
            string message = "";
            employeeViewModel.status = "Inactive";
            Employee employee = Mapper.Map<Employee>(employeeViewModel);

            if (_employeeManager.Update(employee))
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
        //    Employee aEmployee = _projectDbContext.Employees.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aEmployee);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Employee employee)
        //{
        //    var aEmployee = _projectDbContext.Employees.Where(x => x.id == id).SingleOrDefault();
        //    if (employee != null)
        //    {
        //        _projectDbContext.Employees.Remove(aEmployee);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("ShowEmployees");
        //}
    }
}