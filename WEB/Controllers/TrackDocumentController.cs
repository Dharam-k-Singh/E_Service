using Model.Models.TrackingDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class TrackDocumentController : BaseController
    {
        private void GetMaster()
        {

        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TrackDoc()
        {
            return View("TrackDocument");
        }
        [HttpPost]
        public ActionResult TrackDoc(TrackingDocModel model)
        {
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