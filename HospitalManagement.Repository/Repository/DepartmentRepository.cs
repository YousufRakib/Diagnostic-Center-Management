using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class DepartmentRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Department department)
        {
            _dbContext.Departments.Add(department);


            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(Department department)
        {
            Department aDepartment = _dbContext.Departments.FirstOrDefault((c => c.id == department.id));
            _dbContext.Departments.Remove(aDepartment);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Department department)
        {
            Department aDepartment = _dbContext.Departments.FirstOrDefault((c => c.id == department.id));
            if (aDepartment != null)
            {
                aDepartment.departmentName = department.departmentName;
                aDepartment.status = department.status;
                aDepartment.description = department.description;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Department> GetAll()
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
            return _dbContext.Departments.ToList();
        }
        public Department GetById(int id)
        {

            return _dbContext.Departments.FirstOrDefault((c => c.id == id));
        }
    }
}
