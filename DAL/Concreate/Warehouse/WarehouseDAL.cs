using DAL.Interface.Warehouse;
using Model.Models;
using Model.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.Warehouse
{
    public class WarehouseDAL : BaseClassDAL, IWarehouseDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        public ResponseInfo SaveWarehouseDataDAL(WarehouseModel model)
        {
            ResponseInfo resp = new ResponseInfo();
            List<SqlParameter> parameters = new List<SqlParameter>();
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@BookingId",
                SqlDbType = SqlDbType.Int,
                Value = model.BookingId,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@EnterpriseId",
                SqlDbType = SqlDbType.Int,
                Value = model.EnterpriseId,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@CategoryId",
                SqlDbType = SqlDbType.Int,
                Value = model.CategoryId,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@SizeRequired",
                SqlDbType = SqlDbType.VarChar,
                Value = model.RequiredSize,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@RequiredFrom",
                SqlDbType = SqlDbType.DateTime,
                Value = model.RequiredFrom,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@RequiredTo",
                SqlDbType = SqlDbType.DateTime,
                Value = model.ReqioredTill,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@WarehouseDescription",
                SqlDbType = SqlDbType.VarChar,
                Value = model.WarehouseDescription,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Createdby",
                SqlDbType = SqlDbType.Int,
                Value = model.Createdby,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@IsActive",
                SqlDbType = SqlDbType.Bit,
                Value = 1,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Map_Warehousebooking_TT",
                SqlDbType = SqlDbType.Structured,
                Value = model.Map_Warehousebooking_TT,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Flag",
                SqlDbType = SqlDbType.TinyInt,
                Value = 1,
                Direction = System.Data.ParameterDirection.Input
            });
            SqlParameter message = new SqlParameter()
            {
                ParameterName = "@OutError",
                SqlDbType = SqlDbType.VarChar,
                Size = 1000,
                Direction = System.Data.ParameterDirection.Output
            };
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@StorageTypeId",
                SqlDbType = SqlDbType.Int,
                Value = model.StorageTypeId,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@StorageArea",
                SqlDbType = SqlDbType.VarChar,
                Value = model.StorageArea,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(message);
            bool dtRuleData;
            try
            {
                dtRuleData = SqlManager.ExecuteNonQuery("WarehouseBooking_CRUD", parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string errormessage = message.Value.ToString();
            resp.ID = 0;
            resp.IsSuccess = true;
            resp.Msg = errormessage;
            return resp;
        }

        public BookedWarehouseModel BookedWarehouseDAL()
        {
            var result = entities.BookedWarehouse_G().FirstOrDefault();
            BookedWarehouseModel lstWarehouse = Mapping<BookedWarehouseModel>(result);
            return lstWarehouse;
        }

        public List<BookedWarehouseViewModel> GetAllPendingRequestListDAL()
        {
            var result = entities.WarehouseAllPendingRequest_G().ToList();
            List<BookedWarehouseViewModel> lstWarehouse = Mapping<List<BookedWarehouseViewModel>>(result);
            return lstWarehouse;
        }

        public BookedWarehouseModel RequestedWarehouseDAL(int BookingId)
        {
            var result = entities.RequestedWarehouse_G(BookingId).FirstOrDefault();
            BookedWarehouseModel BookedWarehouses = new BookedWarehouseModel();
            BookedWarehouses.WarehouseIds = result;
            return BookedWarehouses;
        }

        public ResponseInfo ConfirmBookingDAL(WarehouseModel model)
        {
            ResponseInfo resp = new ResponseInfo();
            List<SqlParameter> parameters = new List<SqlParameter>();
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@BookingId",
                SqlDbType = SqlDbType.Int,
                Value = model.BookingId,
                Direction = System.Data.ParameterDirection.Input
            });

            parameters.Add(new SqlParameter()
            {
                ParameterName = "@CreatedBy",
                SqlDbType = SqlDbType.Int,
                Value = model.Createdby,
                Direction = System.Data.ParameterDirection.Input
            });
            SqlParameter message = new SqlParameter()
            {
                ParameterName = "@OutError",
                SqlDbType = SqlDbType.VarChar,
                Size = 1000,
                Direction = System.Data.ParameterDirection.Output
            };
            parameters.Add(message);
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Map_Warehousebooking_TT",
                SqlDbType = SqlDbType.Structured,
                Value = model.Map_Warehousebooking_TT,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@ApproverDescription",
                SqlDbType = SqlDbType.VarChar,
                Value = model.ApproverDescription,
                Size = 50000,
                Direction = System.Data.ParameterDirection.Input
            });
            bool dtRuleData;
            try
            {
                dtRuleData = SqlManager.ExecuteNonQuery("ConfirmWarehouse_U", parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string errormessage = message.Value.ToString();
            resp.ID = 0;
            resp.IsSuccess = true;
            resp.Msg = errormessage;
            return resp;
        }

        public List<BookedWarehouseViewModel> GetConfirmBookedWarehouseListDAL()
        {
            var result = entities.ConfirmEnterpriseWarehouse_G().ToList();
            List<BookedWarehouseViewModel> lstWarehouse = Mapping<List<BookedWarehouseViewModel>>(result);
            return lstWarehouse;
        }

        public List<BookedWarehouseViewModel> GetBookedWarehouseByIdDAL(int EnterpriseId)
        {
            var result = entities.BookedWarehouseById_G(EnterpriseId).ToList();
            List<BookedWarehouseViewModel> lstWarehouse = Mapping<List<BookedWarehouseViewModel>>(result);
            return lstWarehouse;
        }

        public ResponseInfo RejectBookingDAL(WarehouseModel model)
        {
            ResponseInfo resp = new ResponseInfo();
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            var result = entities.RejectWarehouse_U(model.BookingId, model.Createdby, OutputParam, model.ApproverDescription);
            resp.ID = 0;
            resp.IsSuccess = true;
            resp.Msg = OutputParam.Value.ToString();
            return resp;
        }

        public List<BookedWarehouseViewModel> GetRejectedWarehouseByIdDAL(int EnterpriseId)
        {
            var result = entities.RejectedWarehouseById(EnterpriseId).ToList();
            List<BookedWarehouseViewModel> lstWarehouse = Mapping<List<BookedWarehouseViewModel>>(result);
            return lstWarehouse;
        }

        public List<BookedWarehouseViewModel> GetRejectedWarehouseDAL()
        {
            var result = entities.RejectedWarehouse_G().ToList();
            List<BookedWarehouseViewModel> lstWarehouse = Mapping<List<BookedWarehouseViewModel>>(result);
            return lstWarehouse;
        }

        public List<BookedWarehouseViewModel> GetAllPendingRequestListBYIdDAL(int EnterpriseId)
        {
            var result = entities.WarehouseAllPendingRequest_ById(EnterpriseId).ToList();
            List<BookedWarehouseViewModel> lstWarehouse = Mapping<List<BookedWarehouseViewModel>>(result);
            return lstWarehouse;
        }
    }
}
