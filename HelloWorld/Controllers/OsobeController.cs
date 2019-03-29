using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class OsobeController : Controller
    {
        
        public ViewResult PopuniOsobu()
        {
            return View();
        }
        [HttpPost]
        public ViewResult PrikaziOsobu(Osoba osoba)
        {
            return View(osoba);
        }
    }
}