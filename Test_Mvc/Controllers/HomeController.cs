using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Test_Mvc.Models;

namespace Test_Mvc.Controllers
{
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:49724/");
        HttpClient Client;

        public HomeController()
        {
            Client = new HttpClient();
            Client.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDetail(Class1 model)
        {
            string data = JsonConvert.SerializeObject(model);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage res = Client.PostAsync(Client.BaseAddress + "Test/givedetail", content).Result;

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Table");

            }
            return View();
        }
        public ActionResult Table()
        {
            List<Class1> obj = new List<Class1>();
            HttpResponseMessage emp=Client.GetAsync(Client.BaseAddress + "Test/GetDetail").Result;
            if(emp.IsSuccessStatusCode)
            {
                string data =emp.Content.ReadAsStringAsync().Result;
                obj = JsonConvert.DeserializeObject<List<Class1>>(data);
            }
            return View(obj);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}