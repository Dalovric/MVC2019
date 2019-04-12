using _8_4_WebShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace _8_4_WebShop.Controllers
{
    public class CartController : Controller
    {
        private WebShop2Entities db = new WebShop2Entities();
        public static List<Proizvodi> lstProizvodi = new List<Proizvodi>();
        // GET: Cart
        public ActionResult Index()
        {
            if(Session["Cart"]!=null)
            {
                lstProizvodi = Session["Cart"] as List<Proizvodi>;
            }

            return View(lstProizvodi);
            
        }
        // GET: Cart/AddToCart/{id}
        public ActionResult AddToCart(int id)
        {
            /*
            if (Session["Cart"] != null)
            {
                lstProizvodi = Session["Cart"] as List<Proizvodi>;
            }
            */
            Proizvodi proizvodi = db.Proizvodis.Find(id);
            lstProizvodi.Add(proizvodi);
            Session["Cart"] = lstProizvodi;
            if(proizvodi == null)
            {
                return HttpNotFound("Greska: Proizvod nije nadjen");
            }
            var proi = db.Proizvodis.Include(p => p.MjereProizvoda);
            return RedirectToAction("Index", "WebShop", proi.ToList());
            
            

        }
    }
}