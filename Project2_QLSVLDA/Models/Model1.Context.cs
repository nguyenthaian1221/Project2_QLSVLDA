﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project2_QLSVLDA.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QL_PROJECTEntities1 : DbContext
    {
        public QL_PROJECTEntities1()
            : base("name=QL_PROJECTEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CHUCNANG> CHUCNANGs { get; set; }
        public virtual DbSet<GIANGVIEN> GIANGVIENs { get; set; }
        public virtual DbSet<LOPMONHOC> LOPMONHOCs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
        public virtual DbSet<SINHVIENMONHOC> SINHVIENMONHOCs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<USERACCOUNT> USERACCOUNTs { get; set; }
        public virtual DbSet<CUOCHEN> CUOCHENs { get; set; }
        public virtual DbSet<BAITAP> BAITAPs { get; set; }
        public virtual DbSet<NHOMSINHVIEN> NHOMSINHVIENs { get; set; }
        public virtual DbSet<SINHVIENCUOCHEN> SINHVIENCUOCHENs { get; set; }
        public virtual DbSet<tblFileDetail> tblFileDetails { get; set; }
        public virtual DbSet<SINHVIENBAITAP> SINHVIENBAITAPs { get; set; }
    }
}
