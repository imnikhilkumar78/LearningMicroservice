﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Models;

namespace UserApi.Services
{
    public interface ITokenService
    {
        public string CreateToken(UserDTO userDTO);
    }
}
