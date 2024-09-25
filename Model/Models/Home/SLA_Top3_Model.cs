using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Home
{
    public class SLA_Top3_Model
    {
        public int RequestId { get; set; }
        public string Enterprise { get; set; }
        public string ReportType { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
    }
}
