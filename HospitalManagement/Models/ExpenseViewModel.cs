using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HospitalManagement.Models
{
    public class ExpenseViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Item name can't empty")]
        public string itemName { get; set; }
        [Required(ErrorMessage = "Where are you purchase from")]
        public string purchaseFrom { get; set; }
        public DateTime purchaseDate { get; set; }
        [Required(ErrorMessage = "Amount can't empty")]
        public int amount { get; set; }
        public string status { get; set; }

        public DateTime createdAt { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}