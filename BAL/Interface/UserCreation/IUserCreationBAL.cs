using Model.Models;
using Model.Models.Organization;
using Model.Models.UserCreation;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
    public interface IUserCreationBAL

    {
        ResponseInfo SaveUserBAL(UserCreationModel model);

        List<GetUserCreationModel> GetUserListBAL();

        UserCreationModel GetUserDetailsBAL(int id);

        ResponseInfo DeleteUserDetailsBAL(int id);

        ResponseInfo SavePasswordBAL(UserPasswordChangeModel model);

        ResponseInfo SaveEPDetailsBAL(UserCreationCommonModel model);

        ResponseInfo SaveEPUserBAL(EnterpriseCreationModel model);

        List<GetEPUserCreationModel> GetEPUserListBAL();

        GetEPUserEditDetailsModel GetEPUserDetailsBAL(int id);

        List<GetEPUserCreationModel> GetEnterpriseUserListBAL(int id);

        ResponseInfo SaveProfileImageBAL(UserProfileChangeModel model);

    }
}
