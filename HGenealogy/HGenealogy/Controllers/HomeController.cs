using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HGenealogy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "客家族譜平台";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "客家族譜平台";

            return View();
        }
    }
}