using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class RequestActionAdminModel
    {
       // public int AllocationId { get; set; }

        public int RequestId { get; set; }

        [Required(ErrorMessage = "Select Department")]
        public int DepartmentID { get; set; }

        //[Required(ErrorMessage = "Select Status")]
        //public int RequestStatusID { get; set; }

        [Required(ErrorMessage = "Select Priority")]
        public int PriorityID { get; set; }

        public string RequestComments { get; set; }

        [Required(ErrorMessage = "Set Commitment Date")]
        public DateTime Commitementdate { get; set; }

        [Required(ErrorMessage = "Set Escalate Date")]
        public DateTime EscalateOndate { get; set; }

        [Required(ErrorMessage = "Enter Escalate Level Email Id")]
        public string EscLevel1EmailId { get; set; }
        public string AllocatorsEmailId { get; set; }

        //[Required(ErrorMessage = "Enter Escalate Level 2 Email Id")]
        //public string EscLevel2EmailId { get; set; }


         public string UploadPath { get; set; }

       // public int SelfAllocatedBy { get; set; }

        public int Createdby { get; set; }

        public System.DateTime Createddate { get; set; }

        public Nullable<int> Modifiedby { get; set; }

        public Nullable<System.DateTime> Modifieddate { get; set; }

        public bool IsActive { get; set; }

    }
}
