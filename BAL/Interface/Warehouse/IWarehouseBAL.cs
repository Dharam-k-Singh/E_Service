using Model.Models;
using Model.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.Warehouse
{
    public interface IWarehouseBAL
    {
        ResponseInfo SaveWarehouseDataBAL(WarehouseModel model);
        BookedWarehouseModel BookedWarehouseBAL();

        List<BookedWarehouseViewModel> GetAllPendingRequestListBAL();
        BookedWarehouseModel RequestedWarehouseBAL(int BookingId);

        ResponseInfo ConfirmBookingBAL(WarehouseModel model);

        List<BookedWarehouseViewModel> GetConfirmBookedWarehouseListBAL();
        List<BookedWarehouseViewModel> GetBookedWarehouseByIdBAL(int EnterpriseId);
        ResponseInfo RejectBookingBAL(WarehouseModel model);

        List<BookedWarehouseViewModel> GetRejectedWarehouseByIdBAL(int EnterpriseId);
        List<BookedWarehouseViewModel> GetRejectedWarehouseBAL();

        List<BookedWarehouseViewModel> GetAllPendingRequestListBYIdBAL(int EnterpriseId);

    }
}
