using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }

        public int CampaignId { get; set; }

        [MaxLength(200, ErrorMessage = "Max 200 characters is allowed ")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Only alphanumeric allowed, no special characters")]
        [Required(ErrorMessage = "Survey Name is required")]
        public string SurveyName { get; set; }

        public string CampaignName { get; set; }

        [Required(ErrorMessage = "No of pages is required")]
        public int NoOfPages { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please select status")]
        public int Status { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
