using BAL.Interface.TrackDocument;
using Model.Models.TrackingDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class TrackDocController : ApiController
    {
        private ITrackDocumentBAL _iTrackDocBAL;
        public TrackDocController()
        {
            _iTrackDocBAL = ServiceFactory.GetTrackDocBALInstance();
        }        

        public IHttpActionResult SaveOrUpdate(TrackingDocModel model)
        {
            return Ok(_iTrackDocBAL.SaveOrUpdateBAL(model));
        }
        public IHttpActionResult GetTrackDocList()
        {
            return Ok(_iTrackDocBAL.TrackingDocListBAL());
        }
        public IHttpActionResult GetListTrackingDocHistoryListById(int Id)
        {
            return Ok(_iTrackDocBAL.TrackingDocHistoryListByIdBAL(Id));
        }
        public IHttpActionResult RemoveData(int Id, int UserId)
        {
            return Ok(_iTrackDocBAL.RemoveTrackingDocByIdBAL(Id, UserId));
        }
        public IHttpActionResult GetTrackingDocDataById(int Id)
        {
            return Ok(_iTrackDocBAL.TrackingDocByIdBAL(Id));
        }
    }
}