using Model.Models;
using Model.Models.Account;
using Model.Models.Home;
using Model.Models.RequestForm;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IHomeBAL
    {
       // ResponseInfo SaveRegistrationBAL(RegistrationModel model);

        ResponseInfo CheckLoginBAL(UserDetailModel model);

        Dsb_RequestCountListModel GetRequestCountBAL(int userId);
        ValididateUser_OnePortal ValidUserBAL(ValididateUser_OnePortal Email);

        List<ServiceReport> ServiceReportBAL(ServiceReportModel model);
        List<ComplaintDrivers_Top3_Model> Top3BAL();
        List<RequestWorkingListModel> DetailsComplaintDriversBAL(int? SubCategoryId, int? RequestId);
        List<SLA_Top3_Model> Top3SLABAL();

        //List<ComplaintDriversViewModel> DashComplaintDriversBAL();
        //List<MostComplainsViewModel> DashMostComplainsBAL();
    }
}
