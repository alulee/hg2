﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HGenealogy.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hDatabaseEntities : DbContext
    {
        public hDatabaseEntities()
            : base("name=hDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<FamilyMemberInfo> FamilyMemberInfoes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<PedigreeInfo> PedigreeInfoes { get; set; }
        public virtual DbSet<PedigreeMeta> PedigreeMetas { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<TaiwanZipCode> TaiwanZipCodes { get; set; }
        public virtual DbSet<UserGeneMeta> UserGeneMetas { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<FamilyMember_Picture_Mapping> FamilyMember_Picture_Mapping { get; set; }
        public virtual DbSet<FamilyMemberRelation> FamilyMemberRelations { get; set; }
        public virtual DbSet<PedigreeEvent> PedigreeEvents { get; set; }
    }
}
