﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerApplication.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Password { get; set; }

        public string jwtToken { get; set; }
    }
}
