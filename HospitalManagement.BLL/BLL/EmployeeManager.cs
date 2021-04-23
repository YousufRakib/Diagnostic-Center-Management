using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class EmployeeManager
    {
        EmployeeRepository _employeeRepository=new EmployeeRepository();
        public bool Add(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public bool Delete(int id)
        {
            return _employeeRepository.Delete(id);
        }
        public bool Update(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }
        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }
    }
}
