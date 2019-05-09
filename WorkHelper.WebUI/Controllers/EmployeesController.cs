using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkHelper.BLL.Interfaces;

namespace WorkHelper.WebUI.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: Employees
        public ActionResult Index()
        {
            return View(employeeService.GetEmployees());
        }

        protected override void Dispose(bool disposing)
        {
            employeeService.Dispose();
            base.Dispose(disposing);
        }
    }
}