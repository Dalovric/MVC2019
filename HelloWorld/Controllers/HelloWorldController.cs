using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult PopisKosarice()
        {
            return View();
        }
        public ActionResult ListaArtikala()
        {
            string[] lista = new string[] { "Skije", "Pancerice", "Sunčane naočale", "Šal", "Kapa" };
            ViewBag.Lista = lista;
            return View();
        }

        public ActionResult RedirectNaMetodu(string id)
        {
            if (id=="Kosarica")
            {
                return RedirectToAction("PopisKosarice");
            }
            else
            {
                return RedirectToAction("ListaArtikala");
            }
        }
    }
}