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
    
    public partial class Proizvodi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proizvodi()
        {
            this.KategorijeProizvodis = new HashSet<KategorijeProizvodi>();
            this.NarudzbeDetaljis = new HashSet<NarudzbeDetalji>();
        }
    
        public int Id { get; set; }
        public short MjeraProizvodaId { get; set; }
        public System.DateTime VrijemeKreiranja { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public bool Dostupan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KategorijeProizvodi> KategorijeProizvodis { get; set; }
        public virtual MjereProizvoda MjereProizvoda { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NarudzbeDetalji> NarudzbeDetaljis { get; set; }
    }
}
