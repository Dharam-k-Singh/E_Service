using Model.Models;
using Model.Models.Organization;
using Model.Models.UserCreation;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.UserCreation
{
    public interface IUserCreationDAL
    {
        ResponseInfo SaveUserDAL(UserCreationModel model);

        List<GetUserCreationModel> GetUserListDAL();

        UserCreationModel GetUserDetailsDAL(int id);

        ResponseInfo DeleteUserDetailsDAL(int id);

        ResponseInfo SavePasswordDAL(UserPasswordChangeModel model);

        ResponseInfo SaveEPDetailsDAL(UserCreationCommonModel model);

        ResponseInfo SaveEPUserDAL(EnterpriseCreationModel model);

        List<GetEPUserCreationModel> GetEPUserListDAL();

        GetEPUserEditDetailsModel GetEPUserDetailsDAL(int id);

        List<GetEPUserCreationModel> GetEnterpriseUserListDAL(int id);

        ResponseInfo SaveProfileImageDAL(UserProfileChangeModel model);

    }
}
