using Model.Models;
using Model.Models.Department;
using Model.Models.ListOfValue;
using Model.Models.Organization;
using Model.Models.Role;
using Model.Models.UserCreation;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.APIHelper;
using WEB.Helper;

namespace WEB.Controllers
{
    public class UserCreationController : BaseController
    {

        private void GetMaters()
        {

            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                //objExe.InvoiceStatuschange.CreatedBy = userId;

            }
            List<OrganizationModel> org = WebAPIHelper.CallApi<List<OrganizationModel>>(HttpMethods.Get, "GetOrganization", "Organization", null, null, userId);
            ViewBag.org = new SelectList(org, "OrganizationID", "OrganizationName");

            //For Role dropdown
            List<RoleModel> Roles = WebAPIHelper.CallApi<List<RoleModel>>(HttpMethods.Get, "GetRoleId", "Role");
            ViewBag.Roles = new SelectList(Roles, "RoleId", "RoleName");

            List<RoleModel> EpRoles = WebAPIHelper.CallApi<List<RoleModel>>(HttpMethods.Get, "GetEpRoleId", "Role");
            ViewBag.EpRoles = new SelectList(EpRoles, "RoleId", "RoleName");

            // For userName dropdown
            //List<UserDetailModel> userdetail = WebAPIHelper.CallApi<List<UserDetailModel>>(HttpMethods.Get, "GetUserDetails", "UsersDetail");
            //ViewBag.userdetail = new SelectList(userdetail, "UDID", "EmployeeName");

            //int EventTypeId = (int)Model.CommonEnum.LOV.LOVId.DepartmentType;
            //List<ListOfValueModel> Event = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, EventTypeId);
            //ViewBag.events = new SelectList(Event, "LOVId", "LOVName");

            List<DepartmentModel> department = WebAPIHelper.CallApi<List<DepartmentModel>>(HttpMethods.Get, "GetListDepartment", "Department");
            ViewBag.department = new SelectList(department, "DepartmentId", "DepartmentName");

            List<OrganizationModel> organization = WebAPIHelper.CallApi<List<OrganizationModel>>(HttpMethods.Get, "GetOrganizationId", "Organization");
            ViewBag.organization = new SelectList(organization, "OrganizationID", "OrganizationName");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddLFZUser()
        {
            //UserCreationCommonModel objMainAddUser = new UserCreationCommonModel();

            //objMainAddUser.SaveUser = null;

            GetMaters();
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(UserCreationModel objAddUser, string Save)
        {

            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                // objAddUser.CreatedBy = userId;
            }

           

            if (objAddUser.DepartmentID != null)
                objAddUser.DepartmentIDs = string.Join(",", objAddUser.DepartmentID);


            // UserCreationModel objAddUser = new UserCreationModel();

            //  objAddUser = objMain.UserCreationModel;

            objAddUser.CreatedBy = userId;
                objAddUser.saltKey = helperClass.GeneratePassword(10); //Password Encrypt Here           
                objAddUser.Password = helperClass.EncodePassword(objAddUser.Password.ToString(), objAddUser.saltKey); //Password Encrypt Here

                ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveUser", "UserCreation", objAddUser);


           
            GetMaters();

            if (objAddUser.UDID == 0)
            {
                TempData["Success"] = si.Msg;
                ModelState.Clear();
               // return RedirectToAction("List");
                return View("AddLFZUser");
            }
            else
            {
                ModelState.Clear();
                return View("AddLFZUser", objAddUser);
            }
        }

        [HttpGet]
        public ActionResult ListLFZUser()
        {
            GetMaters();
            List<GetUserCreationModel> lstUserList = WebAPIHelper.CallApi<List<GetUserCreationModel>>(HttpMethods.Get, "GetUserList", "UserCreation");

            return View(lstUserList);

        }

        public ActionResult EditLFZUser(int UDID)
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            UserCreationModel model = WebAPIHelper.CallApi<UserCreationModel>(HttpMethods.Get, "GetUserDetails", "UserCreation", null, UDID);
            model.Password = "";

            string[] deptypes = model.DepartmentIDs.Split(',');
            List<int> DEPIds = new List<int>();
            for (int i = 0; i < deptypes.Length; i++)
            {
                DEPIds.Add(Convert.ToInt32(deptypes[i]));
            }
            model.DepartmentID = DEPIds;

            GetMaters();

            return View("EditLFZUser", model);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserCreationModel objAddUser)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                // objAddUser.CreatedBy = userId;
            }

            if (objAddUser.DepartmentID != null)
                objAddUser.DepartmentIDs = string.Join(",", objAddUser.DepartmentID);

            if (!string.IsNullOrEmpty(objAddUser.Password))
            {
                objAddUser.saltKey = helperClass.GeneratePassword(10); //Password Encrypt Here           
                objAddUser.Password = helperClass.EncodePassword(objAddUser.Password.ToString(), objAddUser.saltKey); //Password Encrypt Here
            }
            

            objAddUser.CreatedBy = userId;

            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveUser", "UserCreation", objAddUser);



            GetMaters();

            TempData["Success"] = si.Msg;
            //ModelState.Clear();

            return View("EditLFZUser", objAddUser);

        }

        public ActionResult AddEpUser()
        {
            //UserCreationCommonModel objMainAddUser = new UserCreationCommonModel();

            //objMainAddUser.SaveUser = null;

            GetMaters();
            return View();
        }

        [HttpPost]
        public ActionResult SaveEPUser(UserCreationCommonModel objMain, string Save)
        {

            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                // objAddUser.CreatedBy = userId;
            }

            EnterpriseCreationModel objAddEPUser = new EnterpriseCreationModel();

            objAddEPUser = objMain.EnterpriseCreationModel;

            objAddEPUser.CreatedBy = userId;
            objAddEPUser.saltKey = helperClass.GeneratePassword(10); //Password Encrypt Here           
            objAddEPUser.Password = helperClass.EncodePassword(objAddEPUser.Password.ToString(), objAddEPUser.saltKey); //Password Encrypt Here

            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveEPUser", "UserCreation", objAddEPUser);



            GetMaters();

            if (objAddEPUser.UDID == 0)
            {
                TempData["Success"] = si.Msg;
                ModelState.Clear();
                // return RedirectToAction("List");
                return View("AddEpUser");
            }
            else
            {
                ModelState.Clear();
                return View("AddEpUser", objAddEPUser);
            }
        }

        [HttpGet]
        public ActionResult ListEPUser()
        {
            GetMaters();
            List<GetEPUserCreationModel> lstUserList = WebAPIHelper.CallApi<List<GetEPUserCreationModel>>(HttpMethods.Get, "GetEPUserList", "UserCreation");

            return View(lstUserList);

        }

        public ActionResult EditEPuser(int UDID)
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            EnterpriseCreationModel GetEPUserEdit = WebAPIHelper.CallApi<EnterpriseCreationModel>(HttpMethods.Get, "GetEPUserDetails", "UserCreation", null, UDID);
            GetEPUserEdit.Password = "";
            GetMaters();

            return View("EditEPuser", GetEPUserEdit);
        }

        [HttpPost]
        public ActionResult UpdateEPUser(EnterpriseCreationModel objAddUser)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                // objAddUser.CreatedBy = userId;
            }
            if (!string.IsNullOrEmpty(objAddUser.Password))
            {
                objAddUser.saltKey = helperClass.GeneratePassword(10); //Password Encrypt Here           
                objAddUser.Password = helperClass.EncodePassword(objAddUser.Password.ToString(), objAddUser.saltKey); //Password Encrypt Here
            }

            objAddUser.CreatedBy = userId;

            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveEPUser", "UserCreation", objAddUser);



            GetMaters();

            TempData["Success"] = si.Msg;
            //ModelState.Clear();
           
            return View("EditEPUser", objAddUser);

        }

        public ActionResult Delete(int UDID)
        {
            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            var rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteUserDetails", "UserCreation", null, UDID);

            TempData["Success"] = rs.Msg;

            return RedirectToAction("ListLFZUser");
        }

        public ActionResult ChangePassword()
        {
            return View(new UserPasswordChangeModel());

        }

        [HttpPost]
        public ActionResult ChangePassword(UserPasswordChangeModel model)
        {
            string OldPassword = "";
            string OldPasswordgenerated = "";
            if (ModelState.IsValid)
            {
                if (Session != null)
                {
                    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                    model.UDID = userdetail.UDID;
                    UserCreationModel GetUserEdit = WebAPIHelper.CallApi<UserCreationModel>(HttpMethods.Get, "GetUserDetails", "UserCreation", null, model.UDID);

                    string OldSaltKey = GetUserEdit.saltKey;
                    OldPassword = GetUserEdit.Password;
                    OldPasswordgenerated = helperClass.EncodePassword(model.OldPassword.ToString(), OldSaltKey); //Password Encrypt Here
                }
                model.SaltKey = helperClass.GeneratePassword(10); //Password Encrypt Here           
                model.Password = helperClass.EncodePassword(model.Password.ToString(), model.SaltKey); //Password Encrypt Here
                if (OldPassword == OldPasswordgenerated)
                {
                    ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SavePassword", "UserCreation", model);
                    TempData["Success"] = "Password updated successfully";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Please enter valid old password.");
                    return View(model);
                }

            }
            else
            {
                return View();
            }
            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;
            //    model.UDID = userId;

            //}
            //ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SavePassword", "UserCreation", model);

            //TempData["Success"] = si.Msg;
            //ModelState.Clear();
            ////if (objMain.GetClaimData.InvoiceItemID != 0)
            ////    objMain = GetInvoiceDetail(objMain.GetClaimData.InvoiceItemID);
            //// return View("List", objMain);
            //return RedirectToAction("Index", "Home");
            //// return View();

        }

        public ActionResult SaveEnterpriseDetails(UserCreationCommonModel objMain, string SaveDetails)
        {
            //int userId = 0;
            //if (Session != null)
            //{
            //    UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //    userId = userdetail.UDID;
            //    objMain.PaymentDetails.Createdby = userId;

            //}
            ResponseInfo SavedinvoiceId = new ResponseInfo();


            if (SaveDetails != null)
            {

               
                ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveEPDetails", "UserCreation", objMain);


                SavedinvoiceId.ID = si.ID;
                SavedinvoiceId.Msg = si.Msg;

            }

            TempData["Success"] = SavedinvoiceId.Msg;

            ModelState.Clear();

            return RedirectToAction("AddEpUser");
        }

        public ActionResult Add()
        {    

            GetMaters();
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            int id = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                //userId = userdetail.UDID;
                id = userdetail.OrganizationID;

            }
            GetMaters();
            List<GetEPUserCreationModel> lstUserList = WebAPIHelper.CallApi<List<GetEPUserCreationModel>>(HttpMethods.Get, "GetEnterpriseUserList", "UserCreation",null,id);

            return View(lstUserList);

        }

        public ActionResult ChangeProfile()
        {
            return View();

        }

        [HttpPost]
        public ActionResult SaveProfile(UserProfileChangeModel model, HttpPostedFileBase ProfileImagePath)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
                 model.UDID = userId;
            }

            string FileName = "";
            String FilePath = ConfigurationManager.AppSettings["EnterpriseImagePath"];
            if (ProfileImagePath != null)
            {
                FileName = Path.GetFileName(ProfileImagePath.FileName);
                //FileName = objprofile.ProfileOrganization + "_" + FileName;
                string _path = Path.Combine(FilePath, FileName);
                ProfileImagePath.SaveAs(Server.MapPath(_path));
                model.ProfileImagePath = FileName;
            }

            ResponseInfo si = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveProfileImage", "UserCreation", model);

            GetMaters();

            TempData["Success"] = si.Msg;
            //ModelState.Clear();

            return RedirectToAction("LogOut", "Account");

        }
    }
}