using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class RoleRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Role role)
        {
            _dbContext.Roles.Add(role);


            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Role aRole = _dbContext.Roles.FirstOrDefault((c => c.id == id));
            _dbContext.Roles.Remove(aRole);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Role role)
        {
            Role aRole = _dbContext.Roles.FirstOrDefault((c => c.id == role.id));
            if (aRole != null)
            {
                //Account account = Mapper.Map<Account>(accountViewModel);
                //aAccount.EmployeeId = account.EmployeeId;
                aRole.roleName = role.roleName;
                aRole.status = role.status;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Role> GetAll()
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
            return _dbContext.Roles.ToList();
        }
        public Role GetById(int id)
        {

            return _dbContext.Roles.FirstOrDefault((c => c.id == id));
        }
    }
}
