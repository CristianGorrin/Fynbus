using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fynbus2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Vehicles()
        {
            return View();
        }

        public ActionResult Offers()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            return View();
        }

        public ActionResult AddOffer()
        {
            return View();
        }

        public ActionResult EditVehicle(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
