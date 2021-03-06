﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4._1._1_broj_godina.Controllers
{
    public class BrojGodinaController : Controller
    {
        
        public ViewResult RacunajBrojGodina()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RacunajBrojGodina(DateTime datum)
        {
            int brojGodina;
            try
            {
                brojGodina = (DateTime.Now - datum).Days / 365;
                return View((object)brojGodina.ToString());
            }
            catch(Exception e)
            {
                return View((object)e.Message);
            }
        }
    }
}