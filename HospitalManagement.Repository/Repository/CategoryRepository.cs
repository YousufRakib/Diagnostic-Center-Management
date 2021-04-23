using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class CategoryRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Category category)
        {
            _dbContext.Categorys.Add(category);


            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(Category category)
        {
            Category aCategory = _dbContext.Categorys.FirstOrDefault((c => c.id == category.id));
            _dbContext.Categorys.Remove(aCategory);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Category category)
        {
            Category aCategory = _dbContext.Categorys.FirstOrDefault((c => c.id == category.id));
            if (aCategory != null)
            {
                aCategory.CategoryName = category.CategoryName;
                aCategory.status = category.status;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Category> GetAll()
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
            return _dbContext.Categorys.ToList();
        }
        public Category GetById(int id)
        {

            return _dbContext.Categorys.FirstOrDefault((c => c.id == id));
        }
    }
}
