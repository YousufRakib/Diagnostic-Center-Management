using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Expense
    {
        public int id { get; set; }
        public string itemName { get; set; }
        public string purchaseFrom { get; set; }
        public string status { get; set; }
        public DateTime purchaseDate { get; set; }
        public double amount { get; set; }

        public DateTime createdAt { get; set; }
    }
}
