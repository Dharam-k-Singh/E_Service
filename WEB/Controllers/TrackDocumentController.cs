using Model.Models;
using Model.Models.ListOfValue;
using Model.Models.TrackingDocument;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.APIHelper;

namespace WEB.Controllers
{
    public class TrackDocumentController : BaseController
    {
        private UserDetailModel UserDetail {get { return (UserDetailModel)Session["UserDetails"];} }
        private void GetMaster()
        {

            var actionReqList = new Dictionary<int, string> { { 1, "Pending" }, { 2, "In Progress" }, { 3, "Completed" }, { 4, "Cancelled" }
                                                            , { 5, "On Hold" }, { 6, "Scheduled" }, { 7, "Approved" }, { 8, "Rejected" } };

            var docStatusList = new Dictionary<int, string> { { 1, "Accepted" }, { 2, "Declined" }, { 3, "Expired" }, { 4, "Withdrawn" }
                                                            , { 5, "In Review" }, { 6, "Pending Approval" } };

            var docTypeList = new Dictionary<int, string>{ { 1, "Invoice" }, { 2, "Receipt" }, { 3, "Contract" }, { 4, "Report" }, { 5, "Proposal" }
                                                     , { 6, "Memo" }, { 7, "Letter" }, { 8, "Form" }, { 9, "Certificate" }, { 10, "Legal Document" }
                                                     , { 11, "Policies and Procedures" }, { 12, "Technical Documentation" } };

            var attentionStatusList = new Dictionary<int, string> { { 1, "None" }, { 2, "Immediate" }, { 3, "In Review" }, { 4, "Resolved" }, { 5, "Escalated" } };

            ViewBag.ActionReq = new SelectList(actionReqList, "Key", "Value");
            ViewBag.DocStatus = new SelectList(docStatusList, "Key", "Value");
            ViewBag.DocType = new SelectList(docTypeList, "Key", "Value");
            ViewBag.AttentionStatus = new SelectList(attentionStatusList, "Key", "Value");
        }

        public ActionResult Index()
        {
            return View("Document Tracking Index");
        }
        public ActionResult Add()
        {
            GetMaster();
            return View("Add");
        }
        [HttpPost]
        public ActionResult Save(TrackingDocModel model)
        {
            model.ChangedBy = UserDetail.UDID;

            ResponseInfo res = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "", "DocTracking", obj: model);

            return RedirectToAction("");
        }
        public ActionResult List()
        {
            List<TrackingDocModel> lst = new List<TrackingDocModel>();
            return View("DocTrackingList", lst);
        }
        public void UpdateTracking()
        {

        }
    }
}