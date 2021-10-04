using ConsumerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsumerApplication.Services
{
    public class EmployeeService
    {
        public ICollection<EmployeeDTO> GetAll()
        {
            ICollection<EmployeeDTO> empl = null;
            using (var client = new HttpClient())
            {
               
                client.BaseAddress = new Uri("http://localhost:19206/api/");
                var getTask = client.GetFromJsonAsync<EmployeeDTO>("Employee");
                getTask.Wait();
                var result = getTask.Result;
                empl = (ICollection<EmployeeDTO>)result;
               
            }
            return empl;
        }

        public EmployeeDTO AddEmpl(EmployeeDTO empl)
        {
            EmployeeDTO employeeDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:19206/api/");
                var postTask = client.PostAsJsonAsync<EmployeeDTO>("Employee", empl);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<EmployeeDTO>();
                    data.Wait();
                    employeeDTO = data.Result;
                }
            }
            return employeeDTO;
        }

    }

   
}
