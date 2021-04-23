using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class EmployeeRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Employee aEmployee = _dbContext.Employees.FirstOrDefault((c => c.id == id));
            _dbContext.Employees.Remove(aEmployee);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Employee employee)
        {
            Employee aEmployee = _dbContext.Employees.FirstOrDefault(c => c.id == employee.id);
            if (aEmployee != null)
            {
                aEmployee.employeeName = employee.employeeName;
                aEmployee.email = employee.email;
                aEmployee.phone = employee.phone;
                aEmployee.bloodGroup = employee.bloodGroup;
                aEmployee.salary = employee.salary;
                aEmployee.address = employee.address;
                aEmployee.gender = employee.gender;
                aEmployee.joinDate = employee.joinDate;
                aEmployee.status = employee.status;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Employee> GetAll()
        {
            //return _dbContext.Patients.Include(c=>c.Patients).ToList(); //Entity Framework Eager Loading
            /*
            var patients = _dbContext.Patients.ToList();
            _dbContext.Entry(patients)
                    .Collection(c=>c.Patients)
                    .Query()
                    .Where(c=>c.phone.Contains(017))
                    .Load();     
            return patients; //Entity Framework Explicit Loading
            */
            return _dbContext.Employees.ToList();
        }
        public Employee GetById(int id)
        {

            return _dbContext.Employees.FirstOrDefault((c => c.id == id));
        }
    }
}
