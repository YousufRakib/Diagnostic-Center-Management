using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Role
    {
        //public Role()
        //{
        //    Employees = new List<Employee>();
        //}
        public int id { get; set; }
        public string roleName { get; set; }
        public DateTime createdAt { get; set; }
        public string status { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }


        //public List<Employee> Employees { get; set; }
    }
}
