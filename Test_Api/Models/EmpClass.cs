using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_Api.Models
{
    public class EmpClass
    {
        public string id { get;  set; }
        public string name { get; set; }
        public string email_id { get; set; }
        public Nullable<long> Phone_no { get; set; }
    }
}