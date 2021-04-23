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
    public class CategoryController : Controller
    {
        private CategoryManager _categoryManager = new CategoryManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();

        public ActionResult ShowCategories(int? page)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            int pagesize = 6, pageindex = 1;

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;

            var list = _projectDbContext.Categorys.OrderByDescending(x => x.id).Where(u => u.status.Equals("Active")).ToList();

            IPagedList<Category> categories = list.ToPagedList(pageindex, pagesize);

            return View(categories);


            //CategoryViewModel categoryViewModel = new CategoryViewModel();
            //categoryViewModel.Categories = _categoryManager.GetAll();
            //return View(categoryViewModel);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel categoryViewModel)
        {
            string message = "";
            categoryViewModel.status = "Active";
            categoryViewModel.createdAt = DateTime.Now;
            Category category = Mapper.Map<Category>(categoryViewModel);
            if (ModelState.IsValid)
            {
                if (_categoryManager.Add(category))
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
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int categoryId = Convert.ToInt32(id);
            var categoryInfo = _projectDbContext.Categorys.Find(categoryId);
            return View(categoryInfo);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            string message = "";
            Category category = Mapper.Map<Category>(categoryViewModel);
            if (ModelState.IsValid)
            {
                if (_categoryManager.Update(category))
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
            int categoryId = Convert.ToInt32(id);
            var categoryInfo = _projectDbContext.Categorys.Find(categoryId);
            return View(categoryInfo);
        }
        [HttpPost]
        public ActionResult Delete(CategoryViewModel categoryViewModel)
        {
            string message = "";
            categoryViewModel.status = "Inactive";
            Category category = Mapper.Map<Category>(categoryViewModel);

            if (_categoryManager.Update(category))
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
        //    Category aCategory = _projectDbContext.Categorys.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aCategory);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Category category)
        //{
        //    var aCategory = _projectDbContext.Categorys.Where(x => x.id == id).SingleOrDefault();
        //    if (aCategory != null)
        //    {
        //        _projectDbContext.Categorys.Remove(aCategory);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("ShowCategories");
        //}

    }
}