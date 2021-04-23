using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class DepartmentViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Department name Can't be Emply")]
        public string departmentName { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public string status { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }

        public List<Department> Departments { get; set; }
    }
}