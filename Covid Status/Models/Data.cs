using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid_Status.Models
{
    public class Data
    {
        public string Location { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public int Active { get; set; }   
    }
}