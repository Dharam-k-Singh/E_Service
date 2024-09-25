using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.FacilityRTD
{
    public class FoodDetailsModel
    {

        public int FDId { get; set; }
        public int Year { get; set; }

        public int WeekId { get; set; }

        public string DateFrom { get; set; }

        public string DateTo { get; set; }

        public DateTime Monday_Date { get; set; }

        public string Monday_BF { get; set; }

        public string Monday_L { get; set; }
   
        public string Monday_D { get; set; }

        public DateTime Tuesday_Date { get; set; }

        public string Tuesday_BF { get; set; }

        public string Tuesday_L { get; set; }

        public string Tuesday_D { get; set; }

        public DateTime Wednesday_Date { get; set; }

        public string Wednesday_BF { get; set; }

        public string Wednesday_L { get; set; }

        public string Wednesday_D { get; set; }

        public DateTime Thursday_Date { get; set; }

        public string Thursday_BF { get; set; }

        public string Thursday_L { get; set; }

        public string Thursday_D { get; set; }

        public DateTime Friday_Date { get; set; }

        public string Friday_BF { get; set; }

        public string Friday_L { get; set; }

        public string Friday_D { get; set; }

        public DateTime Saturday_Date { get; set; }

        public string Saturday_BF { get; set; }

        public string Saturday_L { get; set; }

        public string Saturday_D { get; set; }

        public DateTime Sunday_Date { get; set; }

        public string Sunday_BF { get; set; }

        public string Sunday_L { get; set; }

        public string Sunday_D { get; set; }

        public int Createdby { get; set; }

        public System.DateTime Createddate { get; set; }

        public Nullable<int> Modifiedby { get; set; }

        public Nullable<System.DateTime> Modifieddate { get; set; }

        public bool IsActive { get; set; }
    }
}
 