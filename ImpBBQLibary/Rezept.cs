//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ImpBBQLibary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rezept
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezept()
        {
            this.Zutaten = new HashSet<Zutaten>();
            this.Kochvorgang = new HashSet<Kochvorgang>();
            this.Bilder = new HashSet<Bilder>();
        }
    
        public int Id { get; set; }
        public string Rezeptnamen { get; set; }
        public string Vorgehen { get; set; }
        public string Rezeptbewertung { get; set; }
    
        public virtual Koch Koch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zutaten> Zutaten { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kochvorgang> Kochvorgang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bilder> Bilder { get; set; }
    }
}
