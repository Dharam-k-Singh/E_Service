using Model.Models;
using Model.Models.ListOfValue;
using Model.Models.TrackingDocument;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
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
            ViewBag.RecipientList = new SelectList(recipientList, "UDID", "EmailId");

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
            string attDoc = "";
            for(int i = 0; i < model.AttachDoc.Count; i++)
            {
                if (i > 0) { attDoc += ","; }

                attDoc += model.AttachDoc[i].FileName;
            }
            model.UploadDoc = attDoc;   

            ResponseInfo res = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveOrUpdate", "TrackDoc", obj: model);

            return RedirectToAction("Add");
        }
        public ActionResult List()
        {
            List<TrackingDocModel> lst = new List<TrackingDocModel>();
            return View("DocTrackingList", lst);
        }
        public void UpdateDocTracking()
        {

        }
    }
}