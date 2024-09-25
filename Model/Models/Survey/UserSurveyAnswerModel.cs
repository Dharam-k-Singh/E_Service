using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class UserSurveyAnswerModel
    {
        public int UserSurveyAnswerId { get; set; }

        public int AssignSurveyId { get; set; }

        public int SurveyId { get; set; }

        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Answer is required")]
        public string Answer { get; set; }

        //[Required(ErrorMessage = "Remark is required")]
        public string Remark { get; set; }

       // public int SurveyStatus { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
