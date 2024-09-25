using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using DAL.Interface;
using Model.Models;
using Model.Models.Account;
using Model.Models.Home;
using Model.Models.RequestForm;
using Model.Models.UserDetail;

namespace BAL.Concreate
{
    public class HomeBAL:IHomeBAL
    {
        private IHomeDAL _iHomeDAL;

        public HomeBAL()
        {
            _iHomeDAL = BALFactory.GetHomeInstance();
        }

        //public ResponseInfo SaveRegistrationBAL(RegistrationModel model)
        //{
        //    return _iHomeDAL.SaveRegistrationDAL(model);
        //}

        public ResponseInfo CheckLoginBAL(UserDetailModel model)
        {
            return _iHomeDAL.CheckLoginDAL(model);
        }

        public Dsb_RequestCountListModel GetRequestCountBAL(int userId)
        {
            return _iHomeDAL.GetRequestCountDAL(userId);
        }

        public ValididateUser_OnePortal ValidUserBAL(ValididateUser_OnePortal Email)
        {
            return _iHomeDAL.ValidUser(Email);
        }
        public List<ServiceReport> ServiceReportBAL(ServiceReportModel model)
        {
            return _iHomeDAL.ServiceReportDAL(model);
        }

        public List<ComplaintDrivers_Top3_Model> Top3BAL()
        {
            return _iHomeDAL.Top3DAL();
        }

        public List<RequestWorkingListModel> DetailsComplaintDriversBAL(int? SubCategoryId, int? RequestId)
        {
            return _iHomeDAL.DetailsComplaintDriversDAL(SubCategoryId, RequestId);
        }
        public List<SLA_Top3_Model> Top3SLABAL()
        {
            return _iHomeDAL.Top3SLADAL();
        }
        //public List<ComplaintDriversViewModel> DashComplaintDriversBAL()
        //{
        //    return _iHomeDAL.DashComplaintDriversDAL();
        //}

        //public List<MostComplainsViewModel> DashMostComplainsBAL()
        //{
        //    return _iHomeDAL.DashMostComplainsDAL();
        //}
    }
}

