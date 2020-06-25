using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            /*Get fN (Pre) */
            ViewBag.Message = "Enter in 3 numbers to be converted into a color!";
            ViewBag.first = Request["firstcolor"];
            ViewBag.second = Request["secondcolor"];
            ViewBag.third = Request["thirdcolor"];
           

           



            return View(); 
        }

        [HttpPost]
        public ActionResult About(int? firstcolor, int? secondcolor, int? thirdcolor)
        {
            /*Post fN (Post) */
            ViewBag.Message = "Your application description page.";
            ViewBag.Random = "Trying to get this to work";
            ViewBag.StateList = "";
            ViewBag.first = Request["firstcolor"];
            ViewBag.second = Request["secondcolor"];
            ViewBag.third = Request["thirdcolor"]; 
           

           
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}