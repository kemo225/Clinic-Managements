﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccessLayerClinics.Login
{
    public class DtoLogin
{
        public string Username { get; set; }
        public string Password { get; set; }
        public DtoLogin(string username, string password)
        {
            Username = username;
            Password = password;
        }
        
    }
}
