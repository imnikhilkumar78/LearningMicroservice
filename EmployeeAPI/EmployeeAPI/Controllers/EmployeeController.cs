using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AddEmployee _service;

        public EmployeeController(AddEmployee service)
        {
            _service = service;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return null;
        }

        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            var empl = _service.AddEmpl(employee);
            if (empl != null)
                return empl;
            return BadRequest(error: "Not Able to Add");
        }
    }
}
