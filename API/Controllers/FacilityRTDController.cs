using BAL.Interface.FacilityRTD;
using Model.Models.FacilityRTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class FacilityRTDController : ApiController
    {
        private IFacilityRTDBAL _iFacilityRTDBAL;

        FacilityRTDController()
        {
            _iFacilityRTDBAL = ServiceFactory.GetFacilityRTDBALInstance();
        }

       // [HttpPost]
        public IHttpActionResult GetWeeksList()
        {
            return Ok(_iFacilityRTDBAL.GetWeeksListBAL());
        } 
        //[HttpPost]
        //public IHttpActionResult GetWeeksList(PassIdModel model)
        //{
        //    return Ok(_iFacilityRTDBAL.GetWeeksListBAL(model));
        //}

        public IHttpActionResult GetWeeksDetails(int id)
        {
            return Ok(_iFacilityRTDBAL.GetWeeksDetailsBAL(id));
        }

        [HttpPost]
        public IHttpActionResult Save(FoodDetailsModel model)
        {
            return Ok(_iFacilityRTDBAL.SaveBAL(model));
        }

        public IHttpActionResult GetListFoodDetails()
        {
            return Ok(_iFacilityRTDBAL.GetListFoodDetailsBAL());
        }

        [HttpGet]
        public IHttpActionResult GetEditFoodDetails(int Id, int UserId)
        {
            return Ok(_iFacilityRTDBAL.GetEditFoodDetailsBAL(Id, UserId));
        }

        [HttpGet]
        public IHttpActionResult GetViewFoodDetails(int Id, int UserId)
        {
            return Ok(_iFacilityRTDBAL.GetViewFoodDetailsBAL(Id, UserId));
        }

        [HttpPost]
        public IHttpActionResult GetMenuViewDetails(PassIdModel model)
        {
            return Ok(_iFacilityRTDBAL.GetMenuViewDetailsBAL(model));
        }


        [HttpPost]
        public IHttpActionResult SaveMeterDetails(MeterReadingModel model)
        {
            return Ok(_iFacilityRTDBAL.SaveMeterDetailsBAL(model));
        }

        public IHttpActionResult GetListMeterDetails(int? id)
        {
            return Ok(_iFacilityRTDBAL.GetListMeterDetailsBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetEditMeterDetails(int id)
        {
            return Ok(_iFacilityRTDBAL.GetEditMeterDetailsBAL(id));
        }

    }
}
