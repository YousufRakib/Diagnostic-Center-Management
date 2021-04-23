using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Employee
    {
        //public Employee()
        //{
        //    Accounts = new List<Account>();
        //}
        public int id { get; set; }
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public string bloodGroup { get; set; }
        public int salary { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public string gender { get; set; }
        public DateTime joinDate { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public DateTime createdAt { get; set; }
        //public List<Account> Accounts { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
