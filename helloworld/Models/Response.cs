using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class Response
    {
        public string Token { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int IsAgree { get; set; }
    }
}