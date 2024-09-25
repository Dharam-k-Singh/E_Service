using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Models.Department
{
    public class DepartmentModel
    {

        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Enter Department Name")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Enter Department Email Id")]
        public string DepartmentEmailId { get; set; }

        [Required(ErrorMessage = "Enter Escalation Level Email Id")]
        public string EscalationEmailLevel1 { get; set; }

        [Required(ErrorMessage = "Enter Number of Days for Escalation")]
        public int NoOfDaysForEscalation { get; set; }

        public int Createdby { get; set; }

        public System.DateTime Createddate { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public bool IsActive { get; set; }

    }
}
