using BAL.Interface.ListOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ListOfCategoryController : ApiController
    {
        private IListOfCategoryBAL _iListOfCategoryDetail;
        public ListOfCategoryController()
        {
            _iListOfCategoryDetail = ServiceFactory.GetListOfCategoryInstance();
        }

       
        public IHttpActionResult GetListOfCategory(int id)
        {
            return Ok(_iListOfCategoryDetail.GetListOfCategory(id));
        }

        public IHttpActionResult GetListOfSubCategory(int id)
        {
            return Ok(_iListOfCategoryDetail.GetListOfSubCategory(id));
        }

        // public IHttpActionResult GetListOfLineItems(int id)
        //{
        //    return Ok(_iListOfCategoryDetail.GetListOfLineItems(id));
        //}

    }
}

