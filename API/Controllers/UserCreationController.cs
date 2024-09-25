using BAL.Interface;
using Model.Models.Organization;
using Model.Models.UserCreation;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class UserCreationController : ApiController
    {
        private IUserCreationBAL _iUserCreationBAL;


        UserCreationController()
        {
            _iUserCreationBAL = ServiceFactory.GetUserCreationInstance();
        }

        [HttpPost]
        public IHttpActionResult SaveUser(UserCreationModel model)
        {
            return Ok(_iUserCreationBAL.SaveUserBAL(model));
        }

       
        [HttpGet]
        public IHttpActionResult GetUserList()
        {
            return Ok(_iUserCreationBAL.GetUserListBAL());
        }

        [HttpGet]
        public IHttpActionResult GetUserDetails(int id)
        {
            return Ok(_iUserCreationBAL.GetUserDetailsBAL(id));
        }

        [HttpPost]
        public IHttpActionResult DeleteUserDetails(int id)
        {
            return Ok(_iUserCreationBAL.DeleteUserDetailsBAL(id));
        }


        [HttpPost]
        public IHttpActionResult SavePassword(UserPasswordChangeModel model)
        {
            return Ok(_iUserCreationBAL.SavePasswordBAL(model));
        }

        [HttpPost]
        public IHttpActionResult SaveEPDetails(UserCreationCommonModel model)
        {
            return Ok(_iUserCreationBAL.SaveEPDetailsBAL(model));
        }

        [HttpPost]
        public IHttpActionResult SaveEPUser(EnterpriseCreationModel model)
        {
            return Ok(_iUserCreationBAL.SaveEPUserBAL(model));
        }

        [HttpGet]
        public IHttpActionResult GetEPUserList()
        {
            return Ok(_iUserCreationBAL.GetEPUserListBAL());
        }

        [HttpGet]
        public IHttpActionResult GetEPUserDetails(int id)
        {
            return Ok(_iUserCreationBAL.GetEPUserDetailsBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetEnterpriseUserList(int id)
        {
            return Ok(_iUserCreationBAL.GetEnterpriseUserListBAL(id));
        }

        [HttpPost]
        public IHttpActionResult SaveProfileImage(UserProfileChangeModel model)
        {
            return Ok(_iUserCreationBAL.SaveProfileImageBAL(model));
        }
    }

}
