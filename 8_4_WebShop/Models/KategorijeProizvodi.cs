//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _8_4_WebShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KategorijeProizvodi
    {
        public int Id { get; set; }
        public int ProizvodId { get; set; }
        public int KategorijaId { get; set; }
    
        public virtual Kategorije Kategorije { get; set; }
        public virtual Proizvodi Proizvodi { get; set; }
    }
}