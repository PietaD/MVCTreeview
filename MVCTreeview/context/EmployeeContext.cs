using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCTreeview.Models;

namespace MVCTreeview.context
{
    public class EmployeeContext : DbContext
    {
        //Assign DefaultConnection (default for authentication) to EmployeeContext
        public EmployeeContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }

        //Ovveride modelbuilder to get self referencing table
        //Employees can have 1 or 0 Managers
        //Manager can have 0 or more Employees
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Manager)
                .WithMany()
                .HasForeignKey(m => m.ManagerID);

            base.OnModelCreating(modelBuilder);
        }
    }
}