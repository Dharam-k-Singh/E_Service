using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Home
{
   
    public class Dsb_RequestCountChartModel
    {
        public int ComplaintEnquiry { get; set; }
        public int NewEnquiry { get; set; }
        public int ClosedEnquiry { get; set; }
        public int InProcess { get; set; }

    }
}
