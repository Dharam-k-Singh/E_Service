using Model.Models;
using Model.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Warehouse
{
    public interface IWarehouseDAL
    {
        ResponseInfo SaveWarehouseDataDAL(WarehouseModel model);

        BookedWarehouseModel BookedWarehouseDAL();

        List<BookedWarehouseViewModel> GetAllPendingRequestListDAL();

        BookedWarehouseModel RequestedWarehouseDAL(int BookingId);

        ResponseInfo ConfirmBookingDAL(WarehouseModel model);
        ResponseInfo RejectBookingDAL(WarehouseModel model);
        List<BookedWarehouseViewModel> GetConfirmBookedWarehouseListDAL();
        List<BookedWarehouseViewModel> GetBookedWarehouseByIdDAL(int EnterpriseId);
        List<BookedWarehouseViewModel> GetRejectedWarehouseByIdDAL(int EnterpriseId);
        List<BookedWarehouseViewModel> GetRejectedWarehouseDAL();
        List<BookedWarehouseViewModel> GetAllPendingRequestListBYIdDAL(int EnterpriseId);

    }
}
