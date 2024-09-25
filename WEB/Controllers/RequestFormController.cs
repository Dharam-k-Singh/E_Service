using Model.Models;
using Model.Models.Department;
using Model.Models.ListOfCategory;
using Model.Models.ListOfValue;
using Model.Models.Organization;
using Model.Models.RequestForm;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Utility;
using WEB.APIHelper;
using WEB.Helper;

namespace WEB.Controllers
{
    public class RequestFormController : BaseController
    {
        // GET: ServiceRequestForm
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

        }

        [HttpPost]
        public ActionResult GetEscalationEmailId(int DepartmentID)
        {
            //int id = DepartmentID;

            GetDepartmentEmailIdModel model = WebAPIHelper.CallApi<GetDepartmentEmailIdModel>(HttpMethods.Get, "GetEscalationEmailId", "Department", null, DepartmentID);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCategoryId(string ReportTypeID)
        {

            int reporttypeId;
            List<SelectListItem> CategoryNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(ReportTypeID))
            {
                reporttypeId = Convert.ToInt32(ReportTypeID);
                List<ListOfCategoryModel> actionid = WebAPIHelper.CallApi<List<ListOfCategoryModel>>(HttpMethods.Get, "GetListOfCategory", "ListOfCategory", null, reporttypeId);

                actionid.ForEach(x =>
                {
                    CategoryNames.Add(new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() });
                });
            }
            return Json(CategoryNames, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetSubCategoryId(string CategoryID)
        {

            int categoryid;
            List<SelectListItem> CategoryNames = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(CategoryID))
            {
                categoryid = Convert.ToInt32(CategoryID);
                List<ListOfCategoryModel> actionid = WebAPIHelper.CallApi<List<ListOfCategoryModel>>(HttpMethods.Get, "GetListOfSubCategory", "ListOfCategory", null, categoryid);

                actionid.ForEach(x =>
                {
                    CategoryNames.Add(new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() });
                });
            }
            return Json(CategoryNames, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddLFZRequest()
        {
            GetMaters();
            return View();
        }

        public ActionResult AddRequest()
        {

            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            RequestFormModel model = new RequestFormModel();
            model.EmailId = userdetail.EmailId;
            model.ContactPersonName = userdetail.EmployeeName;
            model.MobileNo = userdetail.MobileNo;
            model.dtUploads = null;
            TempData["UploadData"] = null;
            GetMaters();
            return View(model);
        }

     

        [HttpPost]
        public ActionResult SaveEPRequest(FormCollection val, RequestFormModel objMain, string Save,HttpPostedFileBase[] document)
        {
            
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                objMain.Createdby = userId;
            }
                ResponseInfo SavedId = new ResponseInfo();
            //if (Save != null)
            //{

            //objMain.Createdby = userId;
            objMain.Createdby = userId;
            GetMaters();

         
            //objMain.UploadPath = sb.ToString();
            objMain.dtUploads = (DataTable)TempData["UploadData"];

            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveRequest", "RequestForm", objMain);
            objMain.RequestId = Convert.ToInt32(si.ID);
            SavedId.ID = si.ID;
            SavedId.Msg = si.Msg;

            //}

            if (objMain.RequestId != 0)
            {
                SubmitRequest(objMain);
            }

            GetMaters();
            TempData.Remove("UploadData");

            if (objMain.RequestId == 0)
            {

                TempData["Success"] = SavedId.Msg;
                //ModelState.Clear();

                //GetMaters();
                // return View("AddLFZRequest");
                return RedirectToAction("AddRequest");
            }
            else
            {
                TempData["Success"] = SavedId.Msg;
                //ModelState.Clear();
                return RedirectToAction("EnterpriseRequestList");
            }
        }

        [HttpPost]
        public JsonResult UploadFiles()
        {
            RequestFormModel model = new RequestFormModel();
            model.dtUploads = (DataTable)TempData["UploadData"];
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                string UploadTypeId = Request.Form["UploadTypeId"];
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Replace(" ", "").Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName.Replace(" ", "");
                        }


                        if (model.dtUploads == null)
                        {
                            model.dtUploads = new DataTable();
                            model.dtUploads.Columns.Add("UploadTypeId", typeof(int));
                            model.dtUploads.Columns.Add("UploadFilename", typeof(string));
                            model.dtUploads.Columns.Add("UploadFilePath", typeof(string));
                        }
                        //else
                        //{
                        //    model.dtUploads.Columns.Add("UploadTypeId", typeof(int));
                        //    model.dtUploads.Columns.Add("UploadFilename", typeof(string));
                        //    model.dtUploads.Columns.Add("UploadFilePath", typeof(string));
                        //}

                        // Get the complete folder path and store the file inside it.  
                        ImageHelper _helper = new ImageHelper();
                        //string ImagePath = _helper.SaveImage(file);
                        string folderPath = Server.MapPath("~/Uploads/RequestUpload/");

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        var fileName = Path.GetFileNameWithoutExtension(file.FileName.Replace(" ", "")) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + Path.GetExtension(file.FileName.Replace(" ", ""));
                        file.SaveAs(Path.Combine(folderPath, fileName));
                        string ImagePath = fileName;


                        DataRow dr = model.dtUploads.NewRow();
                        dr["UploadTypeId"] = UploadTypeId;
                        dr["UploadFilename"] = fname;
                        dr["UploadFilePath"] = ImagePath;
                        model.dtUploads.Rows.Add(dr);

                        //ViewBag.fileTable = Sql.ToList<IncidentUploadsModel>(dtUpload);
                        TempData["UploadData"] = model.dtUploads;
                    }
                    // Returns message that successfully uploaded  
                    var list = Sql.ToList<RequestUploadModel>(model.dtUploads);
                   
                        ViewBag.UploadList = list;
               
                    return Json(list);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpPost]
        public JsonResult DeleteFile()
        {
            RequestFormModel model = new RequestFormModel();
            try
            {
                string filePath = Request.Form["filePath"];
                model.dtUploads = (DataTable)TempData["UploadData"];

                ImageHelper _helper = new ImageHelper();
                //string path = _helper.DeleteDoc(filePath);

                string folderPath = Server.MapPath("~/Documents/");
                var dirPath = Path.Combine(
                            folderPath, filePath);
                if (System.IO.File.Exists(dirPath))
                {
                    //Directory.Delete(dirPath, true);
                    System.IO.File.Delete(dirPath);
                }

                for (int i = 0; i < model.dtUploads.Rows.Count; i++)
                {
                    if (model.dtUploads.Rows[i]["UploadFilePath"].ToString() == filePath)
                    {
                        model.dtUploads.Rows.RemoveAt(i);
                    }
                }

                model.dtUploads.AcceptChanges();
                TempData["UploadData"] = model.dtUploads;
                var list = Sql.ToList<RequestUploadModel>(model.dtUploads);
                return Json(list);
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult removeFile(string FileID)
        {
            UserDetailModel userdetail = new UserDetailModel();
            UploadPathModel model = new UploadPathModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
            }
            model.Udid = userdetail.UDID;
            model.UploadFilePath = FileID;
            ResponseInfo data = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteFile", "RequestForm", model);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LFZReqList()
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;

            }

            GetMaters();
            List<RequestFormListModel> GetList = WebAPIHelper.CallApi<List<RequestFormListModel>>(HttpMethods.Get, "GetLFZReqList", "RequestForm", null, null, userId);

            return View(GetList);

        }

        [HttpGet]
        public ActionResult EnterpriseRequestList()
        {
            int id = 0;
            // int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                // userId = userdetail.UDID;
                id = userdetail.OrganizationID;
            }

            //int RequestStatusID = (int)Model.CommonEnum.LOV.LOVId.WorkStatus;
            //List<ListOfValueModel> status = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, RequestStatusID);
            //ViewBag.status1 = new SelectList(status, "LOVId", "LOVName");

            RequestListCommonModel model = new RequestListCommonModel();


            GetMaters();
            List<RequestFormListModel> GetList = WebAPIHelper.CallApi<List<RequestFormListModel>>(HttpMethods.Get, "GetEPReqList", "RequestForm", null, id);
            model.RequestEnterpriseList = GetList;

            return View(model);

        }

        public ActionResult SaveFeedBackRating(RequestListCommonModel objMain, string Saverating)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                objMain.SaveFeedbackRating.Createdby = userId;

            }
            ResponseInfo SavedinvoiceId = new ResponseInfo();


            if (Saverating != null)
            {

                ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveFeedBackRating", "RequestForm", objMain);


                SavedinvoiceId.ID = si.ID;
                SavedinvoiceId.Msg = si.Msg;
            }

            TempData["Success"] = SavedinvoiceId.Msg;

            ModelState.Clear();

            return RedirectToAction("EnterpriseRequestList");
        }

        public ActionResult EditRequest(int id)
        {
            //UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            TempData["UploadData"] = null;
            RequestFormModel GetUserEdit = WebAPIHelper.CallApi<RequestFormModel>(HttpMethods.Get, "GetEditRequest", "RequestForm", null, id);
            GetUserEdit.PreviewUploadPath = GetUserEdit.UploadPath;
            GetMaters();

            return View("EditRequest", GetUserEdit);
        }

        [HttpPost]
        public ActionResult UpdateRequest(RequestFormModel objMain, IEnumerable<HttpPostedFileBase> UploadPath, HttpPostedFileBase document)
        {
            int userId = 0;
            int RoleId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                objMain.Createdby = userId;
                RoleId = userdetail.RoleId;
            }
            ResponseInfo SavedId = new ResponseInfo();
            objMain.Createdby = userId;
            GetMaters();
            //string FileName = "";
            //String FilePath = ConfigurationManager.AppSettings["RequesUploadPath"];
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append(objMain.PreviewUploadPath);
            //if (UploadPath != null)
            //{
            //    foreach (var file in UploadPath)
            //    {
            //        if (file != null && file.ContentLength > 0)
            //        {
            //            FileName = Path.GetFileName(file.FileName);
            //            FileName = System.IO.Path.GetFileName(file.FileName).ToString();
            //            string _path = Path.Combine(FilePath, FileName);
            //            file.SaveAs(Server.MapPath(_path));
            //            objMain.UploadPath = FileName;

            //            if (sb.Length > 0)
            //            {
            //                sb.Append(",");
            //            }
            //            // in its first pass it will take the first string , then others string: because this line must execute  
            //            sb.Append(FileName);
            //        }
            //    }

            objMain.dtUploads = (DataTable)TempData["UploadData"];
            //}
            ////objMain.UploadPath = sb.ToString();
            //objMain.dtUploads = (DataTable)TempData["UploadData"];
            //if (document != null && document.ContentLength > (1024 * 2))
            //{
            //    string fileName = Path.GetFileName(document.FileName);

            //    fileName = FileUtils.GetNewFileName(fileName);

            //    string path = Path.Combine(Server.MapPath("~/Uploads/RequestUpload/"), fileName);

            //    document.SaveAs(path);

            //    objMain.UploadPath = "/Uploads/RequestUpload/" + fileName;
            //}

            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveRequest", "RequestForm", objMain);
            objMain.RequestId = Convert.ToInt32(si.ID);
            SavedId.ID = si.ID;
            SavedId.Msg = si.Msg;
            //}

            if (objMain.RequestId != 0)
            {
                UpdateRequest(objMain);
            }

            GetMaters();
            TempData["Success"] = si.Msg;
            //ModelState.Clear();
            if (RoleId == 3)
            {
                return RedirectToAction("LFZReqList", "RequestForm");
            }
            else
            {
                return RedirectToAction("EnterpriseRequestList", "RequestForm");
            }
        }

        //[HttpPost]
        //public ActionResult UpdateRequest(RequestFormModel objMain, IEnumerable<HttpPostedFileBase> UploadPath)
        //{
        //    int userId = 0;
        //    int RoleId = 0;
        //    if (Session != null)
        //    {
        //        UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
        //        userId = userdetail.UDID;
        //        objMain.Createdby = userId;
        //        RoleId = userdetail.RoleId;

        //    }
        //    ResponseInfo SavedId = new ResponseInfo();

        //    objMain.Createdby = userId;
        //    GetMaters();



        //    string FileName = "";
        //    String FilePath = ConfigurationManager.AppSettings["RequesUploadPath"];
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    sb.Append(objMain.PreviewUploadPath);
        //    if (UploadPath != null)
        //    {
        //        foreach (var file in UploadPath)
        //        {

        //            if (file != null && file.ContentLength > 0)
        //            {


        //                FileName = Path.GetFileName(file.FileName);
        //                FileName = System.IO.Path.GetFileName(file.FileName).ToString();
        //                string _path = Path.Combine(FilePath, FileName);
        //                file.SaveAs(Server.MapPath(_path));
        //                objMain.UploadPath = FileName;

        //                if (sb.Length > 0)
        //                {
        //                    sb.Append(",");
        //                }

        //                // in its first pass it will take the first string , then others string: because this line must execute  

        //                sb.Append(FileName);
        //            }
        //        }


        //    }
        //    objMain.UploadPath = sb.ToString();

        //    ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveRequest", "RequestForm", objMain);


        //    objMain.RequestId = Convert.ToInt32(si.ID);
        //    SavedId.ID = si.ID;
        //    SavedId.Msg = si.Msg;

        //    //}

        //    GetMaters();
        //    TempData["Success"] = si.Msg;
        //    //ModelState.Clear();
        //    if (RoleId == 3)
        //    {
        //        return RedirectToAction("LFZReqList", "RequestForm");
        //    }
        //    else
        //    {
        //        return RedirectToAction("EnterpriseRequestList", "RequestForm");
        //    }
        //}


        //    if (objMain.RequestId != 0)
        //        {
        //            UpdateRequest(objMain);
        //}

        public ActionResult LFZReqDelete(int id)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
            }
            //UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            var rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteRequest", "RequestForm", null, id, userId);

            TempData["Success"] = rs.Msg;

            return RedirectToAction("LFZReqList");
        }

        public ActionResult Delete(int id)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;

            }
            //UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            var rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteRequest", "RequestForm", null, id, userId);

            TempData["Success"] = rs.Msg;

            return RedirectToAction("EnterpriseRequestList");
        }


        [HttpGet]
        public ActionResult RequestAdminList()
        {
            //int id = 0;
            // int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //     userId = userdetail.UDID;
            //   // id = userdetail.OrganizationID;
            //}

            RequestAdminListCommonModel model = new RequestAdminListCommonModel();

            GetMaters();
            List<RequestListAdminModel> lstUserList = WebAPIHelper.CallApi<List<RequestListAdminModel>>(HttpMethods.Get, "GetReqAdminList", "RequestForm");
            model.RequestListAdmin = lstUserList;

            return View(model);

        }

        [HttpGet]
        public ActionResult RequestAdminWorkingList()
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;

            }

            RequestAdminListCommonModel model = new RequestAdminListCommonModel();

            GetMaters();
            List<RequestWorkingListModel> lstList = WebAPIHelper.CallApi<List<RequestWorkingListModel>>(HttpMethods.Get, "GetReqWorkingList", "RequestForm", null, null, userId);
            model.RequestWorkingList = lstList;
            return View(model);

        }

        [HttpGet]
        public ActionResult RequestHistoryDetails(int id)
        {

            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;

            //}

            RequestAdminListCommonModel model = new RequestAdminListCommonModel();

            GetMaters();
            List<RequestHistoryListModel> lstList = WebAPIHelper.CallApi<List<RequestHistoryListModel>>(HttpMethods.Get, "GetReqHistoryDetails", "RequestForm", null, id);
            model.RequestHistoryList = lstList;

            return View(model);

        }

        public ActionResult SaveActionDetails(RequestAdminListCommonModel objMain, IEnumerable<HttpPostedFileBase> UploadPath, string SaveAction)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                objMain.RequestSaveActionAdmin.Createdby = userId;

            }
            ResponseInfo SavedinvoiceId = new ResponseInfo();


            if (SaveAction != null)
            {

                string FileName = "";
                String FilePath = ConfigurationManager.AppSettings["AllocateActionUploadPath"];
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (UploadPath != null)
                {
                    foreach (var file in UploadPath)
                    {

                        if (file != null && file.ContentLength > 0)
                        {


                            FileName = Path.GetFileName(file.FileName);
                            FileName = System.IO.Path.GetFileName(file.FileName).ToString();
                            string _path = Path.Combine(FilePath, FileName);
                            file.SaveAs(Server.MapPath(_path));
                            objMain.RequestSaveActionAdmin.UploadPath = FileName;

                            if (sb.Length > 0)
                            {
                                sb.Append(",");
                            }

                            // in its first pass it will take the first string , then others string: because this line must execute  

                            sb.Append(FileName);
                        }
                    }
                }
                objMain.RequestSaveActionAdmin.UploadPath = sb.ToString();

                ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveActionDetails", "RequestForm", objMain);
                SavedinvoiceId.ID = si.ID;
                SavedinvoiceId.Msg = si.Msg;

            }

            if (objMain != null)
            {
                SubmitAllocationRequest(objMain);
            }

            TempData["Success"] = SavedinvoiceId.Msg;

            ModelState.Clear();

            return RedirectToAction("RequestAdminList");
        }



        public ActionResult MyTicketList()
        {
            int id = 0;
            // int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                // userId = userdetail.UDID;
                id = userdetail.UDID;
            }

            TicketListCommonModel model = new TicketListCommonModel();

            GetMaters();
            List<TicketListModel> lstUserList = WebAPIHelper.CallApi<List<TicketListModel>>(HttpMethods.Get, "GetMyTicketList", "RequestForm", null, id);
            model.MyTicketList = lstUserList;

            //List<TicketListModel> GetList = WebAPIHelper.CallApi<List<TicketListModel>>(HttpMethods.Get, "GetMyTicketList", "RequestForm", null, id);

            return View(model);
        }

        public ActionResult ChangeTicketStatus(TicketListCommonModel objMain, IEnumerable<HttpPostedFileBase> UploadPath, string Savestatus)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                objMain.ChangeTicketStatus.Createdby = userId;
            }
            ResponseInfo SavedinvoiceId = new ResponseInfo();

            if (Savestatus != null)
            {
                string FileName = "";
                String FilePath = ConfigurationManager.AppSettings["DepartmentUserActionUploadPath"];
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (UploadPath != null)
                {
                    foreach (var file in UploadPath)
                    {

                        if (file != null && file.ContentLength > 0)
                        {


                            FileName = Path.GetFileName(file.FileName);
                            FileName = System.IO.Path.GetFileName(file.FileName).ToString();
                            string _path = Path.Combine(FilePath, FileName);
                            file.SaveAs(Server.MapPath(_path));
                            objMain.ChangeTicketStatus.UploadPath = FileName;

                            if (sb.Length > 0)
                            {
                                sb.Append(",");
                            }

                            // in its first pass it will take the first string , then others string: because this line must execute  

                            sb.Append(FileName);
                        }
                    }


                }
                objMain.ChangeTicketStatus.UploadPath = sb.ToString();



                ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveChangeTicketStatus", "RequestForm", objMain);


                SavedinvoiceId.ID = si.ID;
                SavedinvoiceId.Msg = si.Msg;
            }

            //if (objMain != null)
            //{
            //    DepartmentUserChangeStatusTicket(objMain);
            //}

            TempData["Success"] = SavedinvoiceId.Msg;

            ModelState.Clear();

            return RedirectToAction("MyTicketList");
        }

        public ActionResult DepartmentTickets()
        {

            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;

            }
            TicketListCommonModel model = new TicketListCommonModel();

            GetMaters();
            List<TicketListModel> GetList = WebAPIHelper.CallApi<List<TicketListModel>>(HttpMethods.Get, "GetDepartmentTicketList", "RequestForm", null, null, userId);
            model.MyTicketList = GetList;

            return View(model);
        }

        public ActionResult AllocateRequest(int id)
        {
            // int id = 0;
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                // userId = userdetail.UDID;
                userId = userdetail.UDID;
            }

            GetMaters();

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveAllocateRequest", "RequestForm", null, id, userId);

            AllocateToTeamModel objModel = new AllocateToTeamModel();
            objModel.AllocationID = id;
            if (objModel != null)
            {
                DepartmentSelfAssignTicket(objModel);
            }

            TempData["Success"] = rs.Msg;

            return RedirectToAction("DepartmentTickets");
        }

        public ActionResult AssignDepartmentTickets()
        {
            //int id = 0;
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                // id = userdetail.DepartmentID;
            }
            ModelState.Clear();

            List<DepartmentModel> dep = WebAPIHelper.CallApi<List<DepartmentModel>>(HttpMethods.Get, "GetListDepartmentMapped", "Department", null, null, userId);
            ViewBag.MappedDep = new SelectList(dep, "DepartmentId", "DepartmentName");

            TicketListCommonModel model = new TicketListCommonModel();

            List<TicketListModel> GetList = WebAPIHelper.CallApi<List<TicketListModel>>(HttpMethods.Get, "GetDepartmentTicketList", "RequestForm", null, null, userId);
            model.MyTicketList = GetList;

            // Session["DepartmentID"] = id;

            //GetMaters1(id);

            //model = GetDetail(id);


            return View(model);
        }

        public JsonResult GetDetail(int DepartmentID)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;


            }
            //Dropdown For Survey dropdown

            //List<DepartmentModel> dep = WebAPIHelper.CallApi<List<DepartmentModel>>(HttpMethods.Get, "GetListDepartmentMapped", "Department", null, null, userId);
            //ViewBag.Departement = new SelectList(dep, "DepartmentId", "DepartmentName");

            //ViewBag.LFZusers = null;

            List<GetUserDetailModel> LFZuser = WebAPIHelper.CallApi<List<GetUserDetailModel>>(HttpMethods.Get, "GetDepartmentUserList", "UsersDetail", null, DepartmentID, userId);
            ViewBag.LFZusers = new SelectList(LFZuser, "UDID", "EmployeeName");

            List<TicketListModel> lstModel = WebAPIHelper.CallApi<List<TicketListModel>>(HttpMethods.Get, "GetHODDepTicketList", "RequestForm", null, DepartmentID);

            GetMaters1(DepartmentID);
            DepartmentTicketUserlistModel objdep = new DepartmentTicketUserlistModel();
            objdep.lstDep = LFZuser;
            objdep.lstUser = lstModel;


            return Json(objdep, JsonRequestBehavior.AllowGet);
        }

        private void GetMaters1(int DepartmentID)
        {

            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;


            }
            //Dropdown For Survey dropdown

            //List<DepartmentModel> dep = WebAPIHelper.CallApi<List<DepartmentModel>>(HttpMethods.Get, "GetListDepartmentMapped", "Department", null, null, userId);
            //ViewBag.Departement = new SelectList(dep, "DepartmentId", "DepartmentName");

            ViewBag.LFZusers = null;

            List<GetUserDetailModel> LFZuser = WebAPIHelper.CallApi<List<GetUserDetailModel>>(HttpMethods.Get, "GetDepartmentUserList", "UsersDetail", null, DepartmentID, userId);
            ViewBag.LFZusers = new SelectList(LFZuser, "UDID", "EmployeeName");
        }

        [HttpPost]
        public ActionResult AllocateToTeam(int LFZMembers, int AllocationID)
        {

            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
            }
            AllocateToTeamModel objModel = new AllocateToTeamModel();
            objModel.AllocationID = AllocationID;
            objModel.LFZTeamMembers = LFZMembers;
            objModel.CreatedBy = userdetail.UDID;

            ResponseInfo SavedId = new ResponseInfo();

            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveAllocateToTeam", "RequestForm", objModel);

            //if (objModel != null)
            //{
            //    HODRequestAssignToDepartmentUser(objModel);
            //}
            //TempData["Success"] = si.Msg;

            return Json("Status Change Sucessfully.", JsonRequestBehavior.AllowGet);

            //return 

        }

        public ActionResult ReopenRequest(RequestListCommonModel objMain, string Savestatus)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                objMain.ReOpenTicketStatus.Createdby = userId;

            }
            ResponseInfo SavedRequestId = new ResponseInfo();


            if (Savestatus != null)
            {

                ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveReopenRequest", "RequestForm", objMain);


                SavedRequestId.ID = si.ID;
                SavedRequestId.Msg = si.Msg;
            }


            if (objMain != null)
            {
                ReopenRequestMail(objMain);
            }

            TempData["Success"] = SavedRequestId.Msg;

            ModelState.Clear();

            return RedirectToAction("EnterpriseRequestList");
        }

        //----------------------------------------------------------Email Notification part-------------------------------------------

        public void SubmitRequest(RequestFormModel objMain)
        {
            // DataTable Dtrecord = GetEmailData(objAddInci.InvoiceItemID ,objAddInci.StatusID);
            DataTable Dtrecord = GetEmailData(objMain.RequestId);
            string RequestId = "";
            string RequestNo = "";
            string Topic = "";
            string Enterprise = "";
            string Category = "";
            string SubCategory = "";
            string ContactPersonName = "";
            string MobileNo = "";
            string EmailId = "";
            string Severity = "";
            string RequestDescription = "";
            string AllocatorsEmailId = "";

            if (Dtrecord.Rows.Count > 0)
            {
                RequestId = Dtrecord.Rows[0]["RequestId"].ToString();
                RequestNo = Dtrecord.Rows[0]["RequestNo"].ToString();
                Topic = Dtrecord.Rows[0]["Topic"].ToString();
                Enterprise = Dtrecord.Rows[0]["Enterprise"].ToString();
                Category = Dtrecord.Rows[0]["Category"].ToString();
                SubCategory = Dtrecord.Rows[0]["SubCategory"].ToString();
                ContactPersonName = Dtrecord.Rows[0]["ContactPersonName"].ToString();
                MobileNo = Dtrecord.Rows[0]["MobileNo"].ToString();
                EmailId = Dtrecord.Rows[0]["EmailId"].ToString();
                Severity = Dtrecord.Rows[0]["Severity"].ToString();
                RequestDescription = Dtrecord.Rows[0]["RequestDescription"].ToString();
                AllocatorsEmailId = Dtrecord.Rows[0]["AllocatorsEmailId"].ToString();

                //if (Dtrecord.Rows[0]["EmailId"].ToString() != " ")
                //    Emailids += Dtrecord.Rows[0]["EmailId"].ToString();
            }

            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //Send mail using email template 


            string subject = "Service Request Raised by " + userdetail.EmployeeName;

            string EmailHTML = string.Empty;
            string EmailTemplatePath = ConfigurationManager.AppSettings["SubmitRequest"];
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(EmailTemplatePath)))
            {
                EmailHTML = reader.ReadToEnd();
            }

            EmailHTML = EmailHTML.Replace("#?RequestId?#", RequestId);
            EmailHTML = EmailHTML.Replace("#?RequestNo?#", RequestNo);
            EmailHTML = EmailHTML.Replace("#?Topic?#", Topic);
            EmailHTML = EmailHTML.Replace("#?Enterprise?#", Enterprise);
            EmailHTML = EmailHTML.Replace("#?Category?#", Category);
            EmailHTML = EmailHTML.Replace("#?SubCategory?#", SubCategory);
            EmailHTML = EmailHTML.Replace("#?ContactPersonName?#", ContactPersonName);
            EmailHTML = EmailHTML.Replace("#?MobileNo?#", MobileNo);
            EmailHTML = EmailHTML.Replace("#?EmailId?#", EmailId);
            EmailHTML = EmailHTML.Replace("#?Severity?#", Severity);
            EmailHTML = EmailHTML.Replace("#?RequestDescription?#", RequestDescription);

            //Code to send Mail to User
            bool mailresp = Email.SendMail(AllocatorsEmailId, subject, EmailHTML);

        }

        public void UpdateRequest(RequestFormModel objMain)
        {
            // DataTable Dtrecord = GetEmailData(objAddInci.InvoiceItemID ,objAddInci.StatusID);
            DataTable Dtrecord = GetEmailData(objMain.RequestId);
            string RequestId = "";
            string RequestNo = "";
            string Topic = "";
            string Enterprise = "";
            string Category = "";
            string SubCategory = "";
            string ContactPersonName = "";
            string MobileNo = "";
            string EmailId = "";
            string Severity = "";
            string RequestDescription = "";
            string AllocatorsEmailId = "";
            string TicketAllocatedToEmailId = "";

            if (Dtrecord.Rows.Count > 0)
            {
                RequestId = Dtrecord.Rows[0]["RequestId"].ToString();
                RequestNo = Dtrecord.Rows[0]["RequestNo"].ToString();
                Topic = Dtrecord.Rows[0]["Topic"].ToString();
                Enterprise = Dtrecord.Rows[0]["Enterprise"].ToString();
                Category = Dtrecord.Rows[0]["Category"].ToString();
                SubCategory = Dtrecord.Rows[0]["SubCategory"].ToString();
                ContactPersonName = Dtrecord.Rows[0]["ContactPersonName"].ToString();
                MobileNo = Dtrecord.Rows[0]["MobileNo"].ToString();
                EmailId = Dtrecord.Rows[0]["EmailId"].ToString();
                Severity = Dtrecord.Rows[0]["Severity"].ToString();
                RequestDescription = Dtrecord.Rows[0]["RequestDescription"].ToString();
                AllocatorsEmailId = Dtrecord.Rows[0]["AllocatorsEmailId"].ToString();
                TicketAllocatedToEmailId = Dtrecord.Rows[0]["TicketAllocatedToEmailId"].ToString();

                //if (Dtrecord.Rows[0]["EmailId"].ToString() != " ")
                //    Emailids += Dtrecord.Rows[0]["EmailId"].ToString();
            }

            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //Send mail using email template 


            string subject = "Raised Request is Updated by " + userdetail.EmployeeName;

            string EmailHTML = string.Empty;
            string EmailTemplatePath = ConfigurationManager.AppSettings["UpdateRequest"];
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(EmailTemplatePath)))
            {
                EmailHTML = reader.ReadToEnd();
            }

            EmailHTML = EmailHTML.Replace("#?RequestId?#", RequestId);
            EmailHTML = EmailHTML.Replace("#?RequestNo?#", RequestNo);
            EmailHTML = EmailHTML.Replace("#?Topic?#", Topic);
            EmailHTML = EmailHTML.Replace("#?Enterprise?#", Enterprise);
            EmailHTML = EmailHTML.Replace("#?Category?#", Category);
            EmailHTML = EmailHTML.Replace("#?SubCategory?#", SubCategory);
            EmailHTML = EmailHTML.Replace("#?ContactPersonName?#", ContactPersonName);
            EmailHTML = EmailHTML.Replace("#?MobileNo?#", MobileNo);
            EmailHTML = EmailHTML.Replace("#?EmailId?#", EmailId);
            EmailHTML = EmailHTML.Replace("#?Severity?#", Severity);
            EmailHTML = EmailHTML.Replace("#?RequestDescription?#", RequestDescription);

            //Code to send Mail to User
            bool mailresp = Email.SendMail(TicketAllocatedToEmailId, subject, EmailHTML, AllocatorsEmailId);

        }


        public DataTable GetEmailData(int RequestId)
        {

            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;
            //    //objExe.InvoiceStatuschange.CreatedBy = userId;

            //}

            List<SqlParameter> parameters1 = new List<SqlParameter>();

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@InvoiceItemID",
            //    SqlDbType = SqlDbType.Int,
            //    Value = id,
            //    Direction = System.Data.ParameterDirection.Input
            //});
            parameters1.Add(new SqlParameter()
            {
                ParameterName = "@RequestId",
                SqlDbType = SqlDbType.Int,
                Value = RequestId,
                Direction = System.Data.ParameterDirection.Input
            });
            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@RoleId",
            //    SqlDbType = SqlDbType.Int,
            //    Value = RoleId,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@Flag",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 1,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            DataSet dataSet2 = DAL.SqlManager.ExecuteDataSet("Request_Email_Enterprise_G", parameters1.ToArray());
            DataTable datatable = dataSet2.Tables[0];


            return datatable;

        }


        public void SubmitAllocationRequest(RequestAdminListCommonModel objMain)
        {
            // DataTable Dtrecord = GetEmailData(objAddInci.InvoiceItemID ,objAddInci.StatusID);
            DataTable Dtrecord = GetEmailData1(objMain.RequestSaveActionAdmin.RequestId);
            string RequestId = "";
            string RequestNo = "";
            string Enterprise = "";
            string Category = "";
            string SubCategory = "";
            string RequestStatus = "";
            string Priority = "";
            string Commitementdate = "";
            string EscalateOndate = "";
            string EscLevel1EmailId = "";
            string RequestComments = "";
            string DepartmentName = "";
            string DepartmentEmailId = "";
            string AllocatorsEmailId = "";

            if (Dtrecord.Rows.Count > 0)
            {
                RequestId = Dtrecord.Rows[0]["RequestId"].ToString();
                RequestNo = Dtrecord.Rows[0]["RequestNo"].ToString();
                Enterprise = Dtrecord.Rows[0]["Enterprise"].ToString();
                Category = Dtrecord.Rows[0]["Category"].ToString();
                SubCategory = Dtrecord.Rows[0]["SubCategory"].ToString();
                RequestStatus = Dtrecord.Rows[0]["RequestStatus"].ToString();
                Priority = Dtrecord.Rows[0]["Priority"].ToString();
                Commitementdate = Dtrecord.Rows[0]["Commitementdate"].ToString();
                EscalateOndate = Dtrecord.Rows[0]["EscalateOndate"].ToString();
                EscLevel1EmailId = Dtrecord.Rows[0]["EscLevel1EmailId"].ToString();
                RequestComments = Dtrecord.Rows[0]["RequestComments"].ToString();
                DepartmentName = Dtrecord.Rows[0]["DepartmentName"].ToString();
                DepartmentEmailId = Dtrecord.Rows[0]["DepartmentEmailId"].ToString();
                AllocatorsEmailId = Dtrecord.Rows[0]["AllocatorsEmailId"].ToString();
                //if (Dtrecord.Rows[0]["EmailId"].ToString() != " ")
                //    Emailids += Dtrecord.Rows[0]["EmailId"].ToString();
            }

            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //Send mail using email template 

            string subject = "New Ticket is Allocated By " + userdetail.EmployeeName;

            string EmailHTML = string.Empty;
            string EmailTemplatePath = ConfigurationManager.AppSettings["SubmitAllocationToDepartment"];
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(EmailTemplatePath)))
            {
                EmailHTML = reader.ReadToEnd();
            }

            EmailHTML = EmailHTML.Replace("#?RequestId?#", RequestId);
            EmailHTML = EmailHTML.Replace("#?RequestNo?#", RequestNo);
            EmailHTML = EmailHTML.Replace("#?Enterprise?#", Enterprise);
            EmailHTML = EmailHTML.Replace("#?Category?#", Category);
            EmailHTML = EmailHTML.Replace("#?SubCategory?#", SubCategory);
            EmailHTML = EmailHTML.Replace("#?RequestStatus?#", RequestStatus);
            EmailHTML = EmailHTML.Replace("#?Priority?#", Priority);
            EmailHTML = EmailHTML.Replace("#?Commitementdate?#", Commitementdate);
            EmailHTML = EmailHTML.Replace("#?EscalateOndate?#", EscalateOndate);
            EmailHTML = EmailHTML.Replace("#?EscLevel1EmailId?#", EscLevel1EmailId);
            EmailHTML = EmailHTML.Replace("#?RequestComments?#", RequestComments);
            EmailHTML = EmailHTML.Replace("#?DepartmentName?#", DepartmentName);
            EmailHTML = EmailHTML.Replace("#?AllocatorsEmailId?#",AllocatorsEmailId);
            //Code to send Mail to User
            bool mailresp = Email.SendMail(DepartmentEmailId, subject, EmailHTML,AllocatorsEmailId);

        }

        public DataTable GetEmailData1(int RequestId)
        {

            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;
            //    //objExe.InvoiceStatuschange.CreatedBy = userId;

            //}

            List<SqlParameter> parameters1 = new List<SqlParameter>();

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@InvoiceItemID",
            //    SqlDbType = SqlDbType.Int,
            //    Value = id,
            //    Direction = System.Data.ParameterDirection.Input
            //});
            parameters1.Add(new SqlParameter()
            {
                ParameterName = "@RequestId",
                SqlDbType = SqlDbType.Int,
                Value = RequestId,
                Direction = System.Data.ParameterDirection.Input
            });
            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@RoleId",
            //    SqlDbType = SqlDbType.Int,
            //    Value = RoleId,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@Flag",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 1,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            DataSet dataSet2 = DAL.SqlManager.ExecuteDataSet("Request_Email_AdminAllocation_G", parameters1.ToArray());
            DataTable datatable = dataSet2.Tables[0];


            return datatable;

        }

        public void HODRequestAssignToDepartmentUser(AllocateToTeamModel objModel)
        {
            // DataTable Dtrecord = GetEmailData(objAddInci.InvoiceItemID ,objAddInci.StatusID);
            DataTable Dtrecord = GetEmailData2(objModel.AllocationID);
            string RequestId = "";
            string RequestNo = "";
            string Enterprise = "";
            string Category = "";
            string SubCategory = "";
            string RequestStatus = "";
            string Priority = "";
            string Commitementdate = "";
            string EscalateOndate = "";
            string RequestComments = "";
            string AllocatedToEmailId = "";


            if (Dtrecord.Rows.Count > 0)
            {
                RequestId = Dtrecord.Rows[0]["RequestId"].ToString();
                RequestNo = Dtrecord.Rows[0]["RequestNo"].ToString();
                Enterprise = Dtrecord.Rows[0]["Enterprise"].ToString();
                Category = Dtrecord.Rows[0]["Category"].ToString();
                SubCategory = Dtrecord.Rows[0]["SubCategory"].ToString();
                RequestStatus = Dtrecord.Rows[0]["RequestStatus"].ToString();
                Priority = Dtrecord.Rows[0]["Priority"].ToString();
                Commitementdate = Dtrecord.Rows[0]["Commitementdate"].ToString();
                EscalateOndate = Dtrecord.Rows[0]["EscalateOndate"].ToString();
                RequestComments = Dtrecord.Rows[0]["RequestComments"].ToString();
                AllocatedToEmailId = Dtrecord.Rows[0]["AllocatedToEmailId"].ToString();

                //if (Dtrecord.Rows[0]["EmailId"].ToString() != " ")
                //    Emailids += Dtrecord.Rows[0]["EmailId"].ToString();
            }

            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //Send mail using email template 

            string subject = "New Ticket is Assigned To You By " + userdetail.EmployeeName;

            string EmailHTML = string.Empty;
            string EmailTemplatePath = ConfigurationManager.AppSettings["HODRequestAssignToDepartmentUser"];
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(EmailTemplatePath)))
            {
                EmailHTML = reader.ReadToEnd();
            }

            EmailHTML = EmailHTML.Replace("#?RequestId?#", RequestId);
            EmailHTML = EmailHTML.Replace("#?RequestNo?#", RequestNo);
            EmailHTML = EmailHTML.Replace("#?Enterprise?#", Enterprise);
            EmailHTML = EmailHTML.Replace("#?Category?#", Category);
            EmailHTML = EmailHTML.Replace("#?SubCategory?#", SubCategory);
            EmailHTML = EmailHTML.Replace("#?RequestStatus?#", RequestStatus);
            EmailHTML = EmailHTML.Replace("#?Priority?#", Priority);
            EmailHTML = EmailHTML.Replace("#?Commitementdate?#", Commitementdate);
            EmailHTML = EmailHTML.Replace("#?EscalateOndate?#", EscalateOndate);
            EmailHTML = EmailHTML.Replace("#?RequestComments?#", RequestComments);


            //Code to send Mail to User
            bool mailresp = Email.SendMail(AllocatedToEmailId, subject, EmailHTML);

        }

        public DataTable GetEmailData2(int AllocationID)
        {

            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;
            //    //objExe.InvoiceStatuschange.CreatedBy = userId;

            //}

            List<SqlParameter> parameters1 = new List<SqlParameter>();

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@InvoiceItemID",
            //    SqlDbType = SqlDbType.Int,
            //    Value = id,
            //    Direction = System.Data.ParameterDirection.Input
            //});
            parameters1.Add(new SqlParameter()
            {
                ParameterName = "@AllocationID",
                SqlDbType = SqlDbType.Int,
                Value = AllocationID,
                Direction = System.Data.ParameterDirection.Input
            });
            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@RoleId",
            //    SqlDbType = SqlDbType.Int,
            //    Value = RoleId,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@Flag",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 1,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            DataSet dataSet2 = DAL.SqlManager.ExecuteDataSet("Request_Email_HODTicketAssign_G", parameters1.ToArray());
            DataTable datatable = dataSet2.Tables[0];


            return datatable;

        }

        public void DepartmentSelfAssignTicket(AllocateToTeamModel objModel)
        {
            // DataTable Dtrecord = GetEmailData(objAddInci.InvoiceItemID ,objAddInci.StatusID);
            DataTable Dtrecord = GetEmailData2(objModel.AllocationID);
            string RequestId = "";
            string RequestNo = "";
            string TicketAllocatedDate = "";
            string AllocatorsEmailId = "";


            if (Dtrecord.Rows.Count > 0)
            {
                RequestId = Dtrecord.Rows[0]["RequestId"].ToString();
                RequestNo = Dtrecord.Rows[0]["RequestNo"].ToString();
                TicketAllocatedDate = Dtrecord.Rows[0]["TicketAllocatedDate"].ToString();

                AllocatorsEmailId = Dtrecord.Rows[0]["AllocatorsEmailId"].ToString();


            }

            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //Send mail using email template 

            string subject = "Ticket is Assigned By " + userdetail.EmployeeName;

            string EmailHTML = string.Empty;
            string EmailTemplatePath = ConfigurationManager.AppSettings["DepartmentSelfAssignTicket"];
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(EmailTemplatePath)))
            {
                EmailHTML = reader.ReadToEnd();
            }

            EmailHTML = EmailHTML.Replace("#?RequestId?#", RequestId);
            EmailHTML = EmailHTML.Replace("#?RequestNo?#", RequestNo);
            EmailHTML = EmailHTML.Replace("#?AllocatedBy?#", userdetail.EmployeeName);
            EmailHTML = EmailHTML.Replace("#?TicketAllocatedDate?#", TicketAllocatedDate);

            //Code to send Mail to User
            bool mailresp = Email.SendMail(AllocatorsEmailId, subject, EmailHTML);

        }

        public void DepartmentUserChangeStatusTicket(TicketListCommonModel objMain)
        {
            // DataTable Dtrecord = GetEmailData(objAddInci.InvoiceItemID ,objAddInci.StatusID);
            DataTable Dtrecord = GetEmailData3(objMain.ChangeTicketStatus.AllocationID);

            string RequestId = "";
            string RequestNo = "";
            string RequestStatus = "";
            string EmailId = "";
            string AllocatorsEmailId = "";
            string RequestComments = "";
            // string RequestStatusID = "";
            // string EnterpriseEmailId = "";
            // string TicketAllocatedToEmailId = "";


            if (Dtrecord.Rows.Count > 0)
            {
                RequestId = Dtrecord.Rows[0]["RequestId"].ToString();
                RequestNo = Dtrecord.Rows[0]["RequestNo"].ToString();
                RequestStatus = Dtrecord.Rows[0]["RequestStatus"].ToString();
                EmailId = Dtrecord.Rows[0]["EmailId"].ToString();
                RequestStatus = Dtrecord.Rows[0]["RequestStatus"].ToString();
                RequestComments = Dtrecord.Rows[0]["RequestComments"].ToString();
                AllocatorsEmailId = Dtrecord.Rows[0]["AllocatorsEmailId"].ToString();
                //  RequestStatusID = Dtrecord.Rows[0]["RequestStatusID"].ToString();
                // EnterpriseEmailId = Dtrecord.Rows[0]["EnterpriseEmailId"].ToString();
                // TicketAllocatedToEmailId = Dtrecord.Rows[0]["TicketAllocatedToEmailId"].ToString();

                //if (Dtrecord.Rows[0]["EmailId"].ToString() != " ")
                //    Emailids += Dtrecord.Rows[0]["EmailId"].ToString();
            }

            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //Send mail using email template 
            //if (RequestStatusID == "28")
            //{
            //    string subject = "Ticket Status Updated";

            //    string EmailHTML = string.Empty;
            //    string EmailTemplatePath = ConfigurationManager.AppSettings["DepartmentUserChangeStatusTicket"];
            //    using (StreamReader reader = new StreamReader( EmailTemplatePath)))
            //    {
            //        EmailHTML = reader.ReadToEnd();
            //    }

            //    EmailHTML = EmailHTML.Replace("#?RequestId?#", RequestId);
            //    EmailHTML = EmailHTML.Replace("#?RequestNo?#", RequestNo);
            //    EmailHTML = EmailHTML.Replace("#?RequestStatus?#", RequestStatus);
            //    EmailHTML = EmailHTML.Replace("#?RequestComments?#", RequestComments);

            //    //Code to send Mail to User
            //    bool mailresp = Email.SendMail(EnterpriseEmailId, subject, EmailHTML, TicketAllocatedToEmailId,AllocatorsEmailId);
            //}
            //else
            //{
            string subject = "Ticket Status Updated ";

            string EmailHTML = string.Empty;
            string EmailTemplatePath = ConfigurationManager.AppSettings["DepartmentUserChangeStatusTicket"];
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(EmailTemplatePath)))
            {
                EmailHTML = reader.ReadToEnd();
            }

            EmailHTML = EmailHTML.Replace("#?RequestId?#", RequestId);
            EmailHTML = EmailHTML.Replace("#?RequestNo?#", RequestNo);
            EmailHTML = EmailHTML.Replace("#?RequestStatus?#", RequestStatus);
            EmailHTML = EmailHTML.Replace("#?RequestComments?#", RequestComments);

            //Code to send Mail to User
            bool mailresp = Email.SendMail(EmailId, subject, EmailHTML, AllocatorsEmailId);
            //}
        }

        public DataTable GetEmailData3(int AllocationID)
        {

            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;
            //    //objExe.InvoiceStatuschange.CreatedBy = userId;

            //}

            List<SqlParameter> parameters1 = new List<SqlParameter>();

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@InvoiceItemID",
            //    SqlDbType = SqlDbType.Int,
            //    Value = id,
            //    Direction = System.Data.ParameterDirection.Input
            //});
            parameters1.Add(new SqlParameter()
            {
                ParameterName = "@AllocationID",
                SqlDbType = SqlDbType.Int,
                Value = AllocationID,
                Direction = System.Data.ParameterDirection.Input
            });
            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@RoleId",
            //    SqlDbType = SqlDbType.Int,
            //    Value = RoleId,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@Flag",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 1,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            DataSet dataSet2 = DAL.SqlManager.ExecuteDataSet("Request_Email_ChangeTicketStatus_G", parameters1.ToArray());
            DataTable datatable = dataSet2.Tables[0];


            return datatable;

        }

        public void ReopenRequestMail(RequestListCommonModel objModel)
        {
            // DataTable Dtrecord = GetEmailData(objAddInci.InvoiceItemID ,objAddInci.StatusID);
            DataTable Dtrecord = GetEmailData4(objModel.ReOpenTicketStatus.RequestId);
            string RequestId = "";
            string RequestNo = "";
            string Topic = "";
            string Enterprise = "";
            string Category = "";
            string SubCategory = "";
            string ContactPersonName = "";
            string MobileNo = "";
            string EmailId = "";
            string Severity = "";
            string RequestDescription = "";
            string AllocatorsEmailId = "";
            string TicketAllocatedToEmailId = "";
            string ReOpenedComments = "";

            if (Dtrecord.Rows.Count > 0)
            {
                RequestId = Dtrecord.Rows[0]["RequestId"].ToString();
                RequestNo = Dtrecord.Rows[0]["RequestNo"].ToString();
                Topic = Dtrecord.Rows[0]["Topic"].ToString();
                Enterprise = Dtrecord.Rows[0]["Enterprise"].ToString();
                Category = Dtrecord.Rows[0]["Category"].ToString();
                SubCategory = Dtrecord.Rows[0]["SubCategory"].ToString();
                ContactPersonName = Dtrecord.Rows[0]["ContactPersonName"].ToString();
                MobileNo = Dtrecord.Rows[0]["MobileNo"].ToString();
                EmailId = Dtrecord.Rows[0]["EmailId"].ToString();
                Severity = Dtrecord.Rows[0]["Severity"].ToString();
                RequestDescription = Dtrecord.Rows[0]["RequestDescription"].ToString();
                AllocatorsEmailId = Dtrecord.Rows[0]["AllocatorsEmailId"].ToString();
                TicketAllocatedToEmailId = Dtrecord.Rows[0]["TicketAllocatedToEmailId"].ToString();
                ReOpenedComments = Dtrecord.Rows[0]["ReOpenedComments"].ToString();

                //if (Dtrecord.Rows[0]["EmailId"].ToString() != " ")
                //    Emailids += Dtrecord.Rows[0]["EmailId"].ToString();
            }

            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //Send mail using email template 


            string subject = "Raised Request is Reopened by " + userdetail.EmployeeName;

            string EmailHTML = string.Empty;
            string EmailTemplatePath = ConfigurationManager.AppSettings["ReopenedRequest"];
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(EmailTemplatePath)))
            {
                EmailHTML = reader.ReadToEnd();
            }

            EmailHTML = EmailHTML.Replace("#?RequestId?#", RequestId);
            EmailHTML = EmailHTML.Replace("#?RequestNo?#", RequestNo);
            EmailHTML = EmailHTML.Replace("#?Topic?#", Topic);
            EmailHTML = EmailHTML.Replace("#?Enterprise?#", Enterprise);
            EmailHTML = EmailHTML.Replace("#?Category?#", Category);
            EmailHTML = EmailHTML.Replace("#?SubCategory?#", SubCategory);
            EmailHTML = EmailHTML.Replace("#?ContactPersonName?#", ContactPersonName);
            EmailHTML = EmailHTML.Replace("#?MobileNo?#", MobileNo);
            EmailHTML = EmailHTML.Replace("#?EmailId?#", EmailId);
            EmailHTML = EmailHTML.Replace("#?Severity?#", Severity);
            EmailHTML = EmailHTML.Replace("#?RequestDescription?#", RequestDescription);
            EmailHTML = EmailHTML.Replace("#?ReOpenedComments?#", ReOpenedComments);

            //Code to send Mail to User
            bool mailresp = Email.SendMail(AllocatorsEmailId, subject, EmailHTML, TicketAllocatedToEmailId);

        }

        public DataTable GetEmailData4(int id)
        {

            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;
            //    //objExe.InvoiceStatuschange.CreatedBy = userId;

            //}

            List<SqlParameter> parameters1 = new List<SqlParameter>();

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@InvoiceItemID",
            //    SqlDbType = SqlDbType.Int,
            //    Value = id,
            //    Direction = System.Data.ParameterDirection.Input
            //});
            parameters1.Add(new SqlParameter()
            {
                ParameterName = "@RequestId",
                SqlDbType = SqlDbType.Int,
                Value = id,
                Direction = System.Data.ParameterDirection.Input
            });
            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@RoleId",
            //    SqlDbType = SqlDbType.Int,
            //    Value = RoleId,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            //parameters1.Add(new SqlParameter()
            //{
            //    ParameterName = "@Flag",
            //    SqlDbType = SqlDbType.Int,
            //    Value = 1,
            //    Direction = System.Data.ParameterDirection.Input
            //});

            DataSet dataSet2 = DAL.SqlManager.ExecuteDataSet("Request_Email_ReopenedDetails_G", parameters1.ToArray());
            DataTable datatable = dataSet2.Tables[0];


            return datatable;

        }

        public ActionResult Demo()
        {
            return View();
        }

    }

}