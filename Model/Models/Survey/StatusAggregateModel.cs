using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class StatusAggregateModel
    {
        public AssignSurveyModel AssignSurveyModel { get; set; }

        public List<GetAssignSurveyModel> lstGetAssignSurveyModel { get; set; }
    }
}
