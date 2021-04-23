using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using HospitalManagement.DatabaseContext.DatabaseContext;

namespace HospitalManagement.Repository.Repository
{
    public class DoctorRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(List<Doctor> doctor)
        {
            //int isExecuted = 0;
            _dbContext.Doctors.AddRange(doctor);

            //isExecuted = _dbContext.SaveChanges();

            //if (isExecuted > 0)
            //{
            //    return true;
            //}

            //return false;
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Doctor aDoctor = _dbContext.Doctors.FirstOrDefault((c => c.id == id));
            _dbContext.Doctors.Remove(aDoctor);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Doctor doctor)
        {
            Doctor aDoctor = _dbContext.Doctors.FirstOrDefault((c => c.id == doctor.id));
            if (aDoctor != null)
            {
                //Account account = Mapper.Map<Account>(accountViewModel);
                //aAccount.EmployeeId = account.EmployeeId;
                aDoctor.doctorName = doctor.doctorName;
                aDoctor.phone = doctor.phone;
                aDoctor.designation = doctor.designation;
                aDoctor.gender = doctor.gender;
                aDoctor.refId = doctor.refId;
                aDoctor.hospitalName = doctor.hospitalName;
                aDoctor.status = doctor.status;
                aDoctor.type = doctor.type;
                aDoctor.info = doctor.info;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Doctor> GetAll()
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
            return _dbContext.Doctors.ToList();
        }
        public Doctor GetById(int id)
        {

            return _dbContext.Doctors.FirstOrDefault((c => c.id == id));
        }
    }
}
