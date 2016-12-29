using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace helloworld.Models
{
    public class Accident
    {
        public int Level { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Licenseplate { get; set; }
        public string Street { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
    }
}