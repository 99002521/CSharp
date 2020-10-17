using MvcRetry.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRetry.Controllers
{
    public class DemoController : Controller
    {
        public ViewResult GetAllRecords()                           //*******
        {
            var context = new MyDatabase();
            var model = context.EmpTables.ToList();
            return View(model);
        }

        public ViewResult NewEmployee()
        {
            var model = new EmpTable();
            return View(model);
        }

        [HttpPost]
        public ActionResult NewEmployee(EmpTable emp)
        {
            try
            {
                var context = new MyDatabase();
                context.EmpTables.Add(emp);
                context.SaveChanges();
                return RedirectToAction("GetAllRecords");
            }
            catch
            {
                return RedirectToAction("GetAllRecords");
            }

        }

        public ViewResult Update(string id)
        {
            int empId = int.Parse(id);
            var context = new MyDatabase();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == empId);
            return View(model);

        }
        [HttpPost]
        public ActionResult Update(EmpTable emp)
        {
            var context = new MyDatabase();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == emp.EmpID);
            model.EmpName = emp.EmpName;
            model.EmpAddress = emp.EmpAddress;
            model.EmpSalary = emp.EmpSalary;
            context.SaveChanges();
            return RedirectToAction("GetAllRecords");
        }

        public ActionResult Delete(string id)
        {
            int empId = int.Parse(id);
            var context = new MyDatabase();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == empId);
            context.EmpTables.Remove(model);
            context.SaveChanges();
            return RedirectToAction("GetAllRecords");
        }

    }


}