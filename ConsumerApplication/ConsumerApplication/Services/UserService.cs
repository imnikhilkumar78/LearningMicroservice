using ConsumerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsumerApplication.Services
{
    public class UserService
    {
        public UserDTO Register(UserDTO userDTO)
        {
            UserDTO userDTO1 = null;
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:16830/api/");
                var postTask = client.PostAsJsonAsync<UserDTO>("User", userDTO);
                postTask.Wait();
                var result = postTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    userDTO1 = data.Result;
                }
            }
            return userDTO1;
        }

        public UserDTO Login(UserDTO userDTO)
        {
            UserDTO userDTO1 = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:16830/api/");
                var postTask = client.PostAsJsonAsync<UserDTO>("User/Login", userDTO);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    userDTO1 = data.Result;
                }
            }
            return userDTO1;
        }
    }
}
