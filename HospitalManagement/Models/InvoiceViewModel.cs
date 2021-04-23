using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class InvoiceViewModel
    {
        public int id { get; set; }
        public int testId { get; set; }
        public double price { get; set; }
        public string testRoom { get; set; }
        public string unit { get; set; }
        public string referenceRange { get; set; }
        public string testResult { get; set; }
        public string status { get; set; }
        public int patientId { get; set; }
        public string billId { get; set; }
        public DateTime createdAt { get; set; }
    }
}