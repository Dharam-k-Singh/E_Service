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
    using System.Collections.Generic;
    
    public partial class M_ListOfValues_RTD
    {
        public int LOVId { get; set; }
        public string LOVName { get; set; }
        public Nullable<int> Parentid { get; set; }
        public bool IsEditable { get; set; }
        public int Createdby { get; set; }
        public System.DateTime Createddate { get; set; }
        public Nullable<int> Modifiedby { get; set; }
        public Nullable<System.DateTime> Modifieddate { get; set; }
        public bool IsActive { get; set; }
        public int OrganizationId { get; set; }
    }
}
