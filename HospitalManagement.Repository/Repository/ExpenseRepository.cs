using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class ExpenseRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Expense expense)
        {
            _dbContext.Expenses.Add(expense);


            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(Expense expense)
        {
            Expense aExpense = _dbContext.Expenses.FirstOrDefault((c => c.id == expense.id));
            _dbContext.Expenses.Remove(aExpense);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Expense expense)
        {
            Expense aExpense = _dbContext.Expenses.FirstOrDefault((c => c.id == expense.id));
            if (aExpense != null)
            {
                aExpense.itemName = expense.itemName;
                aExpense.purchaseFrom = expense.purchaseFrom;
                aExpense.purchaseDate = expense.purchaseDate;
                aExpense.amount = expense.amount;
                aExpense.status = expense.status;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Expense> GetAll()
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
            return _dbContext.Expenses.ToList();
        }
        public Expense GetById(int id)
        {

            return _dbContext.Expenses.FirstOrDefault((c => c.id == id));
        }
    }
}
