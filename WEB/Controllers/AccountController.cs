using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEB.APIHelper;
using Model;
using Model.Models.UserDetail;
using Utility;
using Model.Models;
using System.Configuration;
using System.IO;
using Model.Models.Menu;
using WEB.Helper;

namespace WEB.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            //BaseConfig.Url =HttpContext.Request.Url.ToString();
            BaseConfig.Url = ConfigurationManager.AppSettings["BaseUrl"];

            return View();
        }

        [HttpPost]
        
        public async Task<ActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                UserDetailModel users = new UserDetailModel();
                users.EmailId = login.UserId;
                users.Password = login.Password;
                string a = await GetToken(login);
                if (!string.IsNullOrEmpty(a))
                {
                    var Info = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "CheckLogin", "Home", users);
                    if (Info.Status == "true")
                    {
                        UserDetailModel userdetail = WebAPIHelper.CallApi<UserDetailModel>(HttpMethods.Get, "GetUserDetails", "Account");
                        Session["UserDetails"] = userdetail;
                       //  List<M_Modules> s = await CallApi<List<M_Modules>>(HttpMethods.Get, "/Menu/GetMenu");
                       //  Session["Menu"] = s;
                        if (Session["count"] == null)
                            Session["count"] = "0";
                        //if (userdetail.RoleId == 1 || userdetail.RoleId == 4 || userdetail.RoleId == 6 || userdetail.RoleId == 2 || userdetail.RoleId == 8 || userdetail.RoleId == 9 || userdetail.RoleId == 7 || userdetail.RoleId == 5)
                        //    return RedirectToAction("Dashboard", "Home", new { area = "" });
                        //else
                        //{
                        //    return RedirectToAction("GetInActiveUser", "LoggedIn", new { area = "" });
                        //}
                        return RedirectToAction("Dashboard", "Home", new { area = "" });
                        
                    }
                }             
            }
            TempData["NotValid"] = "Please check username or password";
            ModelState.Clear();
            return View();
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();


            return RedirectToAction("Login", "Account");
        }
    }
}