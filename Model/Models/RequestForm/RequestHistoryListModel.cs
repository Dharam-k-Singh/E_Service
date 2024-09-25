using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class RequestHistoryListModel
    {
        //public  RequestId { get; set; }   

        public string RequestNo { get; set; }

        public string Department { get; set; }

        public string Priority { get; set; }

        public string RequestStatus { get; set; }     
   
        public string Commitementdate { get; set; }
     
        public string EscalateOndate { get; set; }
   
        public string EscLevel1EmailId { get; set; }
    
       // public string EscLevel2EmailId { get; set; }

        public string RequestComments { get; set; }

        public string UploadPath { get; set; }

        public string AllocatorUploadPath { get; set; }

        public string AllocatedBy { get; set; }

        public string UpdatedDate { get; set; }

        public string ReOpenedComments { get; set; }

        public string DepartmentUploadPath { get; set; }

    }
}
