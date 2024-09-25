using BAL.Interface.Department;
using Model.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DepartmentController : ApiController
    {
        private IDepartmentBAL _iDepartmentBAL;
        DepartmentController()
        {
            _iDepartmentBAL = ServiceFactory.GetDepartmentBALInstance();
        }

        [HttpPost]
        public IHttpActionResult SaveDepartment(DepartmentModel model)
        {
            return Ok(_iDepartmentBAL.SaveDepartmentBAL(model));
        }

        public IHttpActionResult GetListDepartment()
        {
            return Ok(_iDepartmentBAL.GetListDepartmentBAL());
        }

        [HttpGet]
        public IHttpActionResult GetEditDepartment(int id)
        {
            return Ok(_iDepartmentBAL.GetEditDepartmentBAL(id));
        }

        [HttpPost]
        public IHttpActionResult DeleteDepartment(int id)
        {
            return Ok(_iDepartmentBAL.DeleteDepartmentBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetEscalationEmailId(int id)
        {
            return Ok(_iDepartmentBAL.GetEscalationEmailIdBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetListDepartmentMapped(int userId)
        {
            return Ok(_iDepartmentBAL.GetListDepartmentMappedBAL(userId));
        }
    }
}
