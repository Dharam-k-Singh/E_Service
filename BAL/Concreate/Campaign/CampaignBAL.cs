using BAL.Interface.Campaign;
using DAL.Interface.Campaign;
using Model.Models;
using Model.Models.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.Campaign
{
    public class CampaignBAL: ICampaignBAL
    {
        private ICampaignDAL _iCampaignDAL;

        public CampaignBAL()
        {
            _iCampaignDAL = BALFactory.GetCampaignDALInstance();
        }

        public ResponseInfo SaveCampaignBAL(CampaignModel model)
        {
            return _iCampaignDAL.SaveCampaignDAL(model);
        }

        public List<CampaignModel> GetListCampaignBAL()
        {
            return _iCampaignDAL.GetListCampaignDAL();
        }

        public CampaignModel GetEditCampaignBAL(int id)
        {
            return _iCampaignDAL.GetEditCampaignDAL(id);
        }

        public ResponseInfo DeleteCampaignBAL(int id)
        {
            return _iCampaignDAL.DeleteCampaignDAL(id);
        }
    }
}
