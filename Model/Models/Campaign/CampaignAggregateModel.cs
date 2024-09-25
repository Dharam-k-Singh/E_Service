using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Campaign
{
    public class CampaignAggregateModel
    {
        public CampaignModel CampaignModel { get; set; }

        public List<CampaignModel> lstCampaignModel { get; set; }
    }
}
