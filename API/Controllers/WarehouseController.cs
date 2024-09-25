using BAL.Interface.Warehouse;
using Model.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class WarehouseController : ApiController
    {
        private IWarehouseBAL _iWarehouseBAL;

        WarehouseController()
        {
            _iWarehouseBAL = ServiceFactory.GetWarehouseBALInstance();
        }

        [HttpPost]
        public IHttpActionResult SaveWarehouseData(WarehouseModel model)
        {
            return Ok(_iWarehouseBAL.SaveWarehouseDataBAL(model));
        }

        [HttpGet]
        public IHttpActionResult BookedWarehouse()
        {
            return Ok(_iWarehouseBAL.BookedWarehouseBAL());
        }

        [HttpGet]
        public IHttpActionResult GetAllPendingRequestList()
        {
            return Ok(_iWarehouseBAL.GetAllPendingRequestListBAL());
        }

        [HttpGet]
        public IHttpActionResult RequestedWarehouse(int id)
        {
            return Ok(_iWarehouseBAL.RequestedWarehouseBAL(id));
        }

        [HttpPost]
        public IHttpActionResult ConfirmBooking(WarehouseModel model)
        {
            return Ok(_iWarehouseBAL.ConfirmBookingBAL(model));
        }

        [HttpGet]
        public IHttpActionResult GetConfirmBookedWarehouseList()
        {
            return Ok(_iWarehouseBAL.GetConfirmBookedWarehouseListBAL());
        }

        [HttpGet]
        public IHttpActionResult GetBookedWarehouseById(int id)
        {
            return Ok(_iWarehouseBAL.GetBookedWarehouseByIdBAL(id));
        }

        [HttpPost]
        public IHttpActionResult RejectBooking(WarehouseModel model)
        {
            return Ok(_iWarehouseBAL.RejectBookingBAL(model));
        }

        [HttpGet]
        public IHttpActionResult GetRejectedWarehouseById(int id)
        {
            return Ok(_iWarehouseBAL.GetRejectedWarehouseByIdBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetRejectedWarehouse()
        {
            return Ok(_iWarehouseBAL.GetRejectedWarehouseBAL());
        }

        [HttpGet]
        public IHttpActionResult GetAllPendingRequestListBYId(int id)
        {
            return Ok(_iWarehouseBAL.GetAllPendingRequestListBYIdBAL(id));
        }
    }
}
