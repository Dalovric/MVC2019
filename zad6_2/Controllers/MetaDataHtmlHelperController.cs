using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zad6_2.Models;

namespace zad6_2.Controllers
{
    public class MetaDataHtmlHelperController : Controller
    {
        // GET: MetaDataHtmlHelper
        public ViewResult MetaDataView()
        {
            return View(new OsobaMeta());
        }
        [HttpPost]
        public ViewResult MetaDataView(OsobaMeta osoba)
        {
            return View("/HtmlLabelDisplay", osoba);
        }
        
    }
}