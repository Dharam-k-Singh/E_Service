using Model.Models;
using Model.Models.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Campaign
{
    public interface ICampaignDAL
    {
        ResponseInfo SaveCampaignDAL(CampaignModel model);

        List<CampaignModel> GetListCampaignDAL();

        CampaignModel GetEditCampaignDAL(int id);

        ResponseInfo DeleteCampaignDAL(int id);

    }
}
