﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class RequestFormModel
    {
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Select Type")]
        public int ReportTypeID { get; set; }

        // public int RequestStatusID { get; set; }

        [Required(ErrorMessage = "Select Enterprise")]
        public int EnterpriseID { get; set; }

        [Required(ErrorMessage = "Select Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Select SubCategory")]
        public int SubCategoryId { get; set; }

        public string ReportTypeName { get; set; }

        public string CategoryName { get; set; }
      
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "Select Severity")]
        public int SeverityId { get; set; }

        //[Required(ErrorMessage = "Enter Title")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        public string RequestDescription { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string ContactPersonName { get; set; }

        [Required(ErrorMessage = "Enter Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Enter Mobile No")]
        public string MobileNo { get; set; }

        public string UploadPath { get; set; }

        public string PreviewUploadPath { get; set; }

        public int Createdby { get; set; }

        public System.DateTime Createddate { get; set; }

        public Nullable<int> Modifiedby { get; set; }

        public Nullable<System.DateTime> Modifieddate { get; set; }

        public bool IsActive { get; set; }

        public DataTable dtUploads { get; set; }
        public int UploadTypeId { get; set; }
    }
}
