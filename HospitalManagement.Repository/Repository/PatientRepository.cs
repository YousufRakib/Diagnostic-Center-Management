using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class PatientRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Patient patient)
        {
            _dbContext.Patients.Add(patient);


            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Patient aPatient = _dbContext.Patients.FirstOrDefault((c => c.id == id));
            _dbContext.Patients.Remove(aPatient);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Patient patient)
        {
            Patient aPatient = _dbContext.Patients.FirstOrDefault(c => c.id == patient.id);
            if (aPatient != null)
            {
                aPatient.billId = patient.billId;
                aPatient.bedNo = patient.bedNo;
                aPatient.name = patient.name;
                aPatient.phone = patient.phone;
                aPatient.gender = patient.gender;
                aPatient.status = patient.status;
                aPatient.invoiceDate = patient.invoiceDate;

            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Patient> GetAll()
        {
            return _dbContext.Patients.ToList();
        }
        public Patient GetById(int id)
        {
            return _dbContext.Patients.FirstOrDefault((c => c.id == id));
        }
    }
}
