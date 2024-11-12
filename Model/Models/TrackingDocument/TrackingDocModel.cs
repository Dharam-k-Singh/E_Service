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
        public string SenderOrgName { get; set; }
        public int DocType { get; set; }
        [Required(ErrorMessage = "Please fill the Other Document Type")]
        public string OtherDocType { get; set; }
        public string Subject { get; set; }
        public string DocSummary { get; set; }
        public List<int> RecipientMailId { get; set; }
        public string DetailedDescription { get; set; }
        public int DocumentStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime ReceivedDate { get; set; }
        public int RequiredAction { get; set; }
        public int RequiredAttention { get; set; }
        [Required(ErrorMessage = "Please fill the Other's Attention Required")]
        public string OtherReqAttention { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime ActionDate { get; set; }
        [IgnoreDataMember]
        [Required(ErrorMessage = "At least One Document is Required")]
        public List<HttpPostedFileBase> AttachDoc { get; set; }
        public string UploadDoc { get; set; }
        public int ChangedBy { get; set; }
        public int IsActive { get; set; }
    }
}
