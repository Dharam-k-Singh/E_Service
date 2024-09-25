using DAL.Interface.UserCreation;
using Model.Models;
using Model.Models.Organization;
using Model.Models.UserCreation;
using Model.Models.UserDetail;
using Model.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.UserCreation
{
    public class UserCreationDAL : BaseClassDAL, IUserCreationDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();
        UserInfo user = new UserInfo();

        public ResponseInfo SaveUserDAL(UserCreationModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            if (model.UDID == 0)
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                var result = entities.UserCreation_CRUD(model.UDID, model.EmployeeName, model.Password, model.RoleId,model.DepartmentIDs, model.EmailId, model.MobileNo, model.CreatedBy, model.IsActive, 1, OutputParam, model.saltKey);

                respInfo.ID = model.UDID;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                var result = entities.UserCreation_CRUD(model.UDID, model.EmployeeName, model.Password, model.RoleId, model.DepartmentIDs, model.EmailId, model.MobileNo, model.CreatedBy, model.IsActive, 2, OutputParam, model.saltKey);

                respInfo.ID = model.UDID;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();

            }

            return respInfo;

        }
       
        public List<GetUserCreationModel> GetUserListDAL()
        {
            var result = entities.UserCreationList_G().ToList();
            List<GetUserCreationModel> lstUserList = Mapping<List<GetUserCreationModel>>(result);
            return lstUserList;
        }

        public UserCreationModel GetUserDetailsDAL(int id)
        {

            var result = entities.UserCreation_G(id).FirstOrDefault();
            UserCreationModel lstUserList = Mapping<UserCreationModel>(result);
            return lstUserList;
        }

        public ResponseInfo DeleteUserDetailsDAL(int id)
        {
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            ResponseInfo respInfo = new ResponseInfo();
            var res = entities.UserCreation_D(id, OutputParam);

            respInfo.IsSuccess = true;
            respInfo.Msg = (string)OutputParam.Value;
            return respInfo;
        }

        public ResponseInfo SavePasswordDAL(UserPasswordChangeModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();


            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

            //var result = entities.ChangePassword_U(model.UDID,model.OldPassword, model.Password, OutputParam);
            var result = entities.UserChangePassword(model.UDID, model.Password, model.SaltKey, OutputParam);

            //respInfo.ID = model.UDID;
            // respInfo.Status = "";
            respInfo.IsSuccess = true;
            respInfo.Msg = OutputParam.Value.ToString();

            return respInfo;

        }

        public ResponseInfo SaveEPDetailsDAL(UserCreationCommonModel model1)
        {
            OrganizationModel model = model1.OrganizationModel;

            ResponseInfo respInfo = new ResponseInfo();

            DataTable dt = new DataTable();
            if (model1 != null)
            {
                dt.Columns.Add("OrganizationID", typeof(int));
                // dt.Columns.Add("InvoiceItemID", typeof(int));
                dt.Columns.Add("OrganizationName");
               
                if (model != null)
                {
                    if (model.OrganizationName != null && model.OrganizationName != "")
                    {
                        string[] landdet = model.OrganizationName.Split(new string[] { "||||" }, StringSplitOptions.None);

                        for (int i = 0; i < landdet.Length; i++)
                        {
                            string[] contactprop = landdet[i].Split(new string[] { "####" }, StringSplitOptions.None);

                            dt.Rows.Add(Convert.ToInt32(contactprop[1]),
                               
                                contactprop[0]                             
                                //contactprop[1]
                                //contactprop[2] != "NULL" ? contactprop[2] : null,
                                //contactprop[3] != "NULL" ? contactprop[3] : null,
                                //contactprop[4],

                                //model.Createdby
                                );
                        }

                    }
                }

            }
            List<SqlParameter> parameters1 = new List<SqlParameter>();

            parameters1.Add(new SqlParameter()
            {
                ParameterName = "@OrganizationName",
                SqlDbType = SqlDbType.VarChar,
                Value = model.OrganizationName,
                Direction = System.Data.ParameterDirection.Input
            });
            parameters1.Add(new SqlParameter()
            {
                ParameterName = "@AddEPDetails",
                SqlDbType = SqlDbType.Structured,
                Value = dt,
                Direction = System.Data.ParameterDirection.Input
            });

            
            SqlParameter message = new SqlParameter()
            {
                ParameterName = "@OutError",
                SqlDbType = SqlDbType.VarChar,
                Size = 1000,
                Direction = System.Data.ParameterDirection.Output
            };
            parameters1.Add(message);

            bool dtRuleData;
            try
            {
                dtRuleData = SqlManager.ExecuteNonQuery("AddEnterprise_CRUD", parameters1.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string errormessage = message.Value.ToString();


            respInfo.Status = "";
            respInfo.IsSuccess = true;
            respInfo.Msg = errormessage;

            return respInfo;
        }

        //public ResponseInfo SaveEPDetailsDAL(OrganizationModel model)
        //{
        //    ResponseInfo respInfo = new ResponseInfo();

        //    //if (model.TrainingId == 0)
        //    //{
        //    System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));


        //    var result = entities.AddEnterprise_CRUD(model.OrganizationName, OutputParam);

        //   // respInfo.ID = model.AssessmentId;
        //    respInfo.Status = "";
        //    respInfo.IsSuccess = true;
        //    respInfo.Msg = OutputParam.Value.ToString();
        //    //}

        //    return respInfo;
        //}

        public ResponseInfo SaveEPUserDAL(EnterpriseCreationModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            if (model.UDID == 0)
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                var result = entities.EnterpriseUserCreation_CRUD(model.UDID, model.OrganizationID, model.EmployeeName, model.Password,model.RoleId, model.EmailId, model.MobileNo, model.CreatedBy, model.IsActive, 1, OutputParam, model.saltKey);

                respInfo.ID = model.UDID;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                var result = entities.EnterpriseUserCreation_CRUD(model.UDID, model.OrganizationID, model.EmployeeName, model.Password, model.RoleId, model.EmailId, model.MobileNo, model.CreatedBy, model.IsActive, 2, OutputParam, model.saltKey);

                respInfo.ID = model.UDID;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();

            }

            return respInfo;

        }

        public List<GetEPUserCreationModel> GetEPUserListDAL()
        {
            var result = entities.EnterpriseUserCreationList_G().ToList();
            List<GetEPUserCreationModel> lstUserList = Mapping<List<GetEPUserCreationModel>>(result);
            return lstUserList;
        }

        public GetEPUserEditDetailsModel GetEPUserDetailsDAL(int id)
        {

            var result = entities.EnterpriseUserCreation_G(id).FirstOrDefault();
            GetEPUserEditDetailsModel lstUserList = Mapping<GetEPUserEditDetailsModel>(result);
            return lstUserList;
        }

        public List<GetEPUserCreationModel> GetEnterpriseUserListDAL(int id)
        {
            var result = entities.EnterpriseUserList_G(id).ToList();
            List<GetEPUserCreationModel> lstUserList = Mapping<List<GetEPUserCreationModel>>(result);
            return lstUserList;
        }


        public ResponseInfo SaveProfileImageDAL(UserProfileChangeModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                var result = entities.EnterpriseUserCreationProfile_U(model.UDID, model.ProfileImagePath, OutputParam);

                respInfo.ID = model.UDID;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();

           

            return respInfo;

        }
    }

}
