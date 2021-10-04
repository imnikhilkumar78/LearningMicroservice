using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class AddEmployee
    {
        private readonly EmployeeContext _context;

        public AddEmployee(EmployeeContext context)
        {
            _context = context;
        }

        public Employee AddEmpl(Employee empl)
        {
            try
            {
                _context.Employees.Add(empl);
                _context.SaveChanges();
                return empl;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }
        public ICollection<Employee> GetAll()
        {
            if (_context.Employees.ToList().Count > 0)
                return _context.Employees.ToList();
            return null;
        }
    }
}
