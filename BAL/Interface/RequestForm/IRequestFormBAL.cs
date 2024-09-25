using Model.Models;
using Model.Models.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.RequestForm
{
    public interface IRequestFormBAL
    {
        ResponseInfo SaveRequestBAL(RequestFormModel model);

        List<RequestFormListModel> GetLFZReqListBAL(int userId);

        List<RequestFormListModel> GetEPReqListBAL(int id);

        ResponseInfo SaveFeedBackRatingBAL(RequestListCommonModel model);

        RequestFormEditModel GetEditRequestBAL(int id);

        ResponseInfo DeleteRequestBAL(int id, int userId);

        List<RequestListAdminModel> GetReqAdminListBAL();

        List<RequestWorkingListModel> GetReqWorkingListBAL(int userId);

        List<RequestHistoryListModel> GetReqHistoryDetailsBAL(int id);

        ResponseInfo SaveActionDetailsBAL(RequestAdminListCommonModel model);

        List<TicketListModel> GetMyTicketListBAL(int id);

        ResponseInfo SaveChangeTicketStatusBAL(TicketListCommonModel model);

        List<TicketListModel> GetDepartmentTicketListBAL(int userId);

        ResponseInfo SaveAllocateRequestBAL(int id, int userId);

        ResponseInfo SaveAllocateToTeamBAL(AllocateToTeamModel model);

        List<TicketListModel> GetHODDepTicketListBAL(int id);

        ResponseInfo DeleteFileBAL(UploadPathModel model);

        ResponseInfo SaveReopenRequestBAL(RequestListCommonModel model);

    }
}
