using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using AutoMapper;
using HospitalManagement.Model.Model;
using HospitalManagement.Models;

namespace HospitalManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PatientViewModel,Patient>();
                cfg.CreateMap<Patient,PatientViewModel>();

                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<Category, CategoryViewModel>();

                cfg.CreateMap<AccountViewModel, Account>();
                cfg.CreateMap<Account, AccountViewModel>();

                cfg.CreateMap<EmployeeViewModel, Employee>();
                cfg.CreateMap<Employee, EmployeeViewModel>();

                //cfg.CreateMap<DoctorViewModel, Doctor>();
                //cfg.CreateMap<Doctor, DoctorViewModel>();

                cfg.CreateMap<RoleViewModel, Role>();
                cfg.CreateMap<Role, RoleViewModel>();

                cfg.CreateMap<TestViewModel, Test>();
                cfg.CreateMap<Test, TestViewModel>();

                cfg.CreateMap<DepartmentViewModel, Department>();
                cfg.CreateMap<Department, DepartmentViewModel>();

                cfg.CreateMap<ExpenseViewModel, Expense>();
                cfg.CreateMap<Expense, ExpenseViewModel>();

                cfg.CreateMap<InvoiceViewModel, Invoice>();
                cfg.CreateMap<Invoice, InvoiceViewModel>();

            });
        }
    }
}
