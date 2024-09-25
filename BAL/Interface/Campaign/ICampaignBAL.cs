using Model.Models;
using Model.Models.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.Campaign
{
    public interface ICampaignBAL
    {

        ResponseInfo SaveCampaignBAL(CampaignModel model);

        List<CampaignModel> GetListCampaignBAL();

        CampaignModel GetEditCampaignBAL(int id);

        ResponseInfo DeleteCampaignBAL(int id);

    }
}
