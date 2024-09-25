using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Model.Models.UserDetail;

namespace DAL.Concreate
{
    public class UsersDetailDAL:BaseClassDAL, IUsersDetailDAL
    {
       
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        public List<UserDetailModel> GetUsersDetails()
        {
            //  var result = entities.M_UserDetails_G().ToList();
            // List<UserDetailModel> lstUsersDetail = Mapping<List<UserDetailModel>>(result);
            //// List<UserDetailModel> lstUsersDetail = new List<UserDetailModel>();
            // return lstUsersDetail;
            var result = entities.M_UserDetails_G().ToList();
            List<UserDetailModel> lstUsersDetail = Mapping<List<UserDetailModel>>(result);
            return lstUsersDetail;
        }

        public List<GetUserDetailModel> GetDepartmentUserListDAL(int id, int userId)
        {
            //  var result = entities.M_UserDetails_G().ToList();
            // List<UserDetailModel> lstUsersDetail = Mapping<List<UserDetailModel>>(result);
            //// List<UserDetailModel> lstUsersDetail = new List<UserDetailModel>();
            // return lstUsersDetail;
            var result = entities.M_UserDepartmentList_G(id,userId).ToList();
            List<GetUserDetailModel> lstUsersDetail = Mapping<List<GetUserDetailModel>>(result);
            return lstUsersDetail;
        }
    }
}
