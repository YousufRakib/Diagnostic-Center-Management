using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model.Model
{
    public class Category
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }

        //public List<Test> Testss { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
