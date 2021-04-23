using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Patient
    {
        public int id { get; set; }
        public string billId { get; set; }
        public int bedNo { get; set; }
        public string name { get; set; }
        public int phone { get; set; }
        public string status { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string info { get; set; }
        public DateTime invoiceDate { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string doctorName { get; set; }
        public int refId { get; set; }
        public double subTotal { get; set; }
        public double discount { get; set; }
        public double deductAmmount { get; set; }
        public double totalAmmount { get; set; }
        public string totalAmmountInText { get; set; }
        public double paidAmmount { get; set; }
        public double dueAmmount { get; set; }
        public string paymentStatus { get; set; }
        public string deliveryDate { get; set; }
        public string deliveryTime { get; set; }
        public string remark { get; set; }
        public string paymentBy { get; set; }
        public DateTime createdAt { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
