using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class EmployeeViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Employee Id Can't be Emply")]
        public string employeeId { get; set; }
        [Required(ErrorMessage = "Name Can't be Emply")]
        public string employeeName { get; set; }
        [Required(ErrorMessage = "Email Can't be Emply")]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone Can't be Emply")]
        public int phone { get; set; }
        [Required(ErrorMessage = "Blood Group Can't be Emply")]
        public string bloodGroup { get; set; }
        [Required(ErrorMessage = "Salary Can't be Emply")]
        public int salary { get; set; }
        [Required(ErrorMessage = "Address Can't be Emply")]
        public string address { get; set; }
        [Required(ErrorMessage = "Gender Can't be Emply")]
        public string gender { get; set; }
        public string status { get; set; }
        public DateTime joinDate { get; set; }
        public DateTime createdAt { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Employee> Employees { get; set; }
        public List<SelectListItem> RoleSelectListItems { get; set; }
    }
}