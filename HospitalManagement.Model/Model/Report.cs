using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Report
    {
        public int id { get; set; }
        public string status { get; set; }
        //PatientId is a foreign key
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        //TestId is a foreign key
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
        public string result { get; set; }
        public DateTime date { get; set; }
        //EmployeeId is a foreign key
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        //RoleId is a foreign key
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int refId { get; set; }
        public DateTime createdAt { get; set; }
    }
}
