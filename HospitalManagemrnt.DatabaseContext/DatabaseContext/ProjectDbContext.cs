using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;

namespace HospitalManagemrnt.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}
