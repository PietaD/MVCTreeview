namespace MVCTreeview.Migrations.EmployeeMigrations
{
    using MVCTreeview.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCTreeview.context.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\EmployeeMigrations";
        }

        protected override void Seed(MVCTreeview.context.EmployeeContext context)
        {
            //Not working!

            //context.Employees.AddOrUpdate(
            //  p => p.EmployeeName,
            //  new Employee { EmployeeName = "Root", EmployeeID = 1 },
            //  new Employee { EmployeeName = "John", ManagerID = 1 },
            //  new Employee { EmployeeName = "Thomas", ManagerID = 4 },
            //  new Employee { EmployeeName = "Eric", ManagerID = 1 },
            //  new Employee { EmployeeName = "Jessica", ManagerID = 4 },
            //  new Employee { EmployeeName = "Kate", ManagerID = 2 },
            //  new Employee { EmployeeName = "Bob", ManagerID = 6 },
            //  new Employee { EmployeeName = "Steven", ManagerID = 7 },
            //  new Employee { EmployeeName = "Joanna", ManagerID = 7 },
            //  new Employee { EmployeeName = "Tim", ManagerID = 2 },
            //  new Employee { EmployeeName = "Rebeca", ManagerID = 2 },
            //  new Employee { EmployeeName = "Peter", ManagerID = 8 }
            //);
        }
    }
}
