using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class DoctorViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name Can't be Emply")]
        public string doctorName { get; set; }
        [Required(ErrorMessage = "Phone Can't be Emply")]
        public int phone { get; set; }
        [Required(ErrorMessage = "Designation Can't be Emply")]
        public string designation { get; set; }
        [Required(ErrorMessage = "Gender Can't be Emply")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Referench id Can't be Emply")]
        public int refId { get; set; }
        [Required(ErrorMessage = "Hospital name Can't be Emply")]
        public string hospitalName { get; set; }
        [Required(ErrorMessage = "Please select doctor type")]
        public string type { get; set; }
        public string status { get; set; }
        public string info { get; set; }
        public DateTime createdAt { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }
        //public int TestId { get; set; }
        public double testCommission { get; set; }
        public List<SelectListItem> TestSelectListItems { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}