using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class GetQuestionModel
    {
        public int QuestionId { get; set; }

        public int SurveyId { get; set; }

        public string Question { get; set; }

        public int QuestionTypeId { get; set; }

        public string QuestionType { get; set; }

        public int DisplayOnPageNo { get; set; }

        public int NoOfPages { get; set; }
    }
}
