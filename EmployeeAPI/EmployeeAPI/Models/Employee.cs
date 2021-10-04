using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        [Key]
        public string EmpId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
