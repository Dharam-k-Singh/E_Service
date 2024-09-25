﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.UserCreation
{
    public  class EnterpriseCreationModel
    {
        public int UDID { get; set; }

        [Required(ErrorMessage = "Select Enterprise")]
        public int OrganizationID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "select Role")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mobile No Required")]
        public string MobileNo { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        public string saltKey { get; set; }
    }
}
