using BAL.Interface;
using BAL.Interface.RequestForm;
using DAL.Interface.RequestForm;
using Model.Models;
using Model.Models.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.RequestForm
{
    public class RequestFormBAL : IRequestFormBAL
    {
        private IRequestFormDAL _iRequestFormDAL;

        public RequestFormBAL()
        {
            _iRequestFormDAL = BALFactory.GetRequestFormDALInstance();
        }

        public ResponseInfo SaveRequestBAL(RequestFormModel model)
        {
            return _iRequestFormDAL.SaveRequestDAL(model);
        }

        public List<RequestFormListModel> GetLFZReqListBAL(int userId)
        {
            return _iRequestFormDAL.GetLFZReqListDAL(userId);
        }

        public List<RequestFormListModel> GetEPReqListBAL(int id)
        {
            return _iRequestFormDAL.GetEPReqListDAL(id);
        }

        public ResponseInfo SaveFeedBackRatingBAL(RequestListCommonModel model)
        {
            return _iRequestFormDAL.SaveFeedBackRatingDAL(model);
        }

        public RequestFormEditModel GetEditRequestBAL(int id)
        {
            return _iRequestFormDAL.GetEditRequestDAL(id);
        }

        public ResponseInfo DeleteRequestBAL(int id, int userId)
        {
            return _iRequestFormDAL.DeleteRequestDAL(id, userId);
        }

        public List<RequestListAdminModel> GetReqAdminListBAL()
        {
            return _iRequestFormDAL.GetReqAdminListDAL();
        }

        public List<RequestWorkingListModel> GetReqWorkingListBAL(int userId)
        {
            return _iRequestFormDAL.GetReqWorkingListDAL(userId);
        }

        public List<RequestHistoryListModel> GetReqHistoryDetailsBAL(int id)
        {
            return _iRequestFormDAL.GetReqHistoryDetailsDAL(id);
        }

        public ResponseInfo SaveActionDetailsBAL(RequestAdminListCommonModel model)
        {
            return _iRequestFormDAL.SaveActionDetailsDAL(model);
        }

        public List<TicketListModel> GetMyTicketListBAL(int id)
        {
            return _iRequestFormDAL.GetMyTicketListDAL(id);
        }

        public ResponseInfo SaveChangeTicketStatusBAL(TicketListCommonModel model)
        {
            return _iRequestFormDAL.SaveChangeTicketStatusDAL(model);
        }

        public List<TicketListModel> GetDepartmentTicketListBAL(int userId)
        {
            return _iRequestFormDAL.GetDepartmentTicketListDAL(userId);
        }

        public ResponseInfo SaveAllocateRequestBAL(int id, int userId)
        {
            return _iRequestFormDAL.SaveAllocateRequestDAL(id, userId);
        }

        public ResponseInfo SaveAllocateToTeamBAL(AllocateToTeamModel model)
        {
            return _iRequestFormDAL.SaveAllocateToTeamDAL(model);
        }

        public List<TicketListModel> GetHODDepTicketListBAL(int id)
        {
            return _iRequestFormDAL.GetHODDepTicketListDAL(id);
        }

        public ResponseInfo DeleteFileBAL(UploadPathModel model)
        {
            return _iRequestFormDAL.DeleteFileDAL(model);
        }

        public ResponseInfo SaveReopenRequestBAL(RequestListCommonModel model)
        {
            return _iRequestFormDAL.SaveReopenRequestDAL(model);
        }
    }
}
