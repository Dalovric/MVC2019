using _4._2._1_narudzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4._2._1_narudzba.Controllers
{
    public class ParcijalniPoglediController : Controller
    {
        // GET: ParcijalniPogledi
        public ActionResult PrikaziKosaricu()
        {
            List<Artikal> ListaArtikala = new List<Artikal>()
            {
                new Artikal() {Cijena=9.99m, Kategorija="plava",Kolicina=5, Naziv="Keks" },
                new Artikal() {Cijena=8.99m, Kategorija="žuta",Kolicina=5, Naziv="Banane" },
                new Artikal() {Cijena=7.99m, Kategorija="zelena",Kolicina=5, Naziv="Jabuke" }
            };
            return View();
        }
    }
}