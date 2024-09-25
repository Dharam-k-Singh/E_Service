using DAL.Concreate;
using Model.Models;
using Model.Models.Campaign;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.APIHelper;
using WEB.Controllers;

namespace Medsurvey.Controllers
{
    public class CampaignController : BaseController
    {
        //private CampaignDAL _CampaignDAL;

        //public CampaignController()
        //{
        //    _CampaignDAL = ServiceFactory.GetCampaignDALInstance();
        //}

        public ActionResult Add()
        {
            CampaignAggregateModel model = new CampaignAggregateModel();

            List<CampaignModel> GetList = WebAPIHelper.CallApi<List<CampaignModel>>(HttpMethods.Get, "GetListCampaign", "Campaign");
            model.lstCampaignModel = GetList;


            // model.lstCampaignModel = ListCampaign();
            return View(model);
        }

        public ActionResult Save(CampaignAggregateModel objmain)
        {

            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                if (objmain.CampaignModel.CampaignId == 0)
                    objmain.CampaignModel.CreatedBy = userdetail.UDID;
                else
                    objmain.CampaignModel.UpdatedBy = userdetail.UDID;
            }

            CampaignModel model = new CampaignModel();
            model = objmain.CampaignModel;

            //ResponseInfo rs = _CampaignDAL.SaveCampaignDAL(model.CampaignModel);

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveCampaign", "Campaign", model);

            ModelState.Clear();
            if (rs.Msg == "saved successfully." || rs.Msg == "updated successfully.")
                TempData["Success"] = rs.Msg;
            else
                TempData["Failure"] = rs.Msg;
            return RedirectToAction("Add");
        }


        public ActionResult Edit(int id)
        {
            CampaignAggregateModel model = new CampaignAggregateModel();


            CampaignModel cm = WebAPIHelper.CallApi<CampaignModel>(HttpMethods.Get, "GetEditCampaign", "Campaign", null, id);

            model.CampaignModel = cm;

            //model.CampaignModel = _CampaignDAL.EditCampaignDAL(id);

            model.lstCampaignModel = ListCampaign();

            return View("Add", model);
        }

        public ActionResult List()
        {
           // GetMaters();
            List<CampaignModel> GetList = WebAPIHelper.CallApi<List<CampaignModel>>(HttpMethods.Get, "GetListCampaign", "Campaign");

            return View(GetList);

            //List<CampaignModel> lstcampaign = ListCampaign();

            //return View(lstcampaign);
        }

        public List<CampaignModel> ListCampaign()
        {
            List<CampaignModel> lstCampaignModel = WebAPIHelper.CallApi<List<CampaignModel>>(HttpMethods.Get, "GetListCampaign", "Campaign");
            //List<CampaignModel> lstCampaignModel = _CampaignDAL.ListCampaignDAL();
            return lstCampaignModel;
        }

        public ActionResult Delete(int id)
        {

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteCampaign", "Campaign", null,id);
            //ResponseInfo rs = _CampaignDAL.DeleteCampaignDAL(id);
            TempData["Success"] = rs.Msg;
            return RedirectToAction("Add");
        }
    }
}