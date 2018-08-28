using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTreeview.Models
{
    public class Employee
    {
        //Data properties
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        //nullable to provide a root item
        public int? ManagerID { get; set; }

        //Navigation property
        public Employee Manager { get; set; }

    }

    
}