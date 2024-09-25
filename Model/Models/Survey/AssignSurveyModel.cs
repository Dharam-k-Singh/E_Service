using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class AssignSurveyModel
    {
        public int AssignSurveyId { get; set; }

        public int SurveyId { get; set; }

        public int? QualificationId { get; set; }

        public int? SpecialityId { get; set; }

        public string AssignMemberIds { get; set; }

        [Required(ErrorMessage = "Survey Amount is required")]
        public int SurveyAmount { get; set; }

        public int SurveyStatus { get; set; }

        public int PaymentStatus { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
