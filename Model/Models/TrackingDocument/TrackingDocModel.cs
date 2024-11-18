using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Model.Models.TrackingDocument
{
    public class TrackingDocModel
    {
        public int TrackDocId { get; set; }
        [Required(ErrorMessage = "Sender Name is required")]
        public string SenderOrgName { get; set; }
        [Required(ErrorMessage = "Document Type is required")]
        public int DocType { get; set; }
        [Required(ErrorMessage = "Please fill the Other Document Type")]
        public string OtherDocType { get; set; }
        public string  DocTypeName { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Document is required")]
        public string DocSummary { get; set; }
        [Required(ErrorMessage = "Recipient's Email Id is required")]
        public List<string> RecipientMailId { get; set; }
        public string  ToMailIds { get; set; }
        [Required(ErrorMessage = "Detailed Description is required")]
        public string DetailedDescription { get; set; }
        [Required(ErrorMessage = "Document Status is required")]
        public int DocumentStatus { get; set; }
        public string  DocStatusName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        [Required(ErrorMessage = "Received Date is required")]
        public DateTime ReceivedDate { get; set; }
        [Required(ErrorMessage = "Please select the Required Action")]
        public int RequiredAction { get; set; }
        public string ReqActionName { get; set; }
        [Required(ErrorMessage = "Please select the Required Attention")]
        public int RequiredAttention { get; set; }
        [Required(ErrorMessage = "Please fill the Other's Attention Required")]
        public string CCMailIds { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        [Required(ErrorMessage = "Action Date is required")]
        public DateTime ActionDate { get; set; }
        [IgnoreDataMember]
        [Required(ErrorMessage = "At least One Document is Required")]
        public List<HttpPostedFileBase> AttachDoc { get; set; }
        [Required(ErrorMessage = "")]
        public string UploadDoc { get; set; }
        public int ChangedBy { get; set; }
        public int IsActive { get; set; }
    }
}
