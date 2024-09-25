using DAL.Interface.RequestForm;
using Model.Models;
using Model.Models.RequestForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.RequestForm
{
    public class RequestFormDAL : BaseClassDAL, IRequestFormDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        //public ResponseInfo SaveRequestDAL(RequestFormModel model)
        //{
        //    ResponseInfo respInfo = new ResponseInfo();

        //    if (model.RequestId == 0)
        //    {
        //        System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

        //        ObjectParameter OutputParamReqID = new ObjectParameter("ReqID", typeof(int));

        //        int ReqID = 0;


        //        var result = entities.RequestForm_CRUD(model.RequestId, model.ReportTypeID, model.EnterpriseID, model.Topic, model.CategoryId, model.SubCategoryId, model.ContactPersonName, model.MobileNo, model.EmailId,model.SeverityId,model.UploadPath,model.RequestDescription, model.Createdby, model.IsActive, 1, OutputParamReqID, OutputParam);

        //        ReqID = (int)OutputParamReqID.Value;

        //        respInfo.ID = ReqID;
        //        respInfo.Status = "";
        //        respInfo.IsSuccess = true;
        //        respInfo.Msg = OutputParam.Value.ToString();
        //    }
        //    else
        //    {

        //        System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

        //        ObjectParameter OutputParamReqID = new ObjectParameter("ReqID", typeof(int));

        //        int ReqID = 0;

        //        var result = entities.RequestForm_CRUD(model.RequestId, model.ReportTypeID, model.EnterpriseID, model.Topic, model.CategoryId, model.SubCategoryId, model.ContactPersonName, model.MobileNo, model.EmailId, model.SeverityId, model.UploadPath, model.RequestDescription, model.Createdby, model.IsActive, 2, OutputParamReqID, OutputParam);

        //       // ReqID = model.RequestId;
        //        ReqID = (int)OutputParamReqID.Value;

        //        respInfo.ID = ReqID;
        //        respInfo.Status = "";
        //        respInfo.IsSuccess = true;
        //        respInfo.Msg = OutputParam.Value.ToString();

        //    }

        //    return respInfo;

        //}

        public ResponseInfo SaveRequestDAL(RequestFormModel model)
        {

            ResponseInfo respInfo = new ResponseInfo();
            List<SqlParameter> parameters = new List<SqlParameter>();

            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@RequestId",
                SqlDbType = SqlDbType.Int,
                Value = model.RequestId,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@ReportTypeID",
                SqlDbType = SqlDbType.Int,
                Value = model.ReportTypeID,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@EnterpriseID",
                SqlDbType = SqlDbType.Int,
                Value = model.EnterpriseID,
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
                ParameterName = "@SubCategoryId",
                SqlDbType = SqlDbType.Int,
                Value = model.SubCategoryId,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@SeverityId",
                SqlDbType = SqlDbType.Int,
                Value = model.SeverityId,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Topic",
                SqlDbType = SqlDbType.VarChar,
                Value = model.Topic,
                Direction = System.Data.ParameterDirection.Input
            });

            parameters.Add(new SqlParameter()
            {
                ParameterName = "@RequestDescription",
                SqlDbType = SqlDbType.VarChar,
                Value = model.RequestDescription,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@ContactPersonName",
                SqlDbType = SqlDbType.VarChar,
                Value = model.ContactPersonName,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@EmailId",
                SqlDbType = SqlDbType.VarChar,
                Value = model.EmailId,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters.Add(new SqlParameter()
            {
                ParameterName = "@MobileNo",
                SqlDbType = SqlDbType.VarChar,
                Value = model.MobileNo,
                Direction = System.Data.ParameterDirection.Input
            });

            parameters.Add(new SqlParameter()
            {
                ParameterName = "@UploadPath",
                SqlDbType = SqlDbType.VarChar,
                Value = model.UploadPath,
                Direction = System.Data.ParameterDirection.Input
            });

            parameters.Add(new SqlParameter()
            {
                ParameterName = "@createdby",
                SqlDbType = SqlDbType.Int,
                Value = model.Createdby,
                Direction = System.Data.ParameterDirection.Input
            });


            parameters.Add(new SqlParameter()
            {
                ParameterName = "@Request_Uploads_TT",
                SqlDbType = SqlDbType.Structured,
                Value = model.dtUploads,
                Direction = System.Data.ParameterDirection.Input
            });

            parameters.Add(new SqlParameter()
            {
                ParameterName = "@IsActive",
                SqlDbType = SqlDbType.Bit,
                Value = model.IsActive,
                Direction = System.Data.ParameterDirection.Input
            });

            if (model.RequestId == 0)
            {
                parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Flag",
                    SqlDbType = SqlDbType.Int,
                    Value = 1,
                    Direction = System.Data.ParameterDirection.Input
                });
            }
            else
            {
                parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Flag",
                    SqlDbType = SqlDbType.Int,
                    Value = 2,
                    Direction = System.Data.ParameterDirection.Input
                });
            }
            //parameters.Add(new SqlParameter()
            //{
            //    ParameterName = "@flag",
            //    SqlDbType = SqlDbType.SmallInt,
            //    Value = (int)Model.CommonEnum.LOV.SqlOperations.INSERT,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            SqlParameter message = new SqlParameter()
            {
                ParameterName = "@OutError",
                SqlDbType = SqlDbType.VarChar,
                Size = 1000,
                Direction = System.Data.ParameterDirection.Output
            };

            parameters.Add(message);

            SqlParameter ReqID = new SqlParameter()
            {
                ParameterName = "@ReqID",
                SqlDbType = SqlDbType.Int,
                Value = model.RequestId,
                Direction = System.Data.ParameterDirection.Output
            };
            parameters.Add(ReqID);

            bool dtRuleData;
            try
            {
                dtRuleData = SqlManager.ExecuteNonQuery("RequestForm_CRUD", parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // var dtIncidentData = SqlManager.ExecuteNonQuery("Incident_CRUD", parameters.ToArray());
            string errormessage = message.Value.ToString();

            respInfo.ID = (int)ReqID.Value;
            //respInfo.ID = 0;
            //respInfo.Status = errormessage;
            respInfo.IsSuccess = true;
            respInfo.Msg = errormessage;
            return respInfo;
        }

        public List<RequestFormListModel> GetLFZReqListDAL(int userId)
        {
            var result = entities.RequestFormLFZUserList_G(userId).ToList();
            List<RequestFormListModel> lstUserList = Mapping<List<RequestFormListModel>>(result);
            return lstUserList;
        }

        public List<RequestFormListModel> GetEPReqListDAL(int id)
        {
            var result = entities.RequestFormEPUserList_G(id).ToList();
            List<RequestFormListModel> lstUserList = Mapping<List<RequestFormListModel>>(result);
            return lstUserList;
        }

        public ResponseInfo SaveFeedBackRatingDAL(RequestListCommonModel model1)

        {

            RequestRatingModel model = model1.SaveFeedbackRating;


            ResponseInfo respInfo = new ResponseInfo();

            if (model.RequestId == 0)
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                var result = entities.RequestFeedBackRating_CRUD(model.RequestId, model.RatingtID, model.FeedbackComments, model.Createdby, model.IsActive, 1, OutputParam);
                // respInfo.ID = model.RequestId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                var result = entities.RequestFeedBackRating_CRUD(model.RequestId, model.RatingtID, model.FeedbackComments, model.Createdby, model.IsActive, 2, OutputParam);
                // respInfo.ID = model.UDID;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();

            }

            return respInfo;

        }

        public RequestFormEditModel GetEditRequestDAL(int id)
        {
            var result = entities.RequestFormEdit_G(id).FirstOrDefault();
            RequestFormEditModel lstUserList = Mapping<RequestFormEditModel>(result);
            return lstUserList;
        }

        public ResponseInfo DeleteRequestDAL(int id, int userId)
        {
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            ResponseInfo respInfo = new ResponseInfo();
            var res = entities.RequestForm_D(id, userId, OutputParam);

            respInfo.IsSuccess = true;
            respInfo.Msg = (string)OutputParam.Value;
            return respInfo;

        }

        public List<RequestListAdminModel> GetReqAdminListDAL()
            {
                var result = entities.RequestListAdmin_G().ToList();
                List<RequestListAdminModel> lstUserList = Mapping<List<RequestListAdminModel>>(result);
                return lstUserList;
            }

            public List<RequestWorkingListModel> GetReqWorkingListDAL(int userId)
            {
                var result = entities.RequestWorkingListAdmin_G(userId).ToList();
                List<RequestWorkingListModel> lstUserList = Mapping<List<RequestWorkingListModel>>(result);
                return lstUserList;
            }

            public List<RequestHistoryListModel> GetReqHistoryDetailsDAL(int id)
            {
                var result = entities.RequestHistoryList_G(id).ToList();
                List<RequestHistoryListModel> lstUserList = Mapping<List<RequestHistoryListModel>>(result);
                return lstUserList;
            }

            public ResponseInfo SaveActionDetailsDAL(RequestAdminListCommonModel model1)

            {

                RequestActionAdminModel model = model1.RequestSaveActionAdmin;


                ResponseInfo respInfo = new ResponseInfo();

                if (model.RequestId == 0)
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                    var result = entities.AdminRequestAllocation_CRUD(model.RequestId, model.DepartmentID, model.PriorityID, model.RequestComments, model.Commitementdate, model.EscalateOndate, model.EscLevel1EmailId, model.UploadPath, model.Createdby, model.IsActive, 1, OutputParam);

                    // respInfo.ID = model.RequestId;
                    respInfo.Status = "";
                    respInfo.IsSuccess = true;
                    respInfo.Msg = OutputParam.Value.ToString();
                }
                else
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                    var result = entities.AdminRequestAllocation_CRUD(model.RequestId, model.DepartmentID, model.PriorityID, model.RequestComments, model.Commitementdate, model.EscalateOndate, model.EscLevel1EmailId, model.UploadPath, model.Createdby, model.IsActive, 1, OutputParam);

                    // respInfo.ID = model.UDID;
                    respInfo.Status = "";
                    respInfo.IsSuccess = true;
                    respInfo.Msg = OutputParam.Value.ToString();

                }

                return respInfo;

            }

            public List<TicketListModel> GetMyTicketListDAL(int id)
            {
                var result = entities.MyTicketList_G(id).ToList();
                List<TicketListModel> lstUserList = Mapping<List<TicketListModel>>(result);
                return lstUserList;
            }

            public ResponseInfo SaveChangeTicketStatusDAL(TicketListCommonModel model1)
            {
                ChangeTicketStatusModel model = model1.ChangeTicketStatus;


                ResponseInfo respInfo = new ResponseInfo();

                if (model.AllocationID == 0)
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                    var result = entities.ChangeTicketStatus_CRUD(model.AllocationID, model.RequestStatusID, model.RequestComments, model.UploadPath, model.Createdby, model.IsActive, 1, OutputParam);
                    // respInfo.ID = model.RequestId;
                    respInfo.Status = "";
                    respInfo.IsSuccess = true;
                    respInfo.Msg = OutputParam.Value.ToString();
                }
                else
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                    var result = entities.ChangeTicketStatus_CRUD(model.AllocationID, model.RequestStatusID, model.RequestComments, model.UploadPath, model.Createdby, model.IsActive, 1, OutputParam);
                    // respInfo.ID = model.UDID;
                    respInfo.Status = "";
                    respInfo.IsSuccess = true;
                    respInfo.Msg = OutputParam.Value.ToString();

                }

                return respInfo;

            }

            public List<TicketListModel> GetDepartmentTicketListDAL(int userId)
            {
                var result = entities.DepartmentTicketList_G(userId).ToList();
                List<TicketListModel> lstUserList = Mapping<List<TicketListModel>>(result);
                return lstUserList;
            }

            public ResponseInfo SaveAllocateRequestDAL(int id, int userId)
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
                ResponseInfo respInfo = new ResponseInfo();
                var res = entities.AllocateRequest_CRUD(id, userId, OutputParam);

                respInfo.IsSuccess = true;
                respInfo.Msg = (string)OutputParam.Value;
                return respInfo;
            }

            public ResponseInfo SaveAllocateToTeamDAL(AllocateToTeamModel model)
            {

                ResponseInfo respInfo = new ResponseInfo();

                if (model.AllocationID == 0)
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                    var result = entities.AllocateTicketToTeam_CRUD(model.AllocationID, model.LFZTeamMembers, model.CreatedBy, 1, OutputParam);
                    // respInfo.ID = model.RequestId;
                    respInfo.Status = "";
                    respInfo.IsSuccess = true;
                    respInfo.Msg = OutputParam.Value.ToString();
                }
                else
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                    var result = entities.AllocateTicketToTeam_CRUD(model.AllocationID, model.LFZTeamMembers, model.CreatedBy, 1, OutputParam);
                    // respInfo.ID = model.UDID;
                    respInfo.Status = "";
                    respInfo.IsSuccess = true;
                    respInfo.Msg = OutputParam.Value.ToString();

                }

                return respInfo;
            }

            public List<TicketListModel> GetHODDepTicketListDAL(int id)
            {
                var result = entities.Department_HODTicketList_G(id).ToList();
                List<TicketListModel> lstUserList = Mapping<List<TicketListModel>>(result);
                return lstUserList;
            }

            public ResponseInfo DeleteFileDAL(UploadPathModel model)
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
                ResponseInfo respInfo = new ResponseInfo();
                var res = entities.File_d(model.UploadFilePath, model.Udid, OutputParam);
                respInfo.IsSuccess = true;
                respInfo.Msg = (string)OutputParam.Value;
                return respInfo;
            }
            public ResponseInfo SaveReopenRequestDAL(RequestListCommonModel model1)
            {
                ReOpenTicketChangeStatus model = model1.ReOpenTicketStatus;


                ResponseInfo respInfo = new ResponseInfo();

                if (model.RequestId == 0)
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                    var result = entities.ReopenRequest_U(model.RequestId, model.RequestStatusID, model.ReOpenedComments, model.Createdby, model.IsActive, 1, OutputParam);
                    // respInfo.ID = model.RequestId;
                    respInfo.Status = "";
                    respInfo.IsSuccess = true;
                    respInfo.Msg = OutputParam.Value.ToString();
                }
                else
                {
                    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                    var result = entities.ReopenRequest_U(model.RequestId, model.RequestStatusID, model.ReOpenedComments, model.Createdby, model.IsActive, 1, OutputParam);
                    // respInfo.ID = model.UDID;
                    respInfo.Status = "";
                    respInfo.IsSuccess = true;
                    respInfo.Msg = OutputParam.Value.ToString();

                }

                return respInfo;


                //System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
                //ResponseInfo respInfo = new ResponseInfo();
                //ObjectParameter OutputParamReqID = new ObjectParameter("ReqID", typeof(int));

                // int ReqID = 0;

                //var res = entities.ReopenRequest_U(id,0, userId, OutputParamReqID, OutputParam);

                //ReqID = (int)OutputParamReqID.Value;

                //respInfo.ID = ReqID;
                //respInfo.IsSuccess = true;
                //respInfo.Msg = (string)OutputParam.Value;
                //return respInfo;
            }
        }
    }