using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class RequestWorkingListModel
    {


        //public int RequestId { get; set; }

        //public string ReportType { get; set; }

        ////public string RequestNo { get; set; }

        //public string RequestStatus { get; set; }

        //public string Enterprise { get; set; }

        //public string Category { get; set; }

        //public string SubCategory { get; set; }

        //public string Severity { get; set; }

        //public string Topic { get; set; }

        //public string RequestDescription { get; set; }

        //public string ContactPersonName { get; set; }

        //public string EmailId { get; set; }

        //public string MobileNo { get; set; }

        //public string Department { get; set; }

        //public string Priority { get; set; }

        //public string RaisedOnDate { get; set; }

        //public string ReportedBy { get; set; }

        //public string UploadPath { get; set; }

        ////public string AllocatorUploadPath { get; set; }

        //public string ReOpenedComments { get; set; }
        // new param
        public int RequestId { get; set; }
        public string ReportType { get; set; }
        public string RequestStatus { get; set; }
        public string Enterprise { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Severity { get; set; }
        public string Topic { get; set; }
        public string RequestDescription { get; set; }
        public string ContactPersonName { get; set; }
        public string ReportedBy { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string RaisedOnDate { get; set; }
        public string AllocatorUploadPath { get; set; }
        public string Department { get; set; }
        public string Priority { get; set; }
        public string UploadPath { get; set; }
        public string ReOpenedComments { get; set; }
    }
}
