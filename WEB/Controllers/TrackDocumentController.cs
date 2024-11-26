using Model.Models;
using Model.Models.TrackingDocument;
using Model.Models.UserDetail;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Utility;
using WEB.APIHelper;

namespace WEB.Controllers
{
    public class TrackDocumentController : BaseController
    {
        private UserDetailModel UserDetail { get { return (UserDetailModel)Session["UserDetails"]; } }
        private void GetMaster()
        {

            var actionReq = new Dictionary<int, string>() { { (int)CommonEnum.LOVId.Approve, "Approve" }, { (int)CommonEnum.LOVId.Review, "Review" }, { (int)CommonEnum.LOVId.Archive, "Archive" } };
            ViewBag.ActionReq = new SelectList(actionReq, "Key", "Value");

            var attentionReq = new Dictionary<int, string>() { { (int)CommonEnum.LOVId.None, "None" }, { 51, "ashish.khemka@tolaram.com" }, { (int)CommonEnum.LOVId.Other, "Others" } };
            ViewBag.AttentionStatus = new SelectList(attentionReq, "Key", "Value");


            var docStatus = new Dictionary<int, string>() { { (int)CommonEnum.LOVId.Open, "Open" }, { (int)CommonEnum.LOVId.Closed, "Closed" } };
            ViewBag.DocStatus = new SelectList(docStatus, "Key", "Value");

            var typeDoc = new Dictionary<int, string>() { { (int)CommonEnum.LOVId.NepzaLetter, "Nepza Letter" }, { (int)CommonEnum.LOVId.Custom, "Custom" }, { (int)CommonEnum.LOVId.Immigration, "Immigration" }, { (int)CommonEnum.LOVId.Other, "Others" } };
            ViewBag.TypeDoc = new SelectList(typeDoc, "Key", "Value");

            var recipientList = WebAPIHelper.CallApi<List<UserDetailModel>>(HttpMethods.Get, "GetUserDetails", "UsersDetail");
            ViewBag.RecipientList = new SelectList(recipientList, "UDID", "EmailId");

        }

        public ActionResult Index()
        {
            return View("Index");
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
            if (model.TrackDocId == null) model.DocumentStatus = (int)CommonEnum.LOVId.Open;

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
            if (model.TrackDocId != null)
            {
                TempData["Update"] = "Updated Successfully."; return RedirectToAction("List");
            }
            else
            {
                TempData["Update"] = "Recorded Successfully."; return RedirectToAction("Add");
            }
        }
        public ActionResult List()
        {
            List<TrackingDocModel> lst = WebAPIHelper.CallApi<List<TrackingDocModel>>(HttpMethods.Get, "GetTrackDocList", "TrackDoc");

            if(!new[] { 10, 1 }.Contains(UserDetail.RoleId))
            {
                lst = lst.Where(l => l.RecipientMailId == UserDetail.UDID).ToList();
            }

            
            return View("DocTrackingList", lst);
        }
        public ActionResult Update(int id)
        {
            GetMaster();
            TrackingDocModel model = WebAPIHelper.CallApi<TrackingDocModel>(HttpMethods.Get, "GetTrackingDocDataById", "TrackDoc", Id: id);
            model.RoleId = (byte)UserDetail.RoleId;
            ViewBag.UrlAction = "Update";
            return View("UpdateTrackDoc", model);
        }
        public ActionResult Edit(int id)
        {
            GetMaster();
            TrackingDocModel model = WebAPIHelper.CallApi<TrackingDocModel>(HttpMethods.Get, "", "", Id: id);
            model.RoleId = (byte)UserDetail.RoleId;
            ViewBag.UrlAction = "Edit";
            return View("UpdateTrackDoc", model);
        }
        public ActionResult View(int id)
        {
            TrackingDocModel model = WebAPIHelper.CallApi<TrackingDocModel>(HttpMethods.Get, "GetTrackingDocDataById", "TrackDoc", Id: id);
            return View("TrackDocView", model);
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
        [HttpGet]
        public JsonResult Remove(int id)
        {
            ResponseInfo resp = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "RemoveData", "TrackDoc", Id: id, UserID: UserDetail.UDID);

            return Json(resp, JsonRequestBehavior.AllowGet);
        }
    }
}