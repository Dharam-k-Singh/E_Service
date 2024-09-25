using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Please select survey")]
        public int SurveyId { get; set; }

        [Required(ErrorMessage = "Question is required")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Display on page no is required")]
        public int DisplayOnPageNo { get; set; }

        [Required(ErrorMessage = "Please select question type")]
        public int QuestionTypeId { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
