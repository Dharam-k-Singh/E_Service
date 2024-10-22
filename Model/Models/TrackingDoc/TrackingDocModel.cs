using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.TrackingDoc
{
    public class TrackingDocModel
    {
        public int TrackDocId { get; set; }
        public string SenderOrgName { get; set; }
        public int DocType { get; set; }
        public string Subject { get; set; }
        public string DocSummary { get; set; }
        public string RecipientMailId { get; set; }
        public string DetailedDescription { get; set; }
        public int DocumentStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime ReceivedDate { get; set; }
        public int RequiredAction { get; set; }
        public int RequiredAttention { get; set; }
        [IgnoreDataMember]
        [Required(ErrorMessage = "At least One Document is Required")]
        public HttpPostedFileBase AttachDoc { get; set; }
        public int ChangedBy { get; set; }
        public int IsActive { get; set; }
    }
}
