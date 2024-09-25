using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class SurveyDashboardModel
    {
        public int TotalSurveyAssigned { get; set; }

        public int SurveyPending { get; set; }

        public int SurveyIncomplete { get; set; }

        public int SurveyCompleted { get; set; }

        public int PaymentUnpaid { get; set; }

        public int PaymentPaid { get; set; }

        public int RegisteredEnterprises { get; set; }
    }
}
