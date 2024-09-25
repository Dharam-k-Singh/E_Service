using BAL.Interface;
using BAL.Interface.RequestForm;
using Model.Models.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RequestFormController : ApiController
    {
        private IRequestFormBAL _iRequestFormBAL;


        RequestFormController()
        {
            _iRequestFormBAL = ServiceFactory.GetRequestFormInstance();
        }

        [HttpPost]
        public IHttpActionResult SaveRequest(RequestFormModel model)
        {
            return Ok(_iRequestFormBAL.SaveRequestBAL(model));
        }

        public IHttpActionResult GetLFZReqList(int userId)
        {
            return Ok(_iRequestFormBAL.GetLFZReqListBAL(userId));
        }

        public IHttpActionResult GetEPReqList(int id)
        {
            return Ok(_iRequestFormBAL.GetEPReqListBAL(id));
        }

        [HttpPost]
        public IHttpActionResult SaveFeedBackRating(RequestListCommonModel model)
        {
            return Ok(_iRequestFormBAL.SaveFeedBackRatingBAL(model));
        }

        [HttpGet]
        public IHttpActionResult GetEditRequest(int id)
        {
            return Ok(_iRequestFormBAL.GetEditRequestBAL(id));
        }

        [HttpPost]
        public IHttpActionResult DeleteRequest(int id, int userId)
        {
            return Ok(_iRequestFormBAL.DeleteRequestBAL(id, userId));
        }


        public IHttpActionResult GetReqAdminList()
        {
            return Ok(_iRequestFormBAL.GetReqAdminListBAL());
        }

        public IHttpActionResult GetReqWorkingList(int userId)
        {
            return Ok(_iRequestFormBAL.GetReqWorkingListBAL(userId));
        }

        public IHttpActionResult GetReqHistoryDetails(int id)
        {
            return Ok(_iRequestFormBAL.GetReqHistoryDetailsBAL(id));
        }

        [HttpPost]
        public IHttpActionResult SaveActionDetails(RequestAdminListCommonModel model)
        {
            return Ok(_iRequestFormBAL.SaveActionDetailsBAL(model));
        }

        public IHttpActionResult GetMyTicketList(int id)
        {
            return Ok(_iRequestFormBAL.GetMyTicketListBAL(id));
        }

        [HttpPost]
        public IHttpActionResult SaveChangeTicketStatus(TicketListCommonModel model)
        {
            return Ok(_iRequestFormBAL.SaveChangeTicketStatusBAL(model));
        }

        public IHttpActionResult GetDepartmentTicketList(int userId)
        {
            return Ok(_iRequestFormBAL.GetDepartmentTicketListBAL(userId));
        }

        [HttpPost]
        public IHttpActionResult SaveAllocateRequest(int id, int userId)
        {
            return Ok(_iRequestFormBAL.SaveAllocateRequestBAL(id, userId));
        }

        [HttpPost]
        public IHttpActionResult SaveAllocateToTeam(AllocateToTeamModel model)
        {
            return Ok(_iRequestFormBAL.SaveAllocateToTeamBAL(model));
        }

        public IHttpActionResult GetHODDepTicketList(int id)
        {
            return Ok(_iRequestFormBAL.GetHODDepTicketListBAL(id));
        }

        [HttpPost]
        public IHttpActionResult DeleteFile(UploadPathModel model)
        {
            return Ok(_iRequestFormBAL.DeleteFileBAL(model));
        }
        [HttpPost]
        public IHttpActionResult SaveReopenRequest(RequestListCommonModel model)
        {
            return Ok(_iRequestFormBAL.SaveReopenRequestBAL(model));
        }
    }
}
