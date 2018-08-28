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
            context.Employees.AddOrUpdate(
              p => p.EmployeeName,
              new Employee { EmployeeID = 1, EmployeeName = "Root", ManagerID = null },
              new Employee { EmployeeID = 2, EmployeeName = "John", ManagerID = 1 },
              new Employee { EmployeeID = 3, EmployeeName = "Thomas", ManagerID = 4 },
              new Employee { EmployeeID = 4, EmployeeName = "Eric", ManagerID = 1 },
              new Employee { EmployeeID = 5, EmployeeName = "Jessica", ManagerID = 4 },
              new Employee { EmployeeID = 6, EmployeeName = "Kate", ManagerID = 2 },
              new Employee { EmployeeID = 7, EmployeeName = "Bob", ManagerID = 6 },
              new Employee { EmployeeID = 8, EmployeeName = "Steven", ManagerID = 7 },
              new Employee { EmployeeID = 9, EmployeeName = "Joanna", ManagerID = 7 },
              new Employee { EmployeeID = 10, EmployeeName = "Tim", ManagerID = 2 },
              new Employee { EmployeeID = 11, EmployeeName = "Rebeca", ManagerID = 2 },
              new Employee { EmployeeID = 12, EmployeeName = "Peter", ManagerID = 8 }
            );
        }
    }
}
