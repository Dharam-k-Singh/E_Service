using Model.Models;
using Model.Models.Category;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.APIHelper;

namespace WEB.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Save(CategoryModel objmain)
        {
            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                if (objmain.CategoryID == 0)
                    objmain.Createdby = userdetail.UDID;
                else
                    objmain.Modifiedby = userdetail.UDID;
            }

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveCategory", "Category", objmain);

            ModelState.Clear();
            if (rs.Msg == "saved successfully." || rs.Msg == "updated successfully.")
                TempData["Success"] = rs.Msg;
            else
                TempData["Failure"] = rs.Msg;
            return RedirectToAction("Add");
        }


        public ActionResult Edit(int id)
        {

            CategoryModel model = WebAPIHelper.CallApi<CategoryModel>(HttpMethods.Get, "GetEditCategory", "Category", null, id);

            return View("Add", model);
        }

        public ActionResult List()
        {

            List<CategoryModel> GetList = WebAPIHelper.CallApi<List<CategoryModel>>(HttpMethods.Get, "GetListCategory", "Category");

            return View(GetList);

        }


        public ActionResult Delete(int id)
        {

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteCategory", "Category", null, id);

            TempData["Success"] = rs.Msg;
            return RedirectToAction("List");
        }
    }
}