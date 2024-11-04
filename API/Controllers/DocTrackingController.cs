using BAL.Interface.DocTracking;
using Model.Models.TrackingDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class DocTrackingController : ApiController
    {
        private IDocTracking _iDocTrackBAL;
            
        DocTrackingController()
        {
            _iDocTrackBAL = ServiceFactory.GetDocTrackInstantce();
        }

        [HttpPost]
        public IHttpActionResult Save(TrackingDocModel model)
        {
            return Ok(_iDocTrackBAL.Save(model));
        }
    }
}