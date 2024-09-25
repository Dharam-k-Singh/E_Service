using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class GetSurveyModel
    {
        public int SurveyId { get; set; }

        public int CampaignId { get; set; }

        public string SurveyName { get; set; }

        public string CampaignName { get; set; }

        public int NoOfPages { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Status { get; set; }

    }
}
