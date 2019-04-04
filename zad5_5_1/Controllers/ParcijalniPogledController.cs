using _4._2._1_narudzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zad5_5_1.Controllers
{
    public class ParcijalniPogledController : Controller
    {
        // GET: ParcijalniPogled
        public ActionResult ObradiListu()
        {
            List<Artikal> artikli = new List<Artikal>()
            {
                new Artikal() {Naziv = "Nogometna lopta", Cijena = 250.60m},
                new Artikal() {Naziv = "Električna gitara", Cijena=1890},
                new Artikal() {Naziv = "LED TV", Cijena=3560.99m}
            };

            return View(artikli);
        }
    }
}