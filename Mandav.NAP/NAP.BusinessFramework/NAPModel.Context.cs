﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NAP.BusinessFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NAPEntities : DbContext
    {
        public NAPEntities()
            : base("name=NAPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<inDesign> inDesigns { get; set; }
        public virtual DbSet<inDispatch> inDispatches { get; set; }
        public virtual DbSet<inPackaging> inPackagings { get; set; }
        public virtual DbSet<inPayment> inPayments { get; set; }
        public virtual DbSet<inPrinting> inPrintings { get; set; }
        public virtual DbSet<JobDetailInfo> JobDetailInfoes { get; set; }
        public virtual DbSet<JobDetail> JobDetails { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
