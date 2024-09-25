using BAL.Interface.Campaign;
using Model.Models.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CampaignController : ApiController
    {
        private ICampaignBAL _iCampaignBAL;
        CampaignController()
        {
            _iCampaignBAL = ServiceFactory.GetCampaignBALInstance();
        }

        [HttpPost]
        public IHttpActionResult SaveCampaign(CampaignModel model)
        {
            return Ok(_iCampaignBAL.SaveCampaignBAL(model));
        }

        public IHttpActionResult GetListCampaign()
        {
            return Ok(_iCampaignBAL.GetListCampaignBAL());
        }

        [HttpGet]
        public IHttpActionResult GetEditCampaign(int id)
        {
            return Ok(_iCampaignBAL.GetEditCampaignBAL(id));
        }

        [HttpPost]
        public IHttpActionResult DeleteCampaign(int id)
        {
            return Ok(_iCampaignBAL.DeleteCampaignBAL(id));
        }
    }
}
