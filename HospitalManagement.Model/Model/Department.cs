using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Department
    {
        public int id { get; set; }
        public string departmentName { get; set; }
        public string status { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }

        //public virtual ICollection<Patient> Patients { get; set; }
    }
}
