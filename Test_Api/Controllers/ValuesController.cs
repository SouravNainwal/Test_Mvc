using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test_Api.DataContext;
using Test_Api.Models;

namespace Test_Api.Controllers
{
    public class ValuesController : ApiController
    {
        EmployeeEntities obj = new EmployeeEntities();
        [HttpGet]
        [Route("Test/GetDetail")]
        public List<Emp_Details> GetDetail()
        {            
            List<Emp_Details> list = new List<Emp_Details>();
            var res = obj.Emp_Details.ToList();
            return res;
        }
        [HttpPost]
        [Route("Test/givedetail")]
        public HttpResponseMessage saveemp(EmpClass objj)
        {
            Emp_Details abj=new Emp_Details();
             abj.name= objj.name;
            abj.email_id=objj.email_id;
            abj.Phone_no = objj.Phone_no;

            obj.Emp_Details.Add(abj);
            obj.SaveChanges();

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            return response;
        }
    }
}
