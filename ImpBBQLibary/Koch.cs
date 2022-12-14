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
    
    public partial class Koch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Koch()
        {
            this.Equipment = new HashSet<Equipment>();
            this.Rezept = new HashSet<Rezept>();
            this.Zutaten = new HashSet<Zutaten>();
            this.Kochvorgang = new HashSet<Kochvorgang>();
        }
    
        public int Id { get; set; }
        public string Kochname { get; set; }
        public string Kochbewertung { get; set; }
        public int BilderId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipment> Equipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezept> Rezept { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zutaten> Zutaten { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kochvorgang> Kochvorgang { get; set; }
        public virtual Bilder Bilder { get; set; }
    }
}
