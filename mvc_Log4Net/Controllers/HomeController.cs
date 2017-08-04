using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_Log4Net2NLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //***Log4Net_Test
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Check log file and db log for debug, error, info and warning messages";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";
            return View();
        }
    }
}