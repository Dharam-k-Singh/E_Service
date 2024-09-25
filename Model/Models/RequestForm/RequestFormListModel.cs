using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class RequestFormListModel
    {
        public int RequestId { get; set; }


        //public string ReportTypeID { get; set; }


        public string RequestNo { get; set; }


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


        public string RaisedOn { get; set; }


        public string UpdatedOn { get; set; }


        public string UpdatedBy { get; set; }


        public string CommentsBy { get; set; }

        public string ReOpenedComments { get; set; }

        public string DepartmentUploadPath { get; set; }
    }
}
