using _4._2._1_narudzba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zad6_1_1.Controllers
{
    public class ListaArtikalaController : Controller
    {
        // GET: ListaArtikala
        public ActionResult UnesiArtikal()
        {
            ViewBag.Kategorije = new string[] { "Sport", "Glazba", "Tehnika" };
            return View(new Artikal());
        }
        [HttpPost]
        public ActionResult DodajArtikal(Artikal artikal)
        {
            if (Session["Artikli"]!=null)
            {
                List<Artikal> artikli = (List<Artikal>)Session["Artikli"];
                artikli.Add(artikal);
                Session["Artikli"] = artikli;
            }
            else
            {
                List<Artikal> artikli = new List<Artikal>();
                artikli.Add(artikal);
                Session["Artikli"] = artikli;
            }
            return View(Session["Artikli"]);
        }
    }
}