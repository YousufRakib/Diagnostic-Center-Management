using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class TestManager
    {
        TestRepository _testRepository = new TestRepository();
        public bool Add(Test test)
        {
            return _testRepository.Add(test);
        }

        public bool Delete(int id)
        {
            return _testRepository.Delete(id);
        }
        public bool Update(Test test)
        {
            return _testRepository.Update(test);
        }
        public List<Test> GetAll()
        {
            return _testRepository.GetAll();
        }
        public Test GetById(int id)
        {
            return _testRepository.GetById(id);
        }
    }
}
