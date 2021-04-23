using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagement.Model.Model;

namespace HospitalManagement.Models
{
    public class PatientInvoices
    {
        public Patient Patient { get; set; }
        public Invoice Invoice { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}