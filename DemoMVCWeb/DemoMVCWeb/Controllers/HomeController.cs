using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVCWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public string ShowMessage()
        {
            return "Hello MCV Web Application";
        }

        public ActionResult Hello(string msg)
        {
            ViewBag.Message = "Hello : " + msg; // dinamic property คือการจับข้อมูลลงถังกลาง โดยโยน message
            return View();
        }
    }
}