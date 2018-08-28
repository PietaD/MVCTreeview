using MVCTreeview.context;
using MVCTreeview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTreeview.Controllers
{
    public class TreeviewController : Controller
    {
        EmployeeContext context = new EmployeeContext();

        // GET: Treeview
        public ActionResult Index()
        {
            List<Employee> emps = new List<Employee>();

            //Ordered List of items to get root item as FirstOrDefault()
            emps = context.Employees.OrderBy(e => e.ManagerID).ToList();

            return View(emps);
        }

        // GET: Treeview/Create
        // Needed optional parameter 
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int id = 5)
        {
            //take Employee with id match with selected in form
            var query = context.Employees
                .Where(s => s.EmployeeID == id)
                .FirstOrDefault();

            return View(query);
        }

        // POST: Treeview/Create
        // Add new node below selected Employee
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Create(FormCollection collection, int id = 5)
        {
            try
            {
                Employee emp = new Employee
                {
                    EmployeeName = collection["EmployeeName"],
                    ManagerID = id
                };

                context.Employees.Add(emp);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Treeview/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var query = context.Employees
                .Where(s => s.EmployeeID == id)
                .FirstOrDefault();

            return View(query);
        }

        // POST: Treeview/Edit/5
        // Edit selected item
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var query = context.Employees
                .Where(s => s.EmployeeID == id)
                .FirstOrDefault();

                query.EmployeeName = collection["EmployeeName"];
                query.ManagerID = Int32.Parse(collection["ManagerID"]);


                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Treeview/Delete/6
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 6)
        {
            var query = context.Employees
                .Where(s => s.EmployeeID == id)
                .FirstOrDefault();

            return View(query);
        }

        // POST: Treeview/Delete/6
        // Delete selected item and move its children to upper level (change managerID)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(FormCollection collection, int id = 6)
        {
            try
            {
                //selected employee
                var selected = context.Employees
                    .Where(s => s.EmployeeID == id)
                    .FirstOrDefault();

                //list of chosen node(Manager) employees -> they need to get another ManagerID
                var emps = context.Employees
                    .Where(s => s.ManagerID == id)
                    .ToList();
                
                //each employee get new ManagerID from one level higher
                if (emps.Count > 0 && selected.ManagerID.HasValue)
                {
                    foreach (var item in emps)
                    {
                        item.ManagerID = selected.ManagerID;        
                    }
                }

                context.Employees.Remove(selected);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Treeview/DeleteAll/6
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAll(int id = 6)
        {
            var query = context.Employees
                .Where(s => s.EmployeeID == id)
                .FirstOrDefault();

            return View(query);
        }

        // POST: Treeview/DeleteAll/6
        // Delete all branch
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAll(FormCollection collection, int id = 6)
        {
            try
            {
                //foreach (var item in emps.Where(e => e.ManagerID.Equals(parentID)))
                //{
                //    var children = emps.Where(e => e.ManagerID.Equals(item.EmployeeID)).Count();

                //    if (children > 0)
                //    {
                //        return RedirectToAction ("DeleteAll", children.Count)
                //    }
                //}
                    

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
