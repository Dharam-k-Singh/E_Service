using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class GetAssignSurveyModel
    {
        public int AssignSurveyId { get; set; }

        public string Name { get; set; }

        public string Email_id { get; set; }

        public int SurveyId { get; set; }

        public string SurveyName { get; set; }

        public int SurveyAmount { get; set; }

        public int SurveyStatusId { get; set; }

        public string SurveyStatus { get; set; }

        public int PaymentStatusId { get; set; }

        public string PaymentStatus { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int NoOfPages { get; set; }

        public DateTime EndDate { get; set; }

        public int UserID { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}
