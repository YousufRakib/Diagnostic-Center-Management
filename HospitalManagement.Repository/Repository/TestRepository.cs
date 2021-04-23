using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class TestRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Test test)
        {
            _dbContext.Tests.Add(test);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Test aTest= _dbContext.Tests.FirstOrDefault((c => c.id == id));
            _dbContext.Tests.Remove(aTest);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Test test)
        {
            Test aTest = _dbContext.Tests.FirstOrDefault((c => c.id == test.id));
            if (aTest != null)
            {
                aTest.testName = test.testName;
                aTest.price = test.price;
                aTest.testRoom = test.testRoom;
                aTest.deliveryDays = test.deliveryDays;
                aTest.unit = test.unit;
                aTest.referenceRange = test.referenceRange;
                aTest.status = test.status;
            }
            return _dbContext.SaveChanges() > 0;
        }

        public List<Test> GetAll()
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
            return _dbContext.Tests.ToList();
        }
        public Test GetById(int id)
        {
            return _dbContext.Tests.FirstOrDefault((c => c.id == id));
        }
    }
}
