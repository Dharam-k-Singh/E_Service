using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class QuestionAggregateModel
    {
        public QuestionModel QuestionModel { get; set; }

        public QuestionPollOptionModel QuestionPollOptionModel { get; set; }

        public List<QuestionPollOptionModel> lstQuestionPollOptionModel { get; set; }
    }
}
