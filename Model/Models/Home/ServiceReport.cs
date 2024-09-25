using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Home
{
    public class ServiceReport
    {
        public int RequestId { get; set; }
        public int ReportTypeId { get; set; }

        public string ReportType { get; set; }
        public string RequestStatusId { get; set; }

        public string RequestStatus { get; set; }
        public string EnterpriseID { get; set; }

        public string Enterprise { get; set; }
        public string CategoryId { get; set; }

        public string Category { get; set; }
        public string SubCategoryId { get; set; }

        public string SubCategory { get; set; }
        public string Severity { get; set; }
        public string Topic { get; set; }
        public string RequestDescription { get; set; }
        public string ContactPersonName { get; set; }
        public string EmailId { get; set; }
        public string UploadPath { get; set; }
        public string AverageHandling { get; set; }
        public string AverageResponse { get; set; }
    }
}
