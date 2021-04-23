using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Doctor
    {
        public int id { get; set; }
        public string doctorName { get; set; }
        public int phone { get; set; }
        public string designation { get; set; }
        public string status { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
        public double testCommission { get; set; }
        public int refId { get; set; }
        public string gender { get; set; }
        public string hospitalName { get; set; }
        public string type { get; set; }
        public string info { get; set; }
        public DateTime createdAt { get; set; }


        public virtual ICollection<Patient> Patients { get; set; }
    }
}
