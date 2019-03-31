using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4._2._1_narudzba.Controllers
{
    public class NarudzbaArtiklaController : Controller
    {
        
        public ViewResult NaruciArtikal()
        {
            return View(new Artikal());
        }
        [HttpPost]
        public ViewResult NaruciArtikal(Artikal artikal)
        {
            if (artikal.Kolicina > 10)
            {
                ViewBag.Poruka = "Nema dovoljno" + artikal.Naziv + "na skladištu!";
                return View(artikal);
            }
            else
            {
                ViewBag.Poruka = "Naruceno je " +
                    artikal.Kolicina +
                    "komada" +
                    artikal.Naziv +
                    "sa ukupnom cijenom" +
                    artikal.Cijena * artikal.Kolicina;
                return View(artikal);
            }
        }
    }
}