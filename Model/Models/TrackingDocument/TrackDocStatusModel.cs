using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.TrackingDocument
{
    public class TrackDocStatusModel
    {
        public int TDocHId { get; set; }
        public int TrackDocId { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string EmployeeName { get; set; }
        public int ChangedById { get; set; }
        public DateTime ChangedDate { get; set; }
    }
}
