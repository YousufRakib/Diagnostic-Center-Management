using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class TestViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Test Name can't be Emply")]
        public string testName { get; set; }
        [Required(ErrorMessage = "Test price can't be Emply")]
        public double price { get; set; }
        [Required(ErrorMessage = "Test room can't be Emply")]
        public int testRoom { get; set; }
        [Required(ErrorMessage = "Test delivery day can't be Emply")]
        public int deliveryDays { get; set; }
        [Required(ErrorMessage = "Please enter test unit")]
        public string unit { get; set; }
        [Required(ErrorMessage = "Please enter test reference range")]
        public string referenceRange { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }

        public int CategoryId { get; set; }        
        public Category Category { get; set; }

        public List<Test> Tests { get; set; }
        public List<SelectListItem> CategorySelectListItems { get; set; }
    }
}