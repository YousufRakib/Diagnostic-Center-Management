using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class DepartmentManager
    {
        DepartmentRepository _departmentRepository = new DepartmentRepository();
        public bool Add(Department department)
        {
            return _departmentRepository.Add(department);
        }

        public bool Delete(Department department)
        {
            return _departmentRepository.Delete(department);
        }
        public bool Update(Department department)
        {
            return _departmentRepository.Update(department);
        }
        public List<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }
    }
}
