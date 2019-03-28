﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3_1_1.Controllers
{
    public class KontekstController : Controller
    {
        // GET: Kontekst
        public string Index()
        {
            string poruka = "Danas je: " + DateTime.Now.ToLongDateString();
            return poruka;
        }
      
        public string QueryPodaci()
        {
            if(Request.QueryString["Ime"]==null || Request.QueryString["Prezime"]==null)
            {
                return "Podaci su nepotpuni";
            }
            else
            {
                string ime = Request.QueryString["Ime"];
                string prezime = Request.QueryString["Prezime"];
                string tekstSaStilom = string.Format("<label style='color:red; font-weight:bold;'>{0} {1}</label>", ime, prezime);
                return string.Format("<p>Ime i prezime iz query stringa su: {0}</p>", tekstSaStilom);
            }
        }

    }
}