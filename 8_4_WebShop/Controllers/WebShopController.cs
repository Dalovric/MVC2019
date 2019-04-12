using _8_4_WebShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace _8_4_WebShop.Controllers
{
    public class WebShopController : Controller
    {

        private WebShop2Entities db = new WebShop2Entities();
        // GET: WebShop
        public ActionResult Index()
        {
            var proizvodi = db.Proizvodis.Include(p => p.MjereProizvoda);

            return View(proizvodi.ToList());
        }
    }
}