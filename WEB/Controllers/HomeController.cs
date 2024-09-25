using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.APIHelper;
using Model;
using System.Threading.Tasks;
using System.Net.Http;
using Utility;
using Model.Models.UserDetail;
using Model.Models;
using System.Web.UI;
using Model.Models.Home;
using Model.Models.RequestForm;
using Newtonsoft.Json;
using Model.Models.Organization;
using Model.Models.ListOfValue;
using Model.Models.Department;
using Model.Models.ListOfCategory;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection;

namespace WEB.Controllers
{
    public class HomeController : BaseController
    {


        private void GetMaters()
        {

            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;


            }
            List<OrganizationModel> org = WebAPIHelper.CallApi<List<OrganizationModel>>(HttpMethods.Get, "GetOrganization", "Organization", null, null, userId);
            ViewBag.org = new SelectList(org, "OrganizationID", "OrganizationName");

            //For Role dropdown
            //List<RoleModel> Roles = WebAPIHelper.CallApi<List<RoleModel>>(HttpMethods.Get, "GetRoleId", "Role");
            //ViewBag.Roles = new SelectList(Roles, "RoleId", "RoleName");

            //int EventTypeId = (int)Model.CommonEnum.LOV.LOVId.DepartmentType;
            //List<ListOfValueModel> department = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, EventTypeId);
            //ViewBag.department = new SelectList(department, "LOVId", "LOVName");


            List<DepartmentModel> department = WebAPIHelper.CallApi<List<DepartmentModel>>(HttpMethods.Get, "GetListDepartment", "Department");
            ViewBag.department = new SelectList(department, "DepartmentId", "DepartmentName");

            int CAtTypeId = (int)Model.CommonEnum.LOC.LOCId.Category;
            List<ListOfCategoryModel> Category = WebAPIHelper.CallApi<List<ListOfCategoryModel>>(HttpMethods.Get, "GetListOfCategory", "ListOfCategory", null, CAtTypeId);
            ViewBag.Category = new SelectList(Category, "CategoryID", "CategoryName");

            int SubCAtTypeId = (int)Model.CommonEnum.LOC.LOCId.SubCategories;
            List<ListOfCategoryModel> SubCategory = WebAPIHelper.CallApi<List<ListOfCategoryModel>>(HttpMethods.Get, "GetListOfCategory", "ListOfCategory", null, SubCAtTypeId);
            ViewBag.SubCategory = new SelectList(SubCategory, "CategoryID", "CategoryName");

            

            int SeverityTypeId = (int)Model.CommonEnum.LOV.LOVId.Severity;
            List<ListOfValueModel> Severity = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, SeverityTypeId);
            ViewBag.Severity = new SelectList(Severity, "LOVId", "LOVName");

            int RequestStatusID = (int)Model.CommonEnum.LOV.LOVId.WorkStatus;
            List<ListOfValueModel> status = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, RequestStatusID);
            ViewBag.status = new SelectList(status, "LOVId", "LOVName");

            int RequestTypeId = (int)Model.CommonEnum.LOV.LOVId.RequestType;
            List<ListOfValueModel> RequestType = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, RequestTypeId);
            ViewBag.RequestType = new SelectList(RequestType, "LOVId", "LOVName");

            List<OrganizationModel> organization = WebAPIHelper.CallApi<List<OrganizationModel>>(HttpMethods.Get, "GetOrganizationId", "Organization");
            ViewBag.organization = new SelectList(organization, "OrganizationID", "OrganizationName");

        }
        public ActionResult Index()
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
            }

            Dsb_CommonModel model = new Dsb_CommonModel();

            Dsb_RequestCountListModel Reqcount = WebAPIHelper.CallApi<Dsb_RequestCountListModel>(HttpMethods.Get, "GetRequestCount", "Home",null,null, userId);
            model.Requestcount = Reqcount;

            List<RequestListAdminModel> lstUserList = WebAPIHelper.CallApi<List<RequestListAdminModel>>(HttpMethods.Get, "GetReqAdminList", "RequestForm");
            model.RequestListAdmin = lstUserList;

            List<ComplaintDrivers_Top3_Model> top3List = WebAPIHelper.CallApi<List<ComplaintDrivers_Top3_Model>>(HttpMethods.Get, "Top3ComplaintDrivers", "Home");
            model.ComplaintDrivers = top3List;

            List<SLA_Top3_Model> slaTop3List = WebAPIHelper.CallApi<List<SLA_Top3_Model>>(HttpMethods.Get, "Top3SLA", "Home");
            model.SLA = slaTop3List;

            GetMaters();

            // Dsb_RequestCountChartModel ReqChartcount = WebAPIHelper.CallApi<Dsb_RequestCountChartModel>(HttpMethods.Get, "GetRequestChartCount", "Home", null, null, userId);
            // model.RequesChartcount = ReqChartcount;

            //dataPoints.Add(new Dsb_RequestCountChartModel("Complaint Enquiry", 25));
            //dataPoints.Add(new Dsb_RequestCountChartModel("New Enquiry", 13));
            //dataPoints.Add(new Dsb_RequestCountChartModel("Closed Enquiry", 8));
            //dataPoints.Add(new Dsb_RequestCountChartModel("In Process", 7));


            //ViewBag.DataPoint = JsonConvert.SerializeObject(dataPoints);

            return View(model);
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ServiceReport(ServiceReportModel model)
        {
            GetMaters();
            List<ServiceReport> lstUserList = WebAPIHelper.CallApi<List<ServiceReport>>(HttpMethods.Post, "ServiceReport", "Home", model);
            return View(lstUserList);
            //return Json(lstUserList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ServiceReportAJ(ServiceReportModel model)
        {
            GetMaters();
            List<ServiceReport> lstUserList = WebAPIHelper.CallApi<List<ServiceReport>>(HttpMethods.Post, "ServiceReport", "Home", model);
            return Json(lstUserList, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult ComplaintDriversAJ()
        //{
        //    GetMaters();
        //    List<ComplaintDriversViewModel> lstComplaintDrivers = WebAPIHelper.CallApi<List<ComplaintDriversViewModel>>(HttpMethods.Get, "DashComplaintDrivers", "Home");
        //    return Json(lstComplaintDrivers, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult MostComplainsAJ()
        //{
        //    GetMaters();
        //    List<MostComplainsViewModel> lstMostComplains = WebAPIHelper.CallApi<List<MostComplainsViewModel>>(HttpMethods.Get, "DashMostComplains", "Home");
        //    return Json(lstMostComplains, JsonRequestBehavior.AllowGet);
        //}
        
        public ActionResult ComplaintDriverDetails(int? SubCategoryId, int? RequestId)
        {
            if (SubCategoryId.HasValue)
            {
                //int check = SubCategoryId.Value;
                List<RequestWorkingListModel> lst = WebAPIHelper.CallApi<List<RequestWorkingListModel>>(HttpMethods.Get, "ComplaintDriversDetails", "Home", null, SubCategoryId, null);
                return View(lst);
            }
            if (RequestId.HasValue)
            {
                int check1 = RequestId.Value;
                List<RequestWorkingListModel> lst = WebAPIHelper.CallApi<List<RequestWorkingListModel>>(HttpMethods.Get, "ComplaintDriversDetails", "Home", null, null, RequestId);
                return View(lst);
            }
            return View();
        }



        //-------------------------------For Downloading AllData in XLS----------------------------------------------
        [HttpGet]
        public ActionResult ReportData()
        {
            ServiceReport model = new ServiceReport();
            List<ServiceReport> lstUserList = WebAPIHelper.CallApi<List<ServiceReport>>(HttpMethods.Post, "ServiceReport", "Home",model);
            DataTable dt = ToDataTable(lstUserList);
            DownloadXLS(dt, "ESERVICE_Report");
            return RedirectToAction("ServiceReport");
        }
        public void DownloadXLS(DataTable dt, string FileName)
        {
            var gv = new GridView();
            gv.DataSource = dt;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + FileName + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";

            //XLWorkbook wb = new XLWorkbook();
            //DataTable datata = dt;
            //wb.Worksheets.Add(dt, "Sheet1");

            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            //return RedirectToAction("EmployeeList");
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance); foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        //-------------------------------End For Downloading AllData in XLS----------------------------------------------

    }
}