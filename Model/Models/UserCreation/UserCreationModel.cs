using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.UserCreation
{
    public class UserCreationModel
    {

        public int UDID { get; set; }

        //[Required(ErrorMessage = "Select Enterprise")]
      //  public int OrganizationID { get; set; }

        [Required(ErrorMessage = "Enter Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "select Role")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Select Department")]
        public List<int> DepartmentID { get; set; }

       // [Required(ErrorMessage = "Select Department")]
        public string DepartmentIDs { get; set; }

        //[Required(ErrorMessage = "Select Reporting To")]
        //public int ReportingToID { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mobile No Required")]
        public string MobileNo { get; set; }


        public int CreatedBy { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        public string saltKey { get; set; }

    }
}
