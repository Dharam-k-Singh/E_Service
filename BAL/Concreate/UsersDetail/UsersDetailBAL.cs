using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using DAL.Interface;
using Model.Models.UserDetail;

namespace BAL.Concreate
{
    public class UsersDetailBAL:IUsersDetailBAL
    {
        private IUsersDetailDAL _iUsersDetail;

        public UsersDetailBAL()
        {
            _iUsersDetail = BALFactory.GetUserDetailInstance();
        }
        
        public List<UserDetailModel> GetUsersDetails()
        {
            return _iUsersDetail.GetUsersDetails();
        }

        public List<GetUserDetailModel> GetDepartmentUserListBAL(int id, int userId)
        {
            return _iUsersDetail.GetDepartmentUserListDAL(id,userId);
        }
    }
}
