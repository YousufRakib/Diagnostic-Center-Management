using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HospitalManagement.Models
{
    public class AccountViewModel
    {

        public int id { get; set; }
        [Required(ErrorMessage = "Please enter reason")]
        public string reason { get; set; }
        [Required(ErrorMessage = "Type Can't be Emply")]
        public string type { get; set; }
        [Required(ErrorMessage = "Amount can't empty")]
        public int amount { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public List<Account> Accounts { get; set; }
        public List<SelectListItem> EmployeeSelectListItems { get; set; }
    }
}