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
    
    public partial class Survey_G_Result
    {
        public int SurveyId { get; set; }
        public int CampaignId { get; set; }
        public string SurveyName { get; set; }
        public string CampaignName { get; set; }
        public Nullable<int> NoOfPages { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Status { get; set; }
    }
}
