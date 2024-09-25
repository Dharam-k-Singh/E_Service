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

namespace DAL.Interface
{
    public interface IHomeDAL
    {
        //ResponseInfo SaveRegistrationDAL (RegistrationModel model);

        ResponseInfo CheckLoginDAL(UserDetailModel model);

        Dsb_RequestCountListModel GetRequestCountDAL(int userId);
        ValididateUser_OnePortal ValidUser(ValididateUser_OnePortal Email);


        List<ServiceReport> ServiceReportDAL(ServiceReportModel model);
        List<ComplaintDrivers_Top3_Model> Top3DAL();
        List<RequestWorkingListModel> DetailsComplaintDriversDAL(int? SubCategoryId, int? RequestId);
        List<SLA_Top3_Model> Top3SLADAL();
        //List<ComplaintDriversViewModel> DashComplaintDriversDAL();
        //List<MostComplainsViewModel> DashMostComplainsDAL();
    }
}
