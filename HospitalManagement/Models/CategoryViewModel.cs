using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class CategoryViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Category name Can't be Emply")]
        public string CategoryName { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }

        public List<Category> Categories { get; set; }
        //public List<Test> Tests { get; set; }
    }
}