namespace HospitalManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        reason = c.String(),
                        type = c.String(),
                        amount = c.Int(nullable: false),
                        status = c.String(),
                        date = c.DateTime(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        employeeId = c.Int(nullable: false),
                        employeeName = c.String(),
                        email = c.String(),
                        phone = c.Int(nullable: false),
                        bloodGroup = c.String(),
                        salary = c.Int(nullable: false),
                        address = c.String(),
                        status = c.String(),
                        gender = c.String(),
                        joinDate = c.DateTime(nullable: false),
                        RoleId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        PatientId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        result = c.String(),
                        date = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        refId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .ForeignKey("dbo.Patients", t => t.PatientId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.PatientId)
                .Index(t => t.TestId)
                .Index(t => t.EmployeeId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        billId = c.String(),
                        bedNo = c.Int(nullable: false),
                        name = c.String(),
                        phone = c.Int(nullable: false),
                        status = c.String(),
                        gender = c.String(),
                        age = c.String(),
                        info = c.String(),
                        invoiceDate = c.DateTime(nullable: false),
                        TestId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        doctorName = c.String(),
                        refId = c.Int(nullable: false),
                        subTotal = c.Double(nullable: false),
                        discount = c.Double(nullable: false),
                        deductAmmount = c.Double(nullable: false),
                        totalAmmount = c.Double(nullable: false),
                        totalAmmountInText = c.String(),
                        paidAmmount = c.Double(nullable: false),
                        dueAmmount = c.Double(nullable: false),
                        paymentStatus = c.String(),
                        deliveryDate = c.String(),
                        deliveryTime = c.String(),
                        remark = c.String(),
                        paymentBy = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.TestId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        doctorName = c.String(),
                        phone = c.Int(nullable: false),
                        designation = c.String(),
                        status = c.String(),
                        TestId = c.Int(nullable: false),
                        testCommission = c.Double(nullable: false),
                        refId = c.Int(nullable: false),
                        gender = c.String(),
                        hospitalName = c.String(),
                        type = c.String(),
                        info = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        testName = c.String(),
                        price = c.Double(nullable: false),
                        testRoom = c.Int(nullable: false),
                        deliveryDays = c.Int(nullable: false),
                        status = c.String(),
                        unit = c.String(),
                        referenceRange = c.String(),
                        createdAt = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        status = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        roleName = c.String(),
                        createdAt = c.DateTime(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        employeeId = c.Int(nullable: false),
                        email = c.String(),
                        password = c.String(),
                        status = c.String(),
                        RoleId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        departmentName = c.String(),
                        status = c.String(),
                        description = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        itemName = c.String(),
                        purchaseFrom = c.String(),
                        status = c.String(),
                        purchaseDate = c.DateTime(nullable: false),
                        amount = c.Double(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        testId = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        unit = c.String(),
                        referenceRange = c.String(),
                        testResult = c.String(),
                        testRoom = c.String(),
                        status = c.String(),
                        patientId = c.Int(nullable: false),
                        billId = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Reports", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Reports", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Reports", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Patients", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Patients", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Accounts", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Admins", new[] { "RoleId" });
            DropIndex("dbo.Tests", new[] { "CategoryId" });
            DropIndex("dbo.Doctors", new[] { "TestId" });
            DropIndex("dbo.Patients", new[] { "DoctorId" });
            DropIndex("dbo.Patients", new[] { "TestId" });
            DropIndex("dbo.Reports", new[] { "RoleId" });
            DropIndex("dbo.Reports", new[] { "EmployeeId" });
            DropIndex("dbo.Reports", new[] { "TestId" });
            DropIndex("dbo.Reports", new[] { "PatientId" });
            DropIndex("dbo.Employees", new[] { "RoleId" });
            DropIndex("dbo.Accounts", new[] { "EmployeeId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Expenses");
            DropTable("dbo.Departments");
            DropTable("dbo.Admins");
            DropTable("dbo.Roles");
            DropTable("dbo.Categories");
            DropTable("dbo.Tests");
            DropTable("dbo.Doctors");
            DropTable("dbo.Patients");
            DropTable("dbo.Reports");
            DropTable("dbo.Employees");
            DropTable("dbo.Accounts");
        }
    }
}
