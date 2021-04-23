using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Model.Model;
using HospitalManagement.BLL.BLL;
using HospitalManagement.Models;
using HospitalManagement.DatabaseContext.DatabaseContext;

using AutoMapper;

namespace HospitalManagement.Controllers
{
    public class TestController : Controller
    {
        private TestManager _testManager = new TestManager();
        private CategoryManager _categoryManager=new CategoryManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();

        
        [HttpGet]
        public ActionResult ShowTests(int? page)
        {
            TestViewModel testViewModel=new TestViewModel();
            int pagesize = 6, pageindex = 1;

            //testViewModel.CategoryName = (from T in _projectDbContext.Tests
            //        join C in _projectDbContext.Categorys
            //            on T.CategoryId equals C.id
            //        select new
            //        {
            //            CategoryName = C.CategoryName
            //        }).ToList()
            //    .Select(x => new Test()
            //    {
            //        CategoryName = x.CategoryName
            //    }).ToString();

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = _projectDbContext.Tests.OrderByDescending(x => x.id).Where(u => u.status.Equals("Active")).ToList();
            IPagedList<Test> tests = list.ToPagedList(pageindex,pagesize);

            return View(tests);
        }
        [HttpGet]
        public ActionResult AddTest()
        {
            //var data = from p in _projectDbContext.Tests
            //    select new
            //    {
            //        CategoryId = p.CategoryId,
            //        CategoryName = p.CategoryName
            //    };

            //SelectList list = new SelectList(data, "CategoryId", "CategoryName");
            //ViewBag.Roles = list;

            //return View(new TestViewModel());


            TestViewModel testViewModel = new TestViewModel();
            testViewModel.Tests = _testManager.GetAll();
            testViewModel.CategorySelectListItems = _categoryManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.CategoryName

                }
            ).ToList();
            return View(testViewModel);
        }

        [HttpPost]
        public ActionResult AddTest(TestViewModel testViewModel)
        {

            //_projectDbContext.Tests.Add(testViewModel);
            //_projectDbContext.SaveChanges();
            //return RedirectToAction("ShowTests");

            string message = "";
            testViewModel.status = "Active";
            testViewModel.createdAt = DateTime.Now;
            Test test = Mapper.Map<Test>(testViewModel);
            if (ModelState.IsValid)
            {
                if (_testManager.Add(test))
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
            testViewModel.Tests = _testManager.GetAll();
            testViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.CategoryName
                }).ToList();
            return View(testViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int testId = Convert.ToInt32(id);
            var testInfo = _projectDbContext.Tests.Find(testId);
            return View(testInfo);
        }
        [HttpPost]
        public ActionResult Edit(TestViewModel testViewModel)
        {
            string message = "";
            Test test= Mapper.Map<Test>(testViewModel);
            if (ModelState.IsValid)
            {
                if (_testManager.Update(test))
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
            int testId = Convert.ToInt32(id);
            var testInfo = _projectDbContext.Tests.Find(testId);
            return View(testInfo);
        }
        [HttpPost]
        public ActionResult Delete(TestViewModel testViewModel)
        {
            string message = "";
            testViewModel.status = "Inactive";
            Test test = Mapper.Map<Test>(testViewModel);

            if (_testManager.Update(test))
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
        //    Test aTest = _projectDbContext.Tests.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aTest);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Test test)
        //{
        //    var aTest = _projectDbContext.Tests.Where(x => x.id == id).SingleOrDefault();
        //    if (aTest != null)
        //    {
        //        _projectDbContext.Tests.Remove(aTest);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("ShowTests");
        //}
    }
}