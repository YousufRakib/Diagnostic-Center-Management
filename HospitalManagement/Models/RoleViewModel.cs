using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class RoleViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Role Name Can't be Emply")]
        public string roleName { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public List<Role> Roles { get; set; }

    }
}