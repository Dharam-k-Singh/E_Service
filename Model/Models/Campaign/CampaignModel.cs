using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Campaign
{
    public class CampaignModel
    {
        public int CampaignId { get; set; }

        [MaxLength(200, ErrorMessage = "Max 200 characters is allowed ")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Only alphanumeric allowed, no special characters")]
        [Required(ErrorMessage = "Campaign Name is required")]
        public string CampaignName { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}