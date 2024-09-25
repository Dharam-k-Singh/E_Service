
using BAL.Interface;
using DAL.Interface.UserCreation;
using Model.Models;
using Model.Models.Organization;
using Model.Models.UserCreation;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.UserCreation
{
    public class UserCreationBAL : IUserCreationBAL
    {
        private IUserCreationDAL _iUserCreationDAL;

        public UserCreationBAL()
        {
            _iUserCreationDAL = BALFactory.GetUserCreationDALInstance();
        }

        public ResponseInfo SaveUserBAL(UserCreationModel model)
        {
            return _iUserCreationDAL.SaveUserDAL(model);
        }

        public List<GetUserCreationModel> GetUserListBAL()
        {
            return _iUserCreationDAL.GetUserListDAL();
        }
        public UserCreationModel GetUserDetailsBAL(int id)
        {
            return _iUserCreationDAL.GetUserDetailsDAL(id);
        }

        public ResponseInfo DeleteUserDetailsBAL(int id)
        {
            return _iUserCreationDAL.DeleteUserDetailsDAL(id);
        }

        public ResponseInfo SavePasswordBAL(UserPasswordChangeModel model)
        {
            return _iUserCreationDAL.SavePasswordDAL(model);
        }

        public ResponseInfo SaveEPDetailsBAL(UserCreationCommonModel model)
        {
            return _iUserCreationDAL.SaveEPDetailsDAL(model);
        }

        public ResponseInfo SaveEPUserBAL(EnterpriseCreationModel model)
        {
            return _iUserCreationDAL.SaveEPUserDAL(model);
        }

        public List<GetEPUserCreationModel> GetEPUserListBAL()
        {
            return _iUserCreationDAL.GetEPUserListDAL();
        }

        public GetEPUserEditDetailsModel GetEPUserDetailsBAL(int id)
        {
            return _iUserCreationDAL.GetEPUserDetailsDAL(id);
        }

        public List<GetEPUserCreationModel> GetEnterpriseUserListBAL(int id)
        {
            return _iUserCreationDAL.GetEnterpriseUserListDAL(id);
        }

        public ResponseInfo SaveProfileImageBAL(UserProfileChangeModel model)
        {
            return _iUserCreationDAL.SaveProfileImageDAL(model);
        }
    }
}
