
using DAL.Interface.Campaign;
using Model.Models;
using Model.Models.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.Campaign
{
    public class CampaignDAL : BaseClassDAL, ICampaignDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        public List<CampaignModel> GetListCampaignDAL()
        {
            var result = entities.M_Campaign.Where(m => m.IsActive == true).ToList();
            List<CampaignModel> lstCampaign = Mapping<List<CampaignModel>>(result);
            return lstCampaign;
        }

        public ResponseInfo SaveCampaignDAL(CampaignModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

            if (model.CampaignId == 0)
            {
                var result = entities.Campaign_CRUD(model.CampaignId, model.CampaignName, model.CreatedBy, 1, OutputParam);
                respInfo.ID = model.CampaignId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {

                var result = entities.Campaign_CRUD(model.CampaignId, model.CampaignName, model.UpdatedBy, 2, OutputParam);
                respInfo.ID = model.CampaignId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }

            return respInfo;

        }

        public CampaignModel GetEditCampaignDAL(int id)
        {
            var result = entities.M_Campaign.Where(m => m.CampaignId == id).FirstOrDefault();
            CampaignModel obj = Mapping<CampaignModel>(result);
            return obj;
        }

        public ResponseInfo DeleteCampaignDAL(int id)
        {
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            ResponseInfo respInfo = new ResponseInfo();
            var res = entities.Campaign_D(id, OutputParam);
            respInfo.Status = "";
            respInfo.ID = id;
            respInfo.IsSuccess = true;
            respInfo.Msg = OutputParam.Value.ToString();
            return respInfo;
        }
    }
}

