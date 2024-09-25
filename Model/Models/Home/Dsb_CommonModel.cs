using Model.Models.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Home
{
    public class Dsb_CommonModel
    {

        public Dsb_RequestCountListModel Requestcount { get; set; }

        public List<RequestListAdminModel> RequestListAdmin { get; set; }

        // public Dsb_RequestCountChartModel RequesChartcount { get; set; }

        public RequestActionAdminModel RequestSaveActionAdmin { get; set; }
        public List<ComplaintDrivers_Top3_Model> ComplaintDrivers { get; set; }
        public List<SLA_Top3_Model> SLA { get; set; }
    }
}
