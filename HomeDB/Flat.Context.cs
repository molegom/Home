﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FlatEntities : DbContext
    {
        public FlatEntities()
            : base("name=FlatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Key> Keys { get; set; }
        public virtual DbSet<Flats> Flats { get; set; }
        public virtual DbSet<ImageStatus> ImageStatus { get; set; }
        public virtual DbSet<Image> Images { get; set; }
    }
}
