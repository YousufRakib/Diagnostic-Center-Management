using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Invoice
    {
        public int id { get; set; }
        public int testId { get; set; }
        public double price { get; set; }
        public string unit { get; set; }
        public string referenceRange { get; set; }
        public string testResult { get; set; }
        public string testRoom { get; set; }
        public string status { get; set; }
        public int patientId { get; set; }
        public string billId { get; set; }
        public DateTime createdAt { get; set; }
    }
}
