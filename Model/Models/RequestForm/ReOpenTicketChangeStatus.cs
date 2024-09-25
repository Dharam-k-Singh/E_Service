using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class ReOpenTicketChangeStatus
    {

        public int RequestId { get; set; }

       // [Required(ErrorMessage = "Select Status")]
        public int RequestStatusID { get; set; }

        public string ReOpenedComments { get; set; }

        public int Createdby { get; set; }

        public System.DateTime Createddate { get; set; }

        public Nullable<int> Modifiedby { get; set; }

        public Nullable<System.DateTime> Modifieddate { get; set; }

        public bool IsActive { get; set; }
    }
}
