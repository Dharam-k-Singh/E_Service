using BAL.Interface.Organization;
using Model.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class OrganizationController : ApiController
    {
        private IOrganizationBAL _iOrganizationBAL;


        OrganizationController()
        {
            _iOrganizationBAL = ServiceFactory.GetOrganizationInstance();
        }

      
        public IHttpActionResult GetOrganizationId()
        {
            return Ok(_iOrganizationBAL.GetOrganizationIdBAL());
        }

        public IHttpActionResult GetOrganization(int userId)
        {
            return Ok(_iOrganizationBAL.GetOrganizationDetail(userId));
        }

    }
}
