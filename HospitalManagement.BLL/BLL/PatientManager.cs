using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.Repository.Repository;

namespace HospitalManagement.BLL.BLL
{
    public class PatientManager
    {
        PatientRepository _patientRepository=new PatientRepository();
        public bool Add(Patient patient)
        {
            return _patientRepository.Add(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }
        public bool Update(Patient patient)
        {
            return _patientRepository.Update(patient);
        }
        public List<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }
        public Patient GetById(int id)
        {
            return _patientRepository.GetById(id);
        }
    }
}
