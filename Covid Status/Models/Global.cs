using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid_Status.Models
{
    public class Global
    {
        public List<Data> data { get; set; }
        public string dt { get; set; }
        public string ts { get; set; }
    }
}