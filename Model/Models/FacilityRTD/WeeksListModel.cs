using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.FacilityRTD
{
    public class WeeksListModel
    {
        public int Year { get; set; }
        public int WeekId { get; set; }

        public string DateFrom { get; set; }

        public string DateTo { get; set; }

    }
    public class WeeksModel
    {
        public int WeekId { get; set; }
        public string Bin { get; set; }
    }

}
