using _4._2._1_narudzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4._2._1_narudzba.Controllers
{
    public class HtmlHelperiController : Controller
    {
        // GET: HtmlHelperi
        public ActionResult Index()
        {
            return View();

        }

        private string[] mjesta = new string[]
        {
            "Split", "Osijek", "Zadar", "Rijeka"
        };
        public ViewResult FormHelper()
        {
            ViewBag.Mjesta = this.mjesta;
            return View(new Osoba());
        }
        public ViewResult StrongTypedFormHelper()
        {
            ViewBag.Mjesta = this.mjesta;
            return View(new Osoba());
        }

    }
}