using Model.Models;
using Model.Models.Department;
using Model.Models.ListOfValue;
using Model.Models.Organization;
using Model.Models.RequestForm;
using Model.Models.UserDetail;
using Model.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.APIHelper;
using WEB.Helper;

namespace WEB.Controllers
{
    public class WarehouseController : BaseController
    {
        // GET: Warehouse
        public ActionResult Index()
        {
            return View();
        }

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

            //int CAtTypeId = (int)Model.CommonEnum.LOC.LOCId.Category;
            //List<ListOfCategoryModel> Category = WebAPIHelper.CallApi<List<ListOfCategoryModel>>(HttpMethods.Get, "GetListOfCategory", "ListOfCategory", null, CAtTypeId);
            //ViewBag.Category = new SelectList(Category, "CategoryID", "CategoryName");

            //int SubCAtTypeId = (int)Model.CommonEnum.LOC.LOCId.SubCategories;
            //List<ListOfCategoryModel> SubCategory = WebAPIHelper.CallApi<List<ListOfCategoryModel>>(HttpMethods.Get, "GetListOfCategory", "ListOfCategory", null, SubCAtTypeId);
            //ViewBag.SubCategory = new SelectList(SubCategory, "CategoryID", "CategoryName");

            int SeverityTypeId = (int)Model.CommonEnum.LOV.LOVId.Severity;
            List<ListOfValueModel> Severity = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, SeverityTypeId);
            ViewBag.Severity = new SelectList(Severity, "LOVId", "LOVName");

            int RequestStatusID = (int)Model.CommonEnum.LOV.LOVId.WorkStatus;
            List<ListOfValueModel> status = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, RequestStatusID);
            ViewBag.status = new SelectList(status, "LOVId", "LOVName");

            List<OrganizationModel> organization = WebAPIHelper.CallApi<List<OrganizationModel>>(HttpMethods.Get, "GetOrganizationId", "Organization");
            ViewBag.organization = new SelectList(organization, "OrganizationID", "OrganizationName");

            List<ListOfValueModel> WarehouseCategory = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, 45);
            ViewBag.WarehouseCategory = new SelectList(WarehouseCategory, "LOVId", "LOVName");

            List<ListOfValueModel> WarehouseStorage = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, 49);
            ViewBag.WarehouseStorage = new SelectList(WarehouseStorage, "LOVId", "LOVName");
        }
        [HttpGet]
        public ActionResult WarehouseBooking()
        {
            GetMaters();
            BookedWarehouseModel objWarehouseIds = WebAPIHelper.CallApi<BookedWarehouseModel>(HttpMethods.Get, "BookedWarehouse", "Warehouse");

            WarehouseModel model = new WarehouseModel();
            model.WarehouseId = objWarehouseIds.WarehouseIds;
            model.ReqioredTill = DateTime.Now;
            model.RequiredFrom = DateTime.Now;

            ViewBag.UnbookedWarehouseIds = objWarehouseIds.UnbookedWarehouseIds;
            return View(model);
        }

        [HttpPost]
        public ActionResult WarehouseBooking(WarehouseModel model)
        {
            GetMaters();
            if (!ModelState.IsValid)
            {
                BookedWarehouseModel objWarehouseIds = WebAPIHelper.CallApi<BookedWarehouseModel>(HttpMethods.Get, "BookedWarehouse", "Warehouse");
                model.WarehouseId = objWarehouseIds.WarehouseIds;
                ViewBag.UnbookedWarehouseIds = objWarehouseIds.UnbookedWarehouseIds;
                return View(model);
            }

            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
            }
            model.EnterpriseId = userdetail.OrganizationID;
            model.Createdby = userdetail.UDID;
            List<string> WarehouseIds = model.WarehouseId.Split(',').ToList();
            model.Map_Warehousebooking_TT = UploadFiles(WarehouseIds);
            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveWarehouseData", "Warehouse", model);
            TempData["Success"] = si.Msg;
            return RedirectToAction("WarehouseBooking");
        }

        [HttpPost]
        public DataTable UploadFiles(List<string> WarehouseIds)
        {
            RequestFormModel model = new RequestFormModel();
            WarehouseModel dataModel = new WarehouseModel();
            dataModel.Map_Warehousebooking_TT = new DataTable();
            dataModel.Map_Warehousebooking_TT.Columns.Add("WarehouseId", typeof(string));
            // Checking no of files injected in Request object  
            foreach (string data in WarehouseIds)
            {
                DataRow drData = dataModel.Map_Warehousebooking_TT.NewRow();
                drData["WarehouseId"] = data;
                dataModel.Map_Warehousebooking_TT.Rows.Add(drData);

            }
            TempData["WarehousesId"] = dataModel.Map_Warehousebooking_TT;
            return dataModel.Map_Warehousebooking_TT;
        }

        public ActionResult ViewRequests()
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            List<BookedWarehouseViewModel> model = WebAPIHelper.CallApi<List<BookedWarehouseViewModel>>(HttpMethods.Get, "GetAllPendingRequestList", "Warehouse", null);


            return View(model);
        }

        public ActionResult RequestedWarehouse(int BookingId)
        {
            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
            }
            BookedWarehouseModel objWarehouseIds = WebAPIHelper.CallApi<BookedWarehouseModel>(HttpMethods.Get, "RequestedWarehouse", "Warehouse", null, BookingId);
            WarehouseModel model = new WarehouseModel();
            model.WarehouseId = objWarehouseIds.WarehouseIds;
            model.BookingId = BookingId;
            return View(model);
        }

        [HttpPost]
        public ActionResult RequestedWarehouse(WarehouseModel model)
        {
            GetMaters();
            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
            }
            model.Createdby = userdetail.UDID;
            if (model.WarehouseId != null)
            {
                List<string> WarehouseIds = model.WarehouseId.Split(',').ToList();
                model.Map_Warehousebooking_TT = UploadFiles(WarehouseIds);
                ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "ConfirmBooking", "Warehouse", model);
                TempData["Success"] = si.Msg;
            }
            else
            {
                ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "RejectBooking", "Warehouse", model);
                TempData["Success"] = si.Msg;
            }
            return RedirectToAction("ViewRequests");
        }

        public ActionResult ConfirmBookedWarehouse()
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            List<BookedWarehouseViewModel> model = WebAPIHelper.CallApi<List<BookedWarehouseViewModel>>(HttpMethods.Get, "GetConfirmBookedWarehouseList", "Warehouse", null);


            return View(model);
        }

        public ActionResult BookedWarehouse()
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            List<BookedWarehouseViewModel> model = WebAPIHelper.CallApi<List<BookedWarehouseViewModel>>(HttpMethods.Get, "GetBookedWarehouseById", "Warehouse", null, userdetail.OrganizationID);
            return View(model);
        }

        public ActionResult RejectedWarehouse()
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            List<BookedWarehouseViewModel> model = WebAPIHelper.CallApi<List<BookedWarehouseViewModel>>(HttpMethods.Get, "GetRejectedWarehouse", "Warehouse", null);
            return View(model);
        }

        public ActionResult RejectedWarehouseByOrg()
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            List<BookedWarehouseViewModel> model = WebAPIHelper.CallApi<List<BookedWarehouseViewModel>>(HttpMethods.Get, "GetRejectedWarehouseById", "Warehouse", null, userdetail.OrganizationID);
            return View(model);
        }

        public ActionResult ViewPendingRequests()
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            List<BookedWarehouseViewModel> model = WebAPIHelper.CallApi<List<BookedWarehouseViewModel>>(HttpMethods.Get, "GetAllPendingRequestListBYId", "Warehouse", null, userdetail.OrganizationID);


            return View(model);
        }
    }
}