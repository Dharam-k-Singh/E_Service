using Model.Models;
using Model.Models.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.RequestForm
{
    public interface IRequestFormDAL
    {
        ResponseInfo SaveRequestDAL(RequestFormModel model);

        List<RequestFormListModel> GetLFZReqListDAL(int userId);

        List<RequestFormListModel> GetEPReqListDAL(int id);

        ResponseInfo SaveFeedBackRatingDAL(RequestListCommonModel model);

        RequestFormEditModel GetEditRequestDAL(int id);

        ResponseInfo DeleteRequestDAL(int id, int userId);

        List<RequestListAdminModel> GetReqAdminListDAL();

        List<RequestWorkingListModel> GetReqWorkingListDAL(int userId);

        List<RequestHistoryListModel> GetReqHistoryDetailsDAL(int id);

        ResponseInfo SaveActionDetailsDAL(RequestAdminListCommonModel model);

        List<TicketListModel> GetMyTicketListDAL(int id);

        ResponseInfo SaveChangeTicketStatusDAL(TicketListCommonModel model);

        List<TicketListModel> GetDepartmentTicketListDAL(int userId);

        ResponseInfo SaveAllocateRequestDAL(int id, int userId);

        ResponseInfo SaveAllocateToTeamDAL(AllocateToTeamModel model);

        List<TicketListModel> GetHODDepTicketListDAL(int id);

        ResponseInfo DeleteFileDAL(UploadPathModel model);

        ResponseInfo SaveReopenRequestDAL(RequestListCommonModel model);
    }
}
