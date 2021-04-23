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
    public class DoctorController : Controller
    {
        private DoctorManager _doctorManager = new DoctorManager();
        private TestManager _testManager=new TestManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();
        [HttpGet]
        public ActionResult ShowDoctors(int? page)
        {
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            int pagesize = 4, pageindex = 1;

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;

            var list = _projectDbContext.Doctors.OrderByDescending(x => x.id).Where(u => u.status.Equals("Active")).ToList();

            IPagedList<Doctor> doctors = list.ToPagedList(pageindex, pagesize);

            return View(doctors);

            //DoctorViewModel doctorViewModel = new DoctorViewModel();
            //doctorViewModel.Doctors = _doctorManager.GetAll();
            //return View(doctorViewModel);
        }
        [HttpGet]
        public ActionResult AddDoctor()
        {
            DoctorViewModel doctorViewModel = new DoctorViewModel();
            doctorViewModel.Doctors = _doctorManager.GetAll();
            doctorViewModel.TestSelectListItems = _testManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.testName
                }).ToList();
            return View(doctorViewModel);
        }
        [HttpPost]
        public ActionResult AddDoctor(DoctorViewModel doctorViewModel)
        {
            var doctors = new List<Doctor>();
            string message = "";
            //doctorViewModel.status = "Active";
            //doctorViewModel.createdAt = DateTime.Now;
            //doctorViewModel.info =
            //    doctorViewModel.doctorName+"," + doctorViewModel.designation+ ", "+ doctorViewModel.hospitalName;
            
            //Patient patient = new Patient();
            //patient.name = patientViewModel.name;
            //patient.phone = patientViewModel.phone;
            //patient.bloodGroup = patientViewModel.bloodGroup;
            //patient.gender = patientViewModel.gender;
            //patient.address = patientViewModel.address;
            //Doctor doctor = Mapper.Map<Doctor>(doctorViewModel);

            if (ModelState.IsValid)
            {
                foreach (var doctor in doctorViewModel.Doctors)
                {
                    doctor.doctorName = doctorViewModel.doctorName;
                    doctor.phone = doctorViewModel.phone;
                    doctor.designation = doctorViewModel.designation;
                    doctor.gender = doctorViewModel.gender;
                    doctor.refId = doctorViewModel.refId;
                    doctor.hospitalName = doctorViewModel.hospitalName;
                    doctor.type = doctorViewModel.type;
                    doctor.status = "Active";
                    doctor.info = doctorViewModel.doctorName + "," + doctorViewModel.designation + ", " + doctorViewModel.hospitalName;
                    doctor.createdAt = DateTime.Now;
                    //doctor.TestId=doctorViewModel
                    //doctor.testCommission = doctorViewModel.testCommission;
                    doctors.Add(doctor);
                }
            }

            _doctorManager.Add(doctors);
            //if (ModelState.IsValid)
            //{
            //    if (_doctorManager.Add(doctor))
            //    {
            //        return RedirectToAction("ShowDoctors");
            //    }
            //    else
            //    {
            //        message = "Not Saved";
            //    }
            //}
            //else
            //{
            //    message = "Please full up the field correctly";
            //}


            ViewBag.Message = message;
            doctorViewModel.Doctors = _doctorManager.GetAll();
            doctorViewModel.TestSelectListItems = _testManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.testName
                }).ToList();
            return View(doctorViewModel);
        }
        public ActionResult Details(int id)
        {
            int doctorId = Convert.ToInt32(id);
            var doctorInfo = _projectDbContext.Doctors.Find(doctorId);
            return View(doctorInfo);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int doctorId = Convert.ToInt32(id);
            var doctorInfo = _projectDbContext.Doctors.Find(doctorId);
            return View(doctorInfo);
        }
        [HttpPost]
        public ActionResult Edit(DoctorViewModel doctorViewModel)
        {
            string message = "";
            doctorViewModel.info =
                doctorViewModel.doctorName + "," + doctorViewModel.designation + ", " + doctorViewModel.hospitalName;
            Doctor doctor = Mapper.Map<Doctor>(doctorViewModel);
            if (ModelState.IsValid)
            {
                if (_doctorManager.Update(doctor))
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
            int doctorId = Convert.ToInt32(id);
            var doctorInfo = _projectDbContext.Doctors.Find(doctorId);
            return View(doctorInfo);
        }
        [HttpPost]
        public ActionResult Delete(DoctorViewModel doctorViewModel)
        {
            string message = "";
            doctorViewModel.status = "Inactive";
            Doctor doctor = Mapper.Map<Doctor>(doctorViewModel);

            if (_doctorManager.Update(doctor))
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
        //    Doctor aDoctor = _projectDbContext.Doctors.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aDoctor);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Doctor doctor)
        //{
        //    var aDoctor = _projectDbContext.Doctors.Where(x => x.id == id).SingleOrDefault();
        //    if (doctor != null)
        //    {
        //        _projectDbContext.Doctors.Remove(aDoctor);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("ShowDoctors");
        //}
    }
}