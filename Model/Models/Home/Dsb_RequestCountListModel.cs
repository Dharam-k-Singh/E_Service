using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Home
{
    public class Dsb_RequestCountListModel
    {

        public int ComplaintEnquiry { get; set; }
        public int NewEnquiry { get; set; }
        public int ClosedEnquiry { get; set; }
        public int InProcess { get; set; }

        public int Overdue { get; set; }
        public int Today { get; set; }
        public int Tomorrow { get; set; }
        public int Thisweek { get; set; }
        public int Nextweek { get; set; }
        public int Laterweek { get; set; }
        
        public int High { get; set; }
        public int Medium { get; set; }
        public int Low { get; set; }
        
    }
}
