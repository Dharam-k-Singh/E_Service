using Model.Models;
using Model.Models.ListOfValue;
using Model.Models.TrackingDocument;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;
using WEB.APIHelper;

namespace WEB.Controllers
{
    public class TrackDocumentController : BaseController
    {
        private UserDetailModel UserDetail {get { return (UserDetailModel)Session["UserDetails"];} }
        private void GetMaster()
        {
          
            var docType = new Dictionary<int, string>() { { (int)CommonEnum.LOVId.NepzaLetter, "Nepza Letter" }, { (int)CommonEnum.LOVId.Custom, "Custom" }, { (int)CommonEnum.LOVId.Immigration, "Immigration" }, { (int)CommonEnum.LOVId.Other, "Others" } };
            ViewBag.DocType = new SelectList(docType, "Key", "Value");

            var actionReq = new Dictionary<int, string>() { { (int)CommonEnum.LOVId.Approve, "Approve" }, { (int)CommonEnum.LOVId.Review, "Review" }, { (int)CommonEnum.LOVId.Archive, "Archive" } };
            ViewBag.ActionReq = new SelectList(actionReq, "Key", "Value");

            var attentionReq = new Dictionary<int, string>() { { (int)CommonEnum.LOVId.None, "None" }, { 51, "ashish.khemka@tolaram.com" }, { (int)CommonEnum.LOVId.Other, "Others" } };
            ViewBag.AttentionStatus = new SelectList(attentionReq, "Key", "Value");


            var docStatus = new Dictionary<int, string>() { { (int)CommonEnum.LOVId.Open, "Open" }, { (int)CommonEnum.LOVId.Closed, "Closed" } };
            ViewBag.DocStatus = new SelectList(docStatus, "Key", "Value");

            var recipientList = WebAPIHelper.CallApi<List<UserDetailModel>>(HttpMethods.Get, "GetUserDetails", "UsersDetail");
            ViewBag.RecipientList = new SelectList(recipientList, "EmailId", "EmailId");

        }

        public ActionResult Index()
        {
            return View("Document Tracking Index");
        }
        public ActionResult Add()
        {
            GetMaster();
            return View();
        }
        [HttpPost]
        public ActionResult Save(TrackingDocModel model)
        {
            model.ChangedBy = UserDetail.UDID;

            if (model.RecipientMailId != null)
            {
                string mailIds = "";
                for (int i = 0; i < model.RecipientMailId.Count; i++)
                {
                    if (i > 0) { mailIds += ","; }

                    mailIds += model.RecipientMailId[i];
                }
                model.ToMailIds = mailIds;
            }

            if (model.AttachDoc != null)
            {
                string uploadPath = ConfigurationManager.AppSettings["DocTrackUploadPath"];
                string attDoc = "";
                for (int i = 0; i < model.AttachDoc.Count; i++)
                {
                    if (i > 0) { attDoc += ","; }
                    attDoc += model.AttachDoc[i].FileName;
                    string fullpath = uploadPath + model.AttachDoc[i].FileName;

                    model.AttachDoc[i].SaveAs(Server.MapPath(fullpath));
                }
                model.UploadDoc = attDoc;
            }


            ResponseInfo res = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveOrUpdate", "TrackDoc", obj: model);

            return RedirectToAction("Add");
        }
        public ActionResult List()
        {
            List<TrackingDocModel> lst = WebAPIHelper.CallApi<List<TrackingDocModel>>(HttpMethods.Get, "GetTrackDocList", "TrackDoc");

            foreach(var list in lst)
            {
                list.RecipientMailId = list.ToMailIds.Split(',').Select(id => id.Trim()).ToList();
            }

            return View("DocTrackingList", lst);
        }
        public void UpdateDocTracking()
        {

        }
        [HttpPost]
        public PartialViewResult TrackDocHistory(int id)
        {
            var historyList = WebAPIHelper.CallApi<List<TrackDocStatusModel>>(HttpMethods.Get, "", "TrackDoc", Id: id);
            return PartialView("_TrackDocHistory", historyList);
        }
    }
}