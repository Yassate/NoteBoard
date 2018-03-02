using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoteBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bool val1 = User.Identity.IsAuthenticated;
            if (val1)
            {
                return RedirectToAction("Private", "Board");

            }
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
    }
}