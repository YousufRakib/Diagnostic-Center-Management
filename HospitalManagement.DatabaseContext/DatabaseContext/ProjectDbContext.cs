using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Model.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HospitalManagement.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext:DbContext
    {
        
        public ProjectDbContext()
        {
            Configuration.LazyLoadingEnabled = false; // Disable Lazy Loading
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(t => t.Admins).WithRequired(a => a.Role).WillCascadeOnDelete(false); //add this line code
            modelBuilder.Entity<Role>().HasMany(t => t.Employees).WithRequired(a => a.Role).WillCascadeOnDelete(false);
            modelBuilder.Entity<Role>().HasMany(t => t.Reports).WithRequired(a => a.Role).WillCascadeOnDelete(false);
            modelBuilder.Entity<Employee>().HasMany(t => t.Accounts).WithRequired(a => a.Employee).WillCascadeOnDelete(false);
            modelBuilder.Entity<Employee>().HasMany(t => t.Reports).WithRequired(a => a.Employee).WillCascadeOnDelete(false);
            modelBuilder.Entity<Test>().HasMany(t => t.Reports).WithRequired(a => a.Test).WillCascadeOnDelete(false);
            modelBuilder.Entity<Test>().HasMany(t => t.Patients).WithRequired(a => a.Test).WillCascadeOnDelete(false);
            //modelBuilder.Entity<Department>().HasMany(t => t.Patients).WithRequired(a => a.Department).WillCascadeOnDelete(false);
            modelBuilder.Entity<Doctor>().HasMany(t => t.Patients).WithRequired(a => a.Doctor).WillCascadeOnDelete(false);
            modelBuilder.Entity<Patient>().HasMany(t => t.Reports).WithRequired(a => a.Patient).WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>().HasMany(t => t.Tests).WithRequired(a => a.Category).WillCascadeOnDelete(false);

            //modelBuilder.Entity<Category>().HasKey(p => p.CategoryId);
            //modelBuilder.Entity<Category>().Property(c => c.CategoryId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //modelBuilder.Entity<Test>().HasKey(b => b.id);
            //modelBuilder.Entity<Test>().Property(b => b.id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //modelBuilder.Entity<Test>().HasRequired(p => p.Category)
            //    .WithMany(b => b.Testss).HasForeignKey(b => b.CategoryId);

            //base.OnModelCreating(modelBuilder);
        }
    }
}
