using BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model.Models;
using Model.Models.UserDetail;
using Model.Models.Account;
using Model.Models.Home;

namespace API.Controllers
{
    public class HomeController : ApiController
    {
        private IHomeBAL _iHomeBAL;
        HomeController()
        {
            _iHomeBAL = ServiceFactory.GetHomeInstance();
        }

        //[HttpPost]
        //public IHttpActionResult SaveRegistration(RegistrationModel model)
        //{
        //    return Ok(_iHomeBAL.SaveRegistrationBAL(model));
        //}

        [HttpPost]
        public IHttpActionResult CheckLogin(UserDetailModel model)
        {
            return Ok(_iHomeBAL.CheckLoginBAL(model));
        }

        [HttpGet]
        public IHttpActionResult GetRequestCount(int userId)
        {
            return Ok(_iHomeBAL.GetRequestCountBAL(userId));
        }

        [HttpPost]
        public IHttpActionResult CheckValidUser(ValididateUser_OnePortal Email)
        {
            return Ok(_iHomeBAL.ValidUserBAL(Email));
        }

        [HttpPost]
        public IHttpActionResult ServiceReport(ServiceReportModel model)
        {
            return Ok(_iHomeBAL.ServiceReportBAL(model));
        }
        [HttpGet]
        public IHttpActionResult Top3ComplaintDrivers()
        {
            return Ok(_iHomeBAL.Top3BAL());
        }
        [HttpGet]
        public IHttpActionResult ComplaintDriversDetails(int? Id, int? UserId)
        {
            return Ok(_iHomeBAL.DetailsComplaintDriversBAL(Id, UserId));
        }
        [HttpGet]
        public IHttpActionResult Top3SLA()
        {
            return Ok(_iHomeBAL.Top3SLABAL());
        }
        //[HttpGet]
        //public IHttpActionResult DashComplaintDrivers()
        //{
        //    return Ok(_iHomeBAL.DashComplaintDriversBAL());
        //}

        //[HttpGet]
        //public IHttpActionResult DashMostComplains()
        //{
        //    return Ok(_iHomeBAL.DashMostComplainsBAL());
        //}
    }
}
