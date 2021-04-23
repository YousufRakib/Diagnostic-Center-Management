using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class AccountManager
    {
        AccountRepository _accountRepository=new AccountRepository();
        public bool Add(Account account)
        {
            return _accountRepository.Add(account);
        }

        public bool Delete(int id)
        {
            return _accountRepository.Delete(id);
        }
        public bool Update(Account account)
        {
            return _accountRepository.Update(account);
        }
        public List<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }
        public Account GetById(int id)
        {
            return _accountRepository.GetById(id);
        }
    }
}
