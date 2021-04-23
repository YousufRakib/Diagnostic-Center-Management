using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace HospitalManagement.Models
{
    public class PatientViewModel
    {

        public int id { get; set; }
        public string billId { get; set; }
        public int bedNo { get; set; }
        [Required(ErrorMessage = "Name Can't be Emply")]
        public string name { get; set; }
        [Required(ErrorMessage = "Phone Can't be Emply")]
        public int phone { get; set; }
        public string status { get; set; }
        [Required(ErrorMessage = "Gender Can't be Emply")]
        public string gender { get; set; }
        public int age_Day { get; set; }
        public int age_Month { get; set; }
        public int age_Year { get; set; }
        public string age { get; set; }
        [Required(ErrorMessage = "Address Can't be Emply")]
        public string address { get; set; }
        public string info { get; set; }      
        public DateTime invoiceDate { get; set; }       
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
        public double price { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int refId { get; set; }
        public string doctorName { get; set; }
        public double subTotal { get; set; }
        public double discount { get; set; }
        public double deductAmmount { get; set; }
        public double totalAmmount { get; set; }
        public string totalAmmountInText { get; set; }
        public double paidAmmount { get; set; }
        public double dueAmmount { get; set; }
        public string paymentStatus { get; set; }
        public string deliveryDate { get; set; }
        public string deliveryTime { get; set; }
        public string remark { get; set; }
        public string paymentBy { get; set; }

       
        public DateTime createdAt { get; set; }
        public string testRoom { get; set; }
        public string unit { get; set; }
        public string referenceRange { get; set; }

        public List<Patient> Patients { get; set; }
        public List<Test> Tests { get; set; }

        public List<SelectListItem> TestSelectListItems { get; set; }
        public List<SelectListItem> DoctorSelectListItems { get; set; }
    }
}