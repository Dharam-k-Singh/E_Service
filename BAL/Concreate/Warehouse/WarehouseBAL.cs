using BAL.Interface.Warehouse;
using DAL.Interface.Warehouse;
using Model.Models;
using Model.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.Warehouse
{
    public class WarehouseBAL : IWarehouseBAL
    {
        private IWarehouseDAL _iWarehouseDAL;
        public WarehouseBAL()
        {
            _iWarehouseDAL = BALFactory.GetWarehouseDALInstance();
        }
        public ResponseInfo SaveWarehouseDataBAL(WarehouseModel model)
        {
            return _iWarehouseDAL.SaveWarehouseDataDAL(model);
        }

        public BookedWarehouseModel BookedWarehouseBAL()
        {
            return _iWarehouseDAL.BookedWarehouseDAL();
        }

        public List<BookedWarehouseViewModel> GetAllPendingRequestListBAL()
        {
            return _iWarehouseDAL.GetAllPendingRequestListDAL();
        }

        public BookedWarehouseModel RequestedWarehouseBAL(int BookingId)
        {
            return _iWarehouseDAL.RequestedWarehouseDAL(BookingId);
        }

        public ResponseInfo ConfirmBookingBAL(WarehouseModel model)
        {
            return _iWarehouseDAL.ConfirmBookingDAL(model);
        }

        public List<BookedWarehouseViewModel> GetConfirmBookedWarehouseListBAL()
        {
            return _iWarehouseDAL.GetConfirmBookedWarehouseListDAL();
        }

        public List<BookedWarehouseViewModel> GetBookedWarehouseByIdBAL(int EnterpriseId)
        {
            return _iWarehouseDAL.GetBookedWarehouseByIdDAL(EnterpriseId);
        }

        public ResponseInfo RejectBookingBAL(WarehouseModel model)
        {
            return _iWarehouseDAL.RejectBookingDAL(model);
        }

        public List<BookedWarehouseViewModel> GetRejectedWarehouseByIdBAL(int EnterpriseId)
        {
            return _iWarehouseDAL.GetRejectedWarehouseByIdDAL(EnterpriseId);
        }

        public List<BookedWarehouseViewModel> GetRejectedWarehouseBAL()
        {
            return _iWarehouseDAL.GetRejectedWarehouseDAL();
        }

        public List<BookedWarehouseViewModel> GetAllPendingRequestListBYIdBAL(int EnterpriseId)
        {
            return _iWarehouseDAL.GetAllPendingRequestListBYIdDAL(EnterpriseId);
        }
    }
}
