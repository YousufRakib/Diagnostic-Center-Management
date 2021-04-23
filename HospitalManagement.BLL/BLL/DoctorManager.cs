using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class DoctorManager
    {
        DoctorRepository _doctorRepository = new DoctorRepository();
        //public bool Add(Doctor doctor)
        //{
        //    return _doctorRepository.Add(doctor);
        //}
        public bool Add(List<Doctor> Doctors)
        {
            return _doctorRepository.Add(Doctors);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }
        public bool Update(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }
        public List<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }
        public Doctor GetById(int id)
        {
            return _doctorRepository.GetById(id);
        }
    }
}
