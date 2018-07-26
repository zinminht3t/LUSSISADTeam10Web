﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LUSSISADTeam10API.Models.DBModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LUSSISEntities : DbContext
    {
        public LUSSISEntities()
            : base("name=LUSSISEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adjustment> adjustments { get; set; }
        public virtual DbSet<adjustmentdetail> adjustmentdetails { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<collectionpoint> collectionpoints { get; set; }
        public virtual DbSet<delegation> delegations { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<departmentcollectionpoint> departmentcollectionpoints { get; set; }
        public virtual DbSet<disbursement> disbursements { get; set; }
        public virtual DbSet<disbursementdetail> disbursementdetails { get; set; }
        public virtual DbSet<disbursementlocker> disbursementlockers { get; set; }
        public virtual DbSet<inventory> inventories { get; set; }
        public virtual DbSet<inventorytransaction> inventorytransactions { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<lockercollectionpoint> lockercollectionpoints { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        public virtual DbSet<outstandingrequisition> outstandingrequisitions { get; set; }
        public virtual DbSet<outstandingrequisitiondetail> outstandingrequisitiondetails { get; set; }
        public virtual DbSet<purchaseorder> purchaseorders { get; set; }
        public virtual DbSet<purchaseorderdetail> purchaseorderdetails { get; set; }
        public virtual DbSet<requisition> requisitions { get; set; }
        public virtual DbSet<requisitiondetail> requisitiondetails { get; set; }
        public virtual DbSet<supplier> suppliers { get; set; }
        public virtual DbSet<supplieritem> supplieritems { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<FrequentlyTop5ItemsDashboard> FrequentlyTop5ItemsDashboard { get; set; }
        public virtual DbSet<ItemTrendAnalysi> ItemTrendAnalysis { get; set; }
        public virtual DbSet<MonthItemUsage> MonthItemUsages { get; set; }
        public virtual DbSet<MonthlyItemUsageByHOD> MonthlyItemUsageByHODs { get; set; }
        public virtual DbSet<OrderByDepartmentDarshboard> OrderByDepartmentDarshboards { get; set; }
        public virtual DbSet<RequistionList> RequistionLists { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<NumberofRequest> NumberofRequests { get; set; }
    
        public virtual ObjectResult<MonthlyItemUsage> GetMonthlyItemUsage(Nullable<int> supplierone, Nullable<int> suppliertwo, Nullable<int> supplierthree)
        {
            var supplieroneParameter = supplierone.HasValue ?
                new ObjectParameter("supplierone", supplierone) :
                new ObjectParameter("supplierone", typeof(int));
    
            var suppliertwoParameter = suppliertwo.HasValue ?
                new ObjectParameter("suppliertwo", suppliertwo) :
                new ObjectParameter("suppliertwo", typeof(int));
    
            var supplierthreeParameter = supplierthree.HasValue ?
                new ObjectParameter("supplierthree", supplierthree) :
                new ObjectParameter("supplierthree", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MonthlyItemUsage>("GetMonthlyItemUsage", supplieroneParameter, suppliertwoParameter, supplierthreeParameter);
        }
    
        public virtual ObjectResult<ItemTrendAnalysis> GetItemTrendAnalysis(Nullable<int> fristdept, Nullable<int> seconddept, Nullable<int> thirddept, Nullable<int> month)
        {
            var fristdeptParameter = fristdept.HasValue ?
                new ObjectParameter("fristdept", fristdept) :
                new ObjectParameter("fristdept", typeof(int));
    
            var seconddeptParameter = seconddept.HasValue ?
                new ObjectParameter("seconddept", seconddept) :
                new ObjectParameter("seconddept", typeof(int));
    
            var thirddeptParameter = thirddept.HasValue ?
                new ObjectParameter("thirddept", thirddept) :
                new ObjectParameter("thirddept", typeof(int));
    
            var monthParameter = month.HasValue ?
                new ObjectParameter("month", month) :
                new ObjectParameter("month", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ItemTrendAnalysis>("GetItemTrendAnalysis", fristdeptParameter, seconddeptParameter, thirddeptParameter, monthParameter);
        }
    
        public virtual ObjectResult<RequistionList1> GetRequistionList(Nullable<int> deptid, Nullable<System.DateTime> fromdate, Nullable<System.DateTime> todate)
        {
            var deptidParameter = deptid.HasValue ?
                new ObjectParameter("deptid", deptid) :
                new ObjectParameter("deptid", typeof(int));
    
            var fromdateParameter = fromdate.HasValue ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(System.DateTime));
    
            var todateParameter = todate.HasValue ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RequistionList1>("GetRequistionList", deptidParameter, fromdateParameter, todateParameter);
        }
    }
}
