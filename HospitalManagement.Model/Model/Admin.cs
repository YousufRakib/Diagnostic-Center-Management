using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Admin
    {
        public int id { get; set; }
        public int employeeId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        //RoleId is a foreign key
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public DateTime createdAt { get; set; }
    }
}
