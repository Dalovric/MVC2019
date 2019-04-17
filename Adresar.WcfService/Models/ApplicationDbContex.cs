using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Adresar.WcfService.Models
{
    public class ApplicationDbContex: DbContext
    {
        public ApplicationDbContex()
            : base("AdresarBaza")
        {

        }
        public DbSet<Kontakt> Kontakti { get; set; }
    }
}