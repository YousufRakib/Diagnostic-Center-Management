using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Test
    {
        public int id { get; set; }
        public string testName { get; set; }
        public double price { get; set; }
        public int testRoom { get; set; }
        public int deliveryDays { get; set; }
        public string status { get; set; }
        public string unit { get; set; }
        public string referenceRange { get; set; }
        public DateTime createdAt { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
