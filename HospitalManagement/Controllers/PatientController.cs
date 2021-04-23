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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Rotativa;
using AutoMapper;
using System.Dynamic;
using Rotativa.MVC;

namespace HospitalManagement.Controllers
{
    public class PatientController : Controller
    {
        private PatientManager _patientManager = new PatientManager();
        private InvoiceManager _invoiceManager=new InvoiceManager();
        private DepartmentManager _dapartmentManager = new DepartmentManager();
        private DoctorManager _doctorManager = new DoctorManager();
        private TestManager _testManager = new TestManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();


        public ActionResult PrintMoneyReceipt(int id)
        {
            //return new ActionAsPdf("ViewDetails");
            int patientId = Convert.ToInt32(1009);
            var patientInfo = _projectDbContext.Patients.Find(patientId);
            PatientInvoices patientInvoices = new PatientInvoices();
            patientInvoices.Patient = patientInfo;
            patientInvoices.Invoices = _projectDbContext.Invoices.OrderByDescending(x => x.patientId).Where(u => u.patientId.Equals(patientId)).ToList();
            // return View(patientInvoices);
            return new ActionAsPdf("ViewDetails", patientId);
        }
        [HttpGet]
        public ActionResult ShowPatients()
        {
            if (Session["email"] != null && Session["RoleId"].ToString() == "1")
            {
                int? page = 1;
                int pagesize = 6, pageindex = 1;
                pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
                var list = _projectDbContext.Patients.OrderByDescending(x => x.id).ToList();
                IPagedList<Patient> patients = list.ToPagedList(pageindex, pagesize);
                return View(patients);
            }
            else
            {
                return RedirectToAction("Login", "Employee");
            }
        }
        [HttpGet]
        public ActionResult ViewDetails(int id)
        {
            int patientId = Convert.ToInt32(id);
            var patientInfo = _projectDbContext.Patients.Find(patientId);
            PatientInvoices patientInvoices = new PatientInvoices();
            patientInvoices.Patient = patientInfo;
            patientInvoices.Invoices = _projectDbContext.Invoices.OrderByDescending(x => x.patientId).Where(u => u.patientId.Equals(patientId)).ToList();
            return View(patientInvoices);
        }
        public JsonResult GetTestPriceByTestName(int testId)
        {
            var testList = _testManager.GetAll().Where(c => c.id == testId).ToList();
            var testPrice = from p in testList select (new { p.price });
            return Json(testPrice, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUnitByTestName(int testId)
        {
            var testList = _testManager.GetAll().Where(c => c.id == testId).ToList();
            var testUnit = from p in testList select (new { p.unit });
            return Json(testUnit, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetReferenceRangeByTestName(int testId)
        {
            var testList = _testManager.GetAll().Where(c => c.id == testId).ToList();
            var testReferenceRange = from p in testList select (new { p.referenceRange });
            return Json(testReferenceRange, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDeliveryDaysByTestName(int testId)
        {
            var testList = _testManager.GetAll().Where(c => c.id == testId).ToList();
            var deliveryday = from p in testList select (new { p.deliveryDays });
            return Json(deliveryday, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTestRoomByTestName(int testId)
        {
            var testList = _testManager.GetAll().Where(c => c.id == testId).ToList();
            var Room = from p in testList select (new { p.testRoom });
            return Json(Room, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDoctorInfoByDoctorName(int doctorId)
        {
            var doctorList = _doctorManager.GetAll().Where(c => c.id == doctorId).ToList();
            var info = from D in doctorList select (new {D.info});
            return Json(info, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDoctorRefIdByDoctorName(int doctorId)
        {
            var doctorList = _doctorManager.GetAll().Where(c => c.id == doctorId).ToList();
            var refId = from D in doctorList select (new { D.refId });
            return Json(refId, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDoctorNameByDoctorName(int doctorId)
        {
            var doctorList = _doctorManager.GetAll().Where(c => c.id == doctorId).ToList();
            var doctorName = from D in doctorList select (new { D.doctorName });
            return Json(doctorName, JsonRequestBehavior.AllowGet);
        }

        public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }


        [HttpGet]
        public ActionResult AddPatient()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.Patients = _patientManager.GetAll();
            var autoIncrementId = _projectDbContext.Patients.Max(a=>a.id);
            patientViewModel.billId = "XYZ" + (autoIncrementId+1).ToString();
            patientViewModel.DoctorSelectListItems = _doctorManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.doctorName
                }).ToList();
            patientViewModel.TestSelectListItems = _testManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.testName
                }).ToList();

            //ViewBag.Test = patientViewModel.TestSelectListItems;

            return View(patientViewModel);
        }
        [HttpPost]
        public ActionResult AddPatient(PatientViewModel patientViewModel)
        {
            InvoiceViewModel invoiceViewModel=new InvoiceViewModel();
            string message = "";
            patientViewModel.status = "Active";
            patientViewModel.createdAt = DateTime.Now;
            patientViewModel.invoiceDate=DateTime.Now;

            patientViewModel.age = patientViewModel.age_Day + "-" + patientViewModel.age_Month + "-" + patientViewModel.age_Year;

            //int patientId = patientViewModel.id;
            int testId = patientViewModel.TestId;
            string testRoom = patientViewModel.testRoom;
            double price = patientViewModel.price;
            DateTime createdAt = patientViewModel.createdAt;
            string billId = patientViewModel.billId;
            string status = patientViewModel.status;


            //invoiceViewModel.patientId = patientId;
            invoiceViewModel.billId = billId;
            invoiceViewModel.testId = testId;
            invoiceViewModel.testRoom = testRoom;
            invoiceViewModel.price = price;
            invoiceViewModel.createdAt = createdAt;
            invoiceViewModel.status = status;
            var patientid = _projectDbContext.Patients.Max(a => a.id);
            invoiceViewModel.patientId = patientid + 1;
            Patient patient = Mapper.Map<Patient>(patientViewModel);
            Invoice invoice = Mapper.Map<Invoice>(invoiceViewModel);
            
            //int patientId = patientViewModel.id;
            //invoiceViewModel.patientId = patientId;


            string word = ConvertNumbertoWords(Convert.ToInt32(patientViewModel.totalAmmount));
            patientViewModel.totalAmmountInText = word;

            if (patientViewModel.dueAmmount > 0)
            {
                patientViewModel.paymentStatus = "Due";
            }
            else
            {
                patientViewModel.paymentStatus = "Paid";
            }

            
            //if (ModelState.IsValid)
            //{
                if (_patientManager.Add(patient) && _invoiceManager.Add(invoice))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            //}
            //else
            //{
            //    message = "Please full up the field correctly";
            //}
            ViewBag.Message = message;
            patientViewModel.Patients = _patientManager.GetAll();
       
            patientViewModel.DoctorSelectListItems = _doctorManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.refId.ToString()
                }).ToList();
            patientViewModel.TestSelectListItems = _testManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.id.ToString(),
                    Text = c.testName
                }).ToList();
            return View(patientViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int patientId = Convert.ToInt32(id);
            var patientInfo = _projectDbContext.Patients.Find(patientId);
            return View(patientInfo);
        }
        [HttpPost]
        public ActionResult Edit(PatientViewModel patientViewModel)
        {
            string message = "";
            Patient patient = Mapper.Map<Patient>(patientViewModel);
            if (ModelState.IsValid)
            {
                if (_patientManager.Update(patient))
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
            int patientId = Convert.ToInt32(id);
            var patientInfo = _projectDbContext.Patients.Find(patientId);
            return View(patientInfo);
        }
        [HttpPost]
        public ActionResult Delete(PatientViewModel patientViewModel)
        {
            string message = "";
            patientViewModel.status = "Inactive";
            Patient patient = Mapper.Map<Patient>(patientViewModel);

            if (_patientManager.Update(patient))
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
        //    Patient aPatient = _projectDbContext.Patients.Find(id);//.Where(x => x.PublisherId == id).SingleOrDefault();
        //    return View(aPatient);
        //}
        //[HttpPost]
        //public ActionResult Delete(int id, Patient patient)
        //{
        //    var aPatient = _projectDbContext.Patients.Where(x => x.id == id).SingleOrDefault();
        //    if (aPatient != null)
        //    {
        //        _projectDbContext.Patients.Remove(aPatient);
        //        _projectDbContext.SaveChanges();
        //    }
        //    return RedirectToAction("ShowPatients");
        //}
    }
}