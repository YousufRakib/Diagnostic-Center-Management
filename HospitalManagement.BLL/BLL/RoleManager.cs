using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class RoleManager
    {
        RoleRepository _roleRepository = new RoleRepository();
        public bool Add(Role role)
        {
            return _roleRepository.Add(role);
        }

        public bool Delete(int id)
        {
            return _roleRepository.Delete(id);
        }
        public bool Update(Role role)
        {
            return _roleRepository.Update(role);
        }
        public List<Role> GetAll()
        {
            return _roleRepository.GetAll();
        }
        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }
    }
}
