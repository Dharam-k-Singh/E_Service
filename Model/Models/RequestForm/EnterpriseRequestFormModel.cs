using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class EnterpriseRequestFormModel
    {
        public int RequestId { get; set; }

        public int ReportTypeID { get; set; }

        // public int RequestStatusID { get; set; }

        public int EnterpriseID { get; set; }

        public int CategoryId { get; set; }

        public int SubCategoryId { get; set; }

        public int SeverityId { get; set; }

        public string Topic { get; set; }

        public string RequestDescription { get; set; }

        public string ContactPersonName { get; set; }

        public string EmailId { get; set; }

        public string MobileNo { get; set; }

        public string UploadPath { get; set; }

        public int Createdby { get; set; }

        public System.DateTime Createddate { get; set; }

        public Nullable<int> Modifiedby { get; set; }

        public Nullable<System.DateTime> Modifieddate { get; set; }

        public bool IsActive { get; set; }
    }
}
