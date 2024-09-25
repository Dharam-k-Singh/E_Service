using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class StartSurveyModel
    {
        public QuestionModel QuestionModel { get; set; }

        public List<QuestionPollOptionModel> lstQuestionPollOptionModel { get; set; }

        public UserSurveyAnswerModel UserSurveyAnswerModel { get; set; }
    }
}
