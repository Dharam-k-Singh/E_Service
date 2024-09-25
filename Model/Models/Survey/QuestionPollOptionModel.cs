using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Survey
{
    public class QuestionPollOptionModel
    {
        public int PollOptionId { get; set; }

        public int QuestionId { get; set; }

        public string PollName { get; set; }

        public int QuestionTypeId { get; set; }

        public int? EditableTypeId { get; set; }

        [Required(ErrorMessage = "Total no of rating is required")]
        public int? TotalNoOfRating { get; set; }

        //[Required(ErrorMessage = "Start name is required")]
        public int? StartName { get; set; }

        //[Required(ErrorMessage = "End name is required")]
        public int? EndName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
