using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class AccountRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Account account)
        {
            _dbContext.Accounts.Add(account);


            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Account aAccount = _dbContext.Accounts.FirstOrDefault((c => c.id == id));
            _dbContext.Accounts.Remove(aAccount);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Account account)
        {
            Account aAccount = _dbContext.Accounts.FirstOrDefault((c => c.id == account.id));
            if (aAccount != null)
            {
                //Account account = Mapper.Map<Account>(accountViewModel);
                //aAccount.EmployeeId = account.EmployeeId;
                aAccount.reason = account.reason;
                aAccount.type = account.type;
                aAccount.amount = account.amount;
                aAccount.date = account.date;
                aAccount.status = account.status;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Account> GetAll()
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
            return _dbContext.Accounts.ToList();
        }
        public Account GetById(int id)
        {

            return _dbContext.Accounts.FirstOrDefault((c => c.id == id));
        }
    }
}
