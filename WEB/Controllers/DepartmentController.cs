using Model.Models;
using Model.Models.Department;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.APIHelper;

namespace WEB.Controllers
{
    public class DepartmentController : BaseController
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
           return View();
        }

        public ActionResult Save(DepartmentModel objmain)
        {
            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                if (objmain.DepartmentId == 0)
                    objmain.Createdby = userdetail.UDID;
                else
                    objmain.UpdatedBy = userdetail.UDID;
            }

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveDepartment", "Department", objmain);

            ModelState.Clear();
            if (rs.Msg == "saved successfully." || rs.Msg == "updated successfully.")
                TempData["Success"] = rs.Msg;
            else
                TempData["Success"] = rs.Msg;
            return RedirectToAction("Add");
        }


        public ActionResult Edit(int id)
        {

            DepartmentModel model = WebAPIHelper.CallApi<DepartmentModel>(HttpMethods.Get, "GetEditDepartment", "Department", null, id);

            return View("Add", model);
        }

        public ActionResult List()
        {
           
            List<DepartmentModel> GetList = WebAPIHelper.CallApi<List<DepartmentModel>>(HttpMethods.Get, "GetListDepartment", "Department");

            return View(GetList);

        }


        public ActionResult Delete(int id)
        {

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteDepartment", "Department", null, id);
           
            TempData["Success"] = rs.Msg;
            return RedirectToAction("List");
        }
    }
}