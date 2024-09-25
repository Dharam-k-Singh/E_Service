using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Home
{
    public class ServiceReportModel
    {
        
        public int? ReportType { get; set; }
        public int? RequestStatus { get; set; }
        public int? Enterprise { get; set; }
        public int? Category { get; set; }
        public int? Severity { get; set; }
        public string Topic { get; set; }
        public int? SubCategory { get; set; }
        public string RequestDescription { get; set; }
        public string ContactPersonName { get; set; }
        public string EmailId { get; set; }
       public DateTime? Createddate { get; set; }
        public DateTime? Createddate2 { get; set; }


    }
}
