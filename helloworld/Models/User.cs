﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address{ get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
    }
}