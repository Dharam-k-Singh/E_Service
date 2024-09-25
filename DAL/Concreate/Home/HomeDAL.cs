using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Concreate;
using System.Data.SqlClient;
using System.Data;
using Model.Models.UserDetail;
using System.Data.Entity.Core.Objects;
using System.Security.Cryptography;
using Model.Models.Home;
using Model.Models.Account;
using Model.Models.RequestForm;

namespace DAL.Concreate
{
    public class HomeDAL : BaseClassDAL, IHomeDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        public ResponseInfo CheckLoginDAL(UserDetailModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter()
            {
                ParameterName = "@EmailId",
                SqlDbType = SqlDbType.VarChar,
                Value = model.EmailId,
                Direction = System.Data.ParameterDirection.Input


            });

            //Rahul Added
            DataSet objData = new DataSet();
            objData = SqlManager.ExecuteDataSet("CheckUser", parameters.ToArray());
            string databasePassword = objData.Tables[0].Rows[0]["Password"].ToString();
            string saltKey = objData.Tables[0].Rows[0]["saltKey"].ToString();
            string checkPassword = EncodePassword(model.Password, saltKey); //Create password and check below.
            model.Password = checkPassword;
            //Rahul End


            parameters.Add(new SqlParameter()
            {
                ParameterName = "@password",
                SqlDbType = SqlDbType.VarChar,
                Value = model.Password,
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

            var dtRuleData = SqlManager.ExecuteNonQuery("UserLogin", parameters.ToArray());
            string errormessage = message.Value.ToString();
            respInfo.ID = 0;
            respInfo.Status = errormessage;
            respInfo.IsSuccess = true;
            return respInfo;
        }

        public static string EncodePassword(string pass, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }

        public static string EncodePasswordMd5(string pass)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(encodedBytes);
        }


        public Dsb_RequestCountListModel GetRequestCountDAL(int userId)
        {
            var result = entities.Dashboard(userId).FirstOrDefault();
            Dsb_RequestCountListModel surveyDashboard = Mapping<Dsb_RequestCountListModel>(result);
            return surveyDashboard;
        }

        public ValididateUser_OnePortal ValidUser(ValididateUser_OnePortal Email)
        {
            var result = entities.ValidateUser_OnePortal(Email.EmailID).FirstOrDefault();
            ValididateUser_OnePortal userdetails = Mapping<ValididateUser_OnePortal>(result);
            return userdetails;
        }

        public List<ServiceReport> ServiceReportDAL(ServiceReportModel model)
        
        {
            //model.Severity = "High";

            var result = entities.Eservice_Report(model.ReportType, model.RequestStatus, model.Enterprise, model.Category, model.SubCategory, model.Severity, model.Topic, model.RequestDescription, model.ContactPersonName, model.EmailId,model.Createddate,model.Createddate2).ToList();
            List<ServiceReport> lstServiceReport = Mapping<List<ServiceReport>>(result);
            return lstServiceReport;

            ////List<ServiceReport> lst = new List<ServiceReport>();
            //List<SqlParameter> parameters1 = new List<SqlParameter>();
            //parameters1.Add(new SqlParameter("@ReportType", model.ReportType));
            //parameters1.Add(new SqlParameter("@RequestStatus", model.RequestStatus));
            //parameters1.Add(new SqlParameter("@Enterprise", model.Enterprise));
            //parameters1.Add(new SqlParameter("@Category", model.Category));
            //parameters1.Add(new SqlParameter("@Severity", model.Severity));
            //parameters1.Add(new SqlParameter("@Topic", model.Topic));
            //parameters1.Add(new SqlParameter("@SubCategory", model.SubCategory));
            //parameters1.Add(new SqlParameter("@RequestDescription", model.RequestDescription));
            //parameters1.Add(new SqlParameter("@ContactPersonName", model.ContactPersonName));
            //parameters1.Add(new SqlParameter("@EmailId", model.EmailId));
            //DataSet dataSet2 = SqlManager.ExecuteDataSet("Eservice_Report", parameters1.ToArray());
            //var empList = dataSet2.Tables[0].AsEnumerable().Select(dataRow => new ServiceReport
            //{
            //    ReportType = dataRow.Field<string>("ReportType"),
            //    RequestStatus = dataRow.Field<string>("RequestStatus"),
            //    Enterprise = dataRow.Field<string>("Enterprise"),
            //    Category = dataRow.Field<string>("Category"),
            //    Severity = dataRow.Field<string>("Severity"),
            //    Topic = dataRow.Field<string>("Topic"),
            //    SubCategory = dataRow.Field<string>("SubCategory"),
            //    RequestDescription = dataRow.Field<string>("RequestDescription"),
            //    ContactPersonName = dataRow.Field<string>("ContactPersonName"),
            //    EmailId = dataRow.Field<string>("EmailId")
            //}).ToList();
            //return empList;
        }

        //public List<ComplaintDriversViewModel> DashComplaintDriversDAL()
        //{
        //    var result = entities.DashComplaintDrivers_G().ToList();
        //    List<ComplaintDriversViewModel> lstDashCom = Mapping<List<ComplaintDriversViewModel>>(result);
        //    return lstDashCom;
        //}
        //public List<MostComplainsViewModel> DashMostComplainsDAL()
        //{
        //    var result = entities.DashMostComplains_G().ToList();
        //    List<MostComplainsViewModel> lstMostCompl = Mapping<List<MostComplainsViewModel>>(result);
        //    return lstMostCompl;
        //}

        public List<ComplaintDrivers_Top3_Model> Top3DAL()
        {
            var result = entities.TOP_3_ComplaintDrivers().ToList();
            List<ComplaintDrivers_Top3_Model> lst = Mapping<List<ComplaintDrivers_Top3_Model>>(result);
            return lst;
        }
        public List<RequestWorkingListModel> DetailsComplaintDriversDAL(int? SubCategoryId, int? RequestId)
        {
            var result = entities.Top_3_ComplaintDrivers_Details(SubCategoryId, RequestId).ToList();
            List<RequestWorkingListModel> detailsList = Mapping<List<RequestWorkingListModel>>(result);
            return detailsList;
        }
        public List<SLA_Top3_Model> Top3SLADAL()
        {
            var result = entities.TOP3_SLA().ToList();
            List<SLA_Top3_Model> slaList = Mapping<List<SLA_Top3_Model>>(result);
            return slaList;
        }
    }
}
