﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Koch> KochSet { get; set; }
        public virtual DbSet<Rezept> RezeptSet { get; set; }
        public virtual DbSet<Kochvorgang> KochvorgangSet { get; set; }
        public virtual DbSet<Zutaten> ZutatenSet { get; set; }
        public virtual DbSet<Equipment> EquipmentSet { get; set; }
        public virtual DbSet<Bilder> BilderSet { get; set; }
    }
}
