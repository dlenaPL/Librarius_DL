﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Librarius_DL.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryEntities : DbContext
    {
        public LibraryEntities()
            : base("name=LibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<BookCopies> BookCopies { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Conditions> Conditions { get; set; }
        public virtual DbSet<Fines> Fines { get; set; }
        public virtual DbSet<FineStatuses> FineStatuses { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
    }
}