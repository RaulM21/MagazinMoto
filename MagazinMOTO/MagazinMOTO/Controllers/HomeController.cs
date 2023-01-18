using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazinMOTO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Magazin moto. Cumperi 1 primesti 2";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Incearca, vezi daca poti";

            return View();
        }
    }
}