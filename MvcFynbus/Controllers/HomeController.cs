using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFynbus.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        // Login
        public ActionResult Index()
        {
            return View();
        }

        // New vehicle
        public ActionResult Add_vehicle()
        {
            return View();
        }

        // New offer
        public ActionResult Add_offer()
        {
            return View();
        }

        // All offers from user
        public ActionResult Offers()
        {
            return View();
        }

        // User information
        public ActionResult Info()
        {
            return View();
        }

        public ActionResult StyleSheet()
        {
            return View("StyleSheet.css");
        }
    }
}
