//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    
    public partial class AllEnterpriseWarehouse_G_Result
    {
        public int BookingId { get; set; }
        public Nullable<int> EnterpriseId { get; set; }
        public string OrganizationName { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string SizeRequired { get; set; }
        public Nullable<System.DateTime> RequiredFrom { get; set; }
        public Nullable<System.DateTime> RequiredTo { get; set; }
        public string WarehouseDescription { get; set; }
        public Nullable<int> StorageTypeId { get; set; }
        public string StorageArea { get; set; }
        public string WarehouseIds { get; set; }
    }
}
