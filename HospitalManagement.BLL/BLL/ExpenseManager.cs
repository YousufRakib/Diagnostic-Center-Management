using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class ExpenseManager
    {
        ExpenseRepository _expenseRepository = new ExpenseRepository();
        public bool Add(Expense expense)
        {
            return _expenseRepository.Add(expense);
        }

        public bool Delete(Expense expense)
        {
            return _expenseRepository.Delete(expense);
        }
        public bool Update(Expense expense)
        {
            return _expenseRepository.Update(expense);
        }
        public List<Expense> GetAll()
        {
            return _expenseRepository.GetAll();
        }
        public Expense GetById(int id)
        {
            return _expenseRepository.GetById(id);
        }
    }
}
