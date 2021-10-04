using ConsumerApplication.Models;
using ConsumerApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService service)
        {
            _employeeService = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult AddEmpl()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmpl(EmployeeDTO empl)
        {
            try
            {
                EmployeeDTO employeeDTO = _employeeService.AddEmpl(empl);
                if(employeeDTO!=null)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            catch 
            {

                return View();
            }
            ViewBag.Error = "Not registered";
            return View();
        }

        public ActionResult GetAll()
        {
            if(TempData["token"]!=null)
            {
                string empl = _employeeService.GetAll(TempData.Peek("token").ToString());
                ViewBag.Employee = empl;
            }
            return View();
            
        }

    }
}
