using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Account
    {
        public int id { get; set; }
        
        public string reason { get; set; }
        public string type { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; }
        public DateTime createdAt { get; set; }
        //EmployeeId is a foreign key
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
