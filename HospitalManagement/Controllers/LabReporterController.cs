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
using Newtonsoft.Json;

namespace HospitalManagement.Controllers
{
    public class LabReporterController : Controller
    {
        private PatientManager _patientManager = new PatientManager();
        private InvoiceManager _invoiceManager = new InvoiceManager();
        private DepartmentManager _dapartmentManager = new DepartmentManager();
        private DoctorManager _doctorManager = new DoctorManager();
        private TestManager _testManager = new TestManager();
        private ProjectDbContext _projectDbContext = new ProjectDbContext();

        [HttpGet]
        public ActionResult AddTestResult(int id)
        {
            int patientId = Convert.ToInt32(id);
            var patientInfo = _projectDbContext.Patients.Find(patientId);
            PatientInvoices patientInvoices = new PatientInvoices();
            patientInvoices.Patient = patientInfo;
            patientInvoices.Invoices = _projectDbContext.Invoices.OrderByDescending(x => x.patientId).Where(u => u.patientId.Equals(patientId)).ToList();
            return View(patientInvoices);
        }
        [HttpPost]
        public ActionResult AddTestResult(InvoiceViewModel invoiceViewModel)
        {
            string message = "";
            Invoice invoice = Mapper.Map<Invoice>(invoiceViewModel);
            if (ModelState.IsValid)
            {
                if (_invoiceManager.Update(invoice))
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

        public JsonResult GetInvoiceById(int invoiceId)
        {
            Invoice model = _projectDbContext.Invoices.Where(x => x.id == invoiceId).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            int invoiceId = Convert.ToInt32(id);
            var invoiceInfo = _projectDbContext.Invoices.Find(invoiceId);
            return View(invoiceInfo);
        }
        [HttpPost]
        public ActionResult Edit(InvoiceViewModel invoiceViewModel)
        {
            string message = "";
            Invoice invoice = Mapper.Map<Invoice>(invoiceViewModel);
            if (ModelState.IsValid)
            {
                if (_invoiceManager.Update(invoice))
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
    }
}