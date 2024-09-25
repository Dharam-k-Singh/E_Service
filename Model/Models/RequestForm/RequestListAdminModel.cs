using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class RequestListAdminModel
    {

        public int RequestId { get; set; }


        public string ReportType { get; set; }


        //public int RequestStatusID { get; set; }


        public string RequestStatus { get; set; }


        public string Enterprise { get; set; }


        public string Category { get; set; }


        public string SubCategory { get; set; }


        public string Severity { get; set; }


        public string Topic { get; set; }


        public string RequestDescription { get; set; }


        public string ContactPersonName { get; set; }


        public string EmailId { get; set; }


        public string MobileNo { get; set; }


        public string UploadPath { get; set; }


        public string ReportedBy { get; set; }


        public string RaisedOnDate { get; set; }


        public string Department { get; set; }


        public string Priority { get; set; }


        public string ReOpenedComments { get; set; }

        public string DepartmentUploadPath { get; set; }



        // public date Createddate { get; set; }

        // public Nullable<int> Modifiedby { get; set; }

        //  public Nullable<System.DateTime> Modifieddate { get; set; }

        //  public bool IsActive { get; set; }
    }
}
