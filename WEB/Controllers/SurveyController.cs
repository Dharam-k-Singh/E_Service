using DAL.Concreate;
using Model.Models;
using Model.CommonEnum;
using Model.Models.Campaign;
using Model.Models.Survey;
using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data;
using DAL;
using System.Configuration;
using System.IO;
using Utility;
using Model.Models.ListOfValue;
using WEB.Controllers;
using API;
using WEB.APIHelper;

namespace Medsurvey.Controllers
{
    public class SurveyController : BaseController
    {
        // GET: Survey


       // private SurveyDAL _surveyDAL;
       // private CampaignDAL _campaignDAL;
       // private MasterDAL _masterDAL;
       //// private UserDetailDAL _userDetailDAL;

       // public SurveyController()
       // {
       //     _surveyDAL = ServiceFactory.GetSurveyDALInstance();
       //     _campaignDAL = ServiceFactory.GetCampaignDALInstance();
       //     _masterDAL = ServiceFactory.GetMasterDALInstance();
       //     //_userDetailDAL = ServiceFactory.GetUserDetailDALInstance();
       // }

        public ActionResult Index()
        {
            return View();
        }

        private void GetMaters()
        {
            //Dropdown For Campaign dropdown
            //List<CampaignModel> campaign = _campaignDAL.ListCampaignDAL();
            //ViewBag.campaign = new SelectList(campaign, "CampaignId", "CampaignName");



            //Dropdown For Status dropdown
           // int statusid = (int)LOV.LOVId.Status;

            int statusid = (int)LOV.LOVId.Status;
            List<ListOfValueModel> status = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, statusid);
           // List<ListOfValueModel> status = _masterDAL.GetListOfValue(statusid);
            ViewBag.status = new SelectList(status, "LOVId", "LOVName");

            //Dropdown For Question Type dropdown
            //int questiontypeid = (int)LOV.LOVId.QuestionType;
            int questiontypeid = (int)LOV.LOVId.QuestionType;
            List<ListOfValueModel> questiontype = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, questiontypeid);
            //List<ListOfValueModel> questiontype = _masterDAL.GetListOfValue(questiontypeid);
            ViewBag.questiontype = new SelectList(questiontype, "LOVId", "LOVName");

            //Dropdown For Editable Type dropdown
            // int editabletypeid = (int)LOV.LOVId.EditableType;
            int editabletypeid = (int)LOV.LOVId.EditableType;
            List<ListOfValueModel> editabletype = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, editabletypeid);
           // List<ListOfValueModel> editabletype = _masterDAL.GetListOfValue(editabletypeid);
            ViewBag.editabletype = new SelectList(editabletype, "LOVId", "LOVName");

            //Dropdown For Qualification dropdown
            //int qualificationid = (int)LOV.LOVId.Qualification;
            //int questiontypeid = (int)LOV.LOVId.RequestType;
            //List<QualificationModel> qualification = _masterDAL.ListQualificationDAL(qualificationid);
           // ViewBag.qualification = new SelectList(qualification, "QualificationId", "QualificationName");

            //Dropdown For Speciality dropdown
            //int specialityid = (int)LOV.LOVId.Speciality;

           // int questiontypeid = (int)LOV.LOVId.RequestType;
           // List<SpecialityModel> speciality = _masterDAL.ListSpecialityDAL(specialityid);
           // ViewBag.speciality = new SelectList(speciality, "SpecialityId", "SpecialityName");

            //Dropdown For Status dropdown
            // int paymentStatusid = (int)LOV.LOVId.SurveyPaymentStatus;
           // int paymentStatusid = (int)LOV.LOVId.RequestType;
           // List<ListOfValueModel> paymentStatus = WebAPIHelper.CallApi<List<ListOfValueModel>>(HttpMethods.Get, "GetListOfValue", "ListOfValue", null, paymentStatusid);
           //// List<ListOfValueModel> paymentStatus = _masterDAL.GetListOfValue(paymentStatusid);
           // ViewBag.paymentStatus = new SelectList(paymentStatus, "LOVId", "LOVName");
        }

        private void GetMaters1(int CampaignId)
        {
            //Dropdown For Survey dropdown

            List<GetSurveyModel> survey = WebAPIHelper.CallApi<List<GetSurveyModel>>(HttpMethods.Get, "GetListSurvey", "Survey", null, CampaignId);

          //  List<GetSurveyModel> survey = _surveyDAL.ListSurveyDAL(CampaignId);
            ViewBag.survey = new SelectList(survey, "SurveyId", "SurveyName");
        }

        //Survey region start

        public ActionResult AddSurvey(int CampaignId, string CampaignName)
        {
            ViewBag.CampaignId = CampaignId;
            ViewBag.CampaignName = CampaignName;

            GetMaters();

            return View();
        }

        public ActionResult SaveSurvey(SurveyModel model)
        {

            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                model.CreatedBy = userdetail.UDID;
                model.Status = (int)LOV.LOVId.StatusActive;

            }

           // ResponseInfo rs = _surveyDAL.SaveSurveyDAL(model);

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveSurvey", "Survey", model);

            //ModelState.Clear();
            if (rs.Msg == "Survey saved successfully.")
            {
                TempData["Success"] = rs.Msg;
                return RedirectToAction("ListSurvey", new { CampaignId = model.CampaignId });
            }

            else
            {
                TempData["Success"] = rs.Msg;
                GetMaters();
                return View("AddSurvey", model);
            }


        }

        public ActionResult UpdateSurvey(SurveyModel model)
        {

            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                model.UpdatedBy = userdetail.UDID;
            }


            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveSurvey", "Survey", model);
           // ResponseInfo rs = _surveyDAL.SaveSurveyDAL(model);

            //ModelState.Clear();
            if (rs.Msg == "Survey updated successfully.")
            {
                TempData["Success"] = rs.Msg;
                return RedirectToAction("ListSurvey", new { CampaignId = model.CampaignId });
            }

            else
            {
                TempData["Success"] = rs.Msg;
                GetMaters();
                return View("EditSurvey", model);
            }

        }


        public ActionResult EditSurvey(int id)
        {
            SurveyModel model = WebAPIHelper.CallApi<SurveyModel>(HttpMethods.Get, "GetEditSurvey", "Survey", null, id);

            //SurveyModel model = _surveyDAL.EditSurveyDAL(id);
            GetMaters();
            return View(model);
        }

        public ActionResult ListSurvey(int CampaignId)
        {
            Session["CampaignId"] = CampaignId;

            List<GetSurveyModel> lstSurveyModel = WebAPIHelper.CallApi<List<GetSurveyModel>>(HttpMethods.Get, "GetListSurvey", "Survey", null, CampaignId);

           // List<GetSurveyModel> lstSurveyModel = _surveyDAL.ListSurveyDAL(CampaignId);
            return View(lstSurveyModel);
        }

        public ActionResult DeleteSurvey(int id)
        {

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteSurvey", "Survey", null, id);

           // ResponseInfo rs = _surveyDAL.DeleteSurveyDAL(id);
            TempData["Success"] = rs.Msg;
            int CampaignId = 0;
            if (Session["CampaignId"] != null)
                CampaignId = (int)Session["CampaignId"];
            else
                RedirectToAction("LogOut", "Account");
            return RedirectToAction("ListSurvey", new { CampaignId = CampaignId });
        }


        //Survey region end

        //Question region start

        public ActionResult AddQuestion(int CampaignId)
        {
            Session["CampaignId"] = CampaignId;
            GetMaters();
            GetMaters1(CampaignId);
            QuestionAggregateModel model = new QuestionAggregateModel();
            model.lstQuestionPollOptionModel = new List<QuestionPollOptionModel>();

            return View(model);

        }

        public ActionResult SaveQuestion(QuestionAggregateModel model, string polloptions)
        {

            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                model.QuestionModel.CreatedBy = userdetail.UDID;
               // model.Ed = (int)LOV.LOVId.StatusActive;

            }

            if (model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.OneTo10Rating)
            {
                model.QuestionPollOptionModel.QuestionTypeId = model.QuestionModel.QuestionTypeId;
                model.QuestionPollOptionModel.CreatedBy = userdetail.UDID;
            }

            else if (model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.MCQwithMultipleChoice)
            {

                if (polloptions != null && polloptions != "")
                {
                    //string[] options = polloptions.Split('$$$$');

                    string[] options = polloptions.Split(new string[] { "$$$$" }, StringSplitOptions.None);

                    List<QuestionPollOptionModel> lstopt = new List<QuestionPollOptionModel>();


                    for (int i = 0; i < options.Length; i++)
                    {
                        //object obj = diagn[i];
                        //object[] obj = (object[])arrObj[i];

                        //string[] options = lstoptions[i].Split('#');

                        //int temp = 0;
                        //if (int.TryParse(diagnprop[0], out temp))
                        //{

                        //}
                        //else
                        //{
                        //    temp = 254;
                        //}
                        QuestionPollOptionModel polop = new QuestionPollOptionModel()
                        {
                            PollName = options[i],
                            QuestionTypeId = model.QuestionModel.QuestionTypeId,
                            CreatedBy = userdetail.UDID
                        };
                        lstopt.Add(polop);
                    }
                    model.lstQuestionPollOptionModel = lstopt;
                }

            }

            else if (model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.MCQ)
            {

                if (polloptions != null && polloptions != "")
                {
                    //string[] options = polloptions.Split('$');

                    string[] options = polloptions.Split(new string[] { "$$$$" }, StringSplitOptions.None);

                    List<QuestionPollOptionModel> lstopt = new List<QuestionPollOptionModel>();


                    for (int i = 0; i < options.Length; i++)
                    {


                        // string[] op = options[i].Split('#');

                        int temp = (int)LOV.LOVId.NotEditable;
                        //if (int.TryParse(op[1], out temp))
                        //{

                        //}
                        //else
                        //{
                        //    //temp = 254;
                        //}
                        QuestionPollOptionModel polop = new QuestionPollOptionModel()
                        {
                            PollName = options[i],
                            EditableTypeId = temp,
                            QuestionTypeId = model.QuestionModel.QuestionTypeId,
                            CreatedBy = userdetail.UDID
                        };
                        lstopt.Add(polop);
                    }
                    model.lstQuestionPollOptionModel = lstopt;
                }

            }

            else if (model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.RatingTable || model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.MarkingTable)
            {

                if (polloptions != null && polloptions != "")
                {
                    //string[] options = polloptions.Split('$');

                    string[] options = polloptions.Split(new string[] { "$$$$" }, StringSplitOptions.None);

                    List<QuestionPollOptionModel> lstopt = new List<QuestionPollOptionModel>();


                    for (int i = 0; i < options.Length; i++)
                    {


                        // string[] op = options[i].Split('#');

                        int temp = (int)LOV.LOVId.NotEditable;
                        //if (int.TryParse(op[1], out temp))
                        //{

                        //}
                        //else
                        //{
                        //    //temp = 254;
                        //}
                        QuestionPollOptionModel polop = new QuestionPollOptionModel()
                        {
                            PollName = options[i],
                            EditableTypeId = temp,
                            QuestionTypeId = model.QuestionModel.QuestionTypeId,
                            TotalNoOfRating = model.QuestionPollOptionModel.TotalNoOfRating,
                            StartName = model.QuestionPollOptionModel.StartName,
                            EndName = model.QuestionPollOptionModel.EndName,
                            CreatedBy = userdetail.UDID
                        };
                        lstopt.Add(polop);
                    }
                    model.lstQuestionPollOptionModel = lstopt;
                }

            }


            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveQuestion", "Survey", model);

           // ResponseInfo rs = _surveyDAL.SaveQuestionDAL(model);



            int CampaignId = 0;
            if (Session["CampaignId"] != null)
                CampaignId = (int)Session["CampaignId"];
            else
                RedirectToAction("List", "Campaign");

            //ModelState.Clear();
            if (rs.Msg == "Question saved successfully.")
            {

                ModelState.Clear();
                TempData["Success"] = rs.Msg;
                return RedirectToAction("AddQuestion", new { CampaignId = CampaignId });
            }

            else
            {
                TempData["Success"] = rs.Msg;
                GetMaters();
                GetMaters1(CampaignId);
                return View("AddQuestion", model);
            }


        }

        public ActionResult UpdateQuestion(QuestionAggregateModel model, string polloptions)
        {
               
            UserDetailModel userdetail = new UserDetailModel();
            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                model.QuestionModel.UpdatedBy = userdetail.UDID;
            }


            if (model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.OneTo10Rating)
            {
                model.QuestionPollOptionModel.QuestionTypeId = model.QuestionModel.QuestionTypeId;
                model.QuestionPollOptionModel.CreatedBy = userdetail.UDID;
            }

            else if (model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.MCQwithMultipleChoice)
            {

                if (polloptions != null && polloptions != "")
                {
                    string[] options = polloptions.Split('$');

                    List<QuestionPollOptionModel> lstopt = new List<QuestionPollOptionModel>();


                    for (int i = 0; i < options.Length; i++)
                    {
                        //object obj = diagn[i];
                        //object[] obj = (object[])arrObj[i];

                        //string[] options = lstoptions[i].Split('#');

                        //int temp = 0;
                        //if (int.TryParse(diagnprop[0], out temp))
                        //{

                        //}
                        //else
                        //{
                        //    temp = 254;
                        //}
                        QuestionPollOptionModel polop = new QuestionPollOptionModel()
                        {
                            PollName = options[i],
                            QuestionTypeId = model.QuestionModel.QuestionTypeId,
                            CreatedBy = userdetail.UDID
                        };
                        lstopt.Add(polop);
                    }
                    model.lstQuestionPollOptionModel = lstopt;
                }

            }

            else if (model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.MCQ)
            {

                if (polloptions != null && polloptions != "")
                {
                    string[] options = polloptions.Split('$');

                    List<QuestionPollOptionModel> lstopt = new List<QuestionPollOptionModel>();


                    for (int i = 0; i < options.Length; i++)
                    {


                        string[] op = options[i].Split('#');

                        int temp = (int)LOV.LOVId.NotEditable;
                        if (int.TryParse(op[1], out temp))
                        {

                        }
                        else
                        {
                            //temp = 254;
                        }
                        QuestionPollOptionModel polop = new QuestionPollOptionModel()
                        {
                            PollName = op[0],
                            EditableTypeId = temp,
                            QuestionTypeId = model.QuestionModel.QuestionTypeId,
                            CreatedBy = userdetail.UDID
                        };
                        lstopt.Add(polop);
                    }
                    model.lstQuestionPollOptionModel = lstopt;
                }

            }

            else if (model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.RatingTable || model.QuestionModel.QuestionTypeId == (int)LOV.LOVId.MarkingTable)
            {

                if (polloptions != null && polloptions != "")
                {
                    //string[] options = polloptions.Split('$');

                    string[] options = polloptions.Split(new string[] { "$$$$" }, StringSplitOptions.None);

                    List<QuestionPollOptionModel> lstopt = new List<QuestionPollOptionModel>();


                    for (int i = 0; i < options.Length; i++)
                    {


                        // string[] op = options[i].Split('#');

                        int temp = (int)LOV.LOVId.NotEditable;
                        //if (int.TryParse(op[1], out temp))
                        //{

                        //}
                        //else
                        //{
                        //    //temp = 254;
                        //}
                        QuestionPollOptionModel polop = new QuestionPollOptionModel()
                        {
                            PollName = options[i],
                            EditableTypeId = temp,
                            QuestionTypeId = model.QuestionModel.QuestionTypeId,
                            TotalNoOfRating = model.QuestionPollOptionModel.TotalNoOfRating,
                            StartName = model.QuestionPollOptionModel.StartName,
                            EndName = model.QuestionPollOptionModel.EndName,
                            CreatedBy = userdetail.UDID
                        };
                        lstopt.Add(polop);
                    }
                    model.lstQuestionPollOptionModel = lstopt;
                }

            }

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveQuestion", "Survey", model);


            int CampaignId = 0;
            if (Session["CampaignId"] != null)
                CampaignId = (int)Session["CampaignId"];
            else
                RedirectToAction("List", "Campaign");

            //ModelState.Clear();
            if (rs.Msg == "Question updated successfully.")
            {
                ModelState.Clear();
                TempData["Success"] = rs.Msg;
                return RedirectToAction("ListQuestion", new { CampaignId = CampaignId });
            }

            else
            {
                TempData["Success"] = rs.Msg;
                GetMaters();
                GetMaters1(CampaignId);
                return View("EditQuestion", model);
            }

        }



        public QuestionAggregateModel GetQuestionDetail(int id)
        {
            int userId = 0;
            if (Session != null)
            {
                UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
            }

            QuestionAggregateModel objcommMain = new QuestionAggregateModel();

            QuestionModel Question = WebAPIHelper.CallApi<QuestionModel>(HttpMethods.Get, "GetQuestionDetails", "Survey", null, id);
            objcommMain.QuestionModel = Question;

            QuestionPollOptionModel Poll = WebAPIHelper.CallApi<QuestionPollOptionModel>(HttpMethods.Get, "GetQuestionPolldetails", "Survey", null, id);
            objcommMain.QuestionPollOptionModel = Poll;

            List<QuestionPollOptionModel> IstPollList = WebAPIHelper.CallApi<List<QuestionPollOptionModel>>(HttpMethods.Get, "GetQuestionPollList", "Survey", null, id);
            objcommMain.lstQuestionPollOptionModel = IstPollList;

            return objcommMain;

        }
        public ActionResult EditQuestion(int id)
        {

            //QuestionAggregateModel model = _surveyDAL.EditQuestionDAL(id);


            UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];

            GetMaters();

            //-----For display data
            QuestionAggregateModel model = new QuestionAggregateModel();

            model = GetQuestionDetail(id);


            GetMaters();
            int CampaignId = 0;
            if (Session["CampaignId"] != null)
                CampaignId = (int)Session["CampaignId"];
            else
                RedirectToAction("List", "Campaign");
            GetMaters1(CampaignId);
            return View(model);
        }

        public ActionResult ListQuestion(int CampaignId)
        {
            Session["CampaignId"] = CampaignId;
            //List<GetQuestionModel> lstQuestionModel = _surveyDAL.ListQuestionDAL();

            List<GetQuestionModel> lstQuestionModel = WebAPIHelper.CallApi<List<GetQuestionModel>>(HttpMethods.Get, "GetListQuestion", "Survey");

            //GetSurveyModel model = new GetSurveyModel();
            GetMaters1(CampaignId);
            return View();
        }

        public JsonResult GetQuestionList(int SurveyId)
        {


            List<GetQuestionModel> lstQuestionModel = WebAPIHelper.CallApi<List<GetQuestionModel>>(HttpMethods.Get, "GetQuestionList", "Survey", null, SurveyId);

           // List<GetQuestionModel> lstQuestionModel = _surveyDAL.ListQuestionDAL(SurveyId);

            return Json(lstQuestionModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteQuestion(int id)
        {

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteQuestion", "Survey", null, id);

            //ResponseInfo rs = _surveyDAL.DeleteQuestionDAL(id);
            TempData["Success"] = rs.Msg;
            int CampaignId = 0;
            if (Session["CampaignId"] != null)
                CampaignId = (int)Session["CampaignId"];
            else
                RedirectToAction("List", "Campaign");
            return RedirectToAction("ListQuestion", new { CampaignId = CampaignId });
        }

        //Question region end

        // Assign Survey region start

        //public ActionResult AssignSurvey(int id, string SurveyName)
        //{
        //    ViewBag.SurveyName = SurveyName;
        //    ViewBag.SurveyId = id;

        //    Session["SurveyName"] = SurveyName;
        //    Session["SurveyId"] = id;

        //    AssignSurveyAggregateModel model = new AssignSurveyAggregateModel();

        //    List<GetAssignSurveyModel> ListSurvey = WebAPIHelper.CallApi<List<GetAssignSurveyModel>>(HttpMethods.Get, "GetListAssignedSurvey", "Survey", null, id);

        //    model.lstGetAssignSurveyModel = ListSurvey;

        //    GetMaters();
        //    return View(model);
        //}

        public ActionResult AssignSurvey(int id, string SurveyName)
        {
            SurveyModel objModel = new SurveyModel();
            UserDetailModel userdetail = new UserDetailModel();

            if (Session != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                objModel.CreatedBy = userdetail.UDID;
                objModel.SurveyId = id;
                objModel.IsActive = true;
                objModel.Status = (int)LOV.LOVId.StatusActive;

            }

            ViewBag.SurveyName = SurveyName;
            ViewBag.SurveyId = id;

            Session["SurveyName"] = SurveyName;
            Session["SurveyId"] = id;

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "AllocateSurveyBAL", "Survey", objModel);

            AssignSurveyAggregateModel model = new AssignSurveyAggregateModel();

            List<GetAssignSurveyModel> ListSurvey = WebAPIHelper.CallApi<List<GetAssignSurveyModel>>(HttpMethods.Get, "GetListAssignedSurvey", "Survey", null, id);

            model.lstGetAssignSurveyModel = ListSurvey;

            GetMaters();
            return View(model);
        }

        //public JsonResult GetDoctorList(int SurveyId, int qualificationId, int specialityId)
        //{
        //    List<UserDetailModel> lstQuestionModel = _userDetailDAL.ListUserDetailDAL((int)LOV.LOVId.DepartmentType, SurveyId, qualificationId, specialityId);
        //    return Json(lstQuestionModel, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult SaveAssignSurvey(AssignSurveyAggregateModel model)
        {

            UserDetailModel userdetail = new UserDetailModel();
            if (Session["UserDetails"] != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                model.AssignSurveyModel.CreatedBy = userdetail.UDID;
                //model.Ed = (int)LOV.LOVId.StatusActive;
            }
            else
                RedirectToAction("LogOut", "Account");

            AssignSurveyModel mod = new AssignSurveyModel();


            mod.SurveyStatus = (int)LOV.LOVId.SurveyStatus_Pending;

            // model.AssignSurveyModel.PaymentStatus = (int)LOV.LOVId.SurveyPaymentStatus_Unpaid;

            // model.AssignSurveyModel.SurveyStatus = (int)LOV.LOVId.WorkStatus;

            mod.PaymentStatus = (int)LOV.LOVId.WorkStatus;
            mod.CreatedBy = userdetail.UDID;

            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveAssignSurvey", "Survey", mod);

            // ResponseInfo rs = _surveyDAL.SaveAssignSurveyDAL(model.AssignSurveyModel);

            //ModelState.Clear();

            TempData["Success"] = rs.Msg;

            //mail part
            //if (rs.Msg == "Survey assigned successfully.")
            //{
            //    GetAssigneeMailDetail(model.AssignSurveyModel.SurveyId, model.AssignSurveyModel.AssignMemberIds);
            //}




            //else
            //{
            //    TempData["Success"] = rs.Msg;
            //    return View("AddQuestion", model);
            //}
            return RedirectToAction("AssignSurvey", new { id = Convert.ToInt32(Session["SurveyId"]), SurveyName = Session["SurveyName"].ToString() });

        }

        //public List<GetAssignSurveyModel> ListAssignSurvey(int id)
        //{

        //    List<GetAssignSurveyModel> lstGetAssignSurveyModel = WebAPIHelper.CallApi<List<GetAssignSurveyModel>>(HttpMethods.Get, "ListAssignSurvey", "Survey", null, id);

        //    // List<GetAssignSurveyModel> lstGetAssignSurveyModel = _surveyDAL.ListAssignSurveyDAL(id);

        //    return lstGetAssignSurveyModel;
        //}

        public ActionResult DeleteAssignSurvey(int id, string SurveyName)
        {


            ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "DeleteAssignSurvey", "Survey", null, id);

           // ResponseInfo rs = _surveyDAL.DeleteAssignSurveyDAL(id);
            TempData["Success"] = rs.Msg;
            return RedirectToAction("AssignSurvey", new { id = Convert.ToInt32(Session["SurveyId"]), SurveyName = SurveyName = Session["SurveyName"].ToString() });
        }

        private void MailtoAssignee(string AssignMemberIds)
        {

        }

        //private void GetAssigneeMailDetail(int SurveyId, string AssignMemberIds)
        //{
        //    //Fetching Mail Detail of Survey Assigned member detail

        //    List<SqlParameter> parameters = new List<SqlParameter>();

        //    parameters.Add(new SqlParameter()
        //    {
        //        ParameterName = "@SurveyId",
        //        SqlDbType = SqlDbType.Int,
        //        Value = SurveyId,
        //        Direction = System.Data.ParameterDirection.Input
        //    });

        //    parameters.Add(new SqlParameter()
        //    {
        //        ParameterName = "@AssignMemberIds",
        //        SqlDbType = SqlDbType.VarChar,
        //        Value = AssignMemberIds,
        //        Direction = System.Data.ParameterDirection.Input
        //    });

        //    //parameters.Add(message);

        //    DataSet mailDetail = SqlManager.ExecuteDataSet("AssigneeMailDetail_G", parameters.ToArray());

        //    // send mail to requester region start

        //    string subject = "new survey assigned.";

        //    string emailTemplatePath = ConfigurationManager.AppSettings["assignsurvey"];


        //    // send Mail Part

        //   if (mailDetail.Tables.Count > 0)

        //       MailtoAssignee(mailDetail.Tables[0], emailTemplatePath, subject);

        //    // send mail to requester region end


        //}

        //private bool MailtoAssignee(DataTable dt, string emailTemplatePath, string subject)
        //{
        //    bool mailresp = false;
        //    //send mail 
        //    //Code to send mail.

        //    //Send mail using email template 
        //    string EmailHTML = string.Empty;

        //    using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(emailTemplatePath)))
        //    {
        //        EmailHTML = reader.ReadToEnd();
        //    }


        //    string mailid = "";
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            if (i == 0)
        //            {
        //                mailid = dt.Rows[i]["Email_id"].ToString();

        //                EmailHTML = EmailHTML.Replace("#?SurveyName?#", dt.Rows[i]["SurveyName"].ToString());
        //                EmailHTML = EmailHTML.Replace("#?AssignDate?#", Convert.ToDateTime(dt.Rows[i]["AssignDate"]).ToString("dd-MMM-yyyy"));
        //                EmailHTML = EmailHTML.Replace("#?EndDate?#", Convert.ToDateTime(dt.Rows[i]["EndDate"]).ToString("dd-MMM-yyyy"));
        //            }
        //            else
        //                mailid += "," + dt.Rows[i]["Email_id"].ToString();

        //            //replace tags whereever possible and then return the final html


        //        }

        //        mailresp = Email.SendMail(mailid, subject, EmailHTML);
        //    }

        //    return mailresp;
        //}




        // Assign Survey region end

        // User Start Survey region start

        public ActionResult SurveyNotification()
        {
            UserDetailModel userdetail = new UserDetailModel();

            int userId = 0;
            if (Session["UserDetails"] != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;
            }
            else
                RedirectToAction("Logout", "Account");


            List<GetAssignSurveyModel> lst = WebAPIHelper.CallApi<List<GetAssignSurveyModel>>(HttpMethods.Get, "GetSurveyNotification", "Survey", null, null,userId);

            //List<GetAssignSurveyModel> lst = _surveyDAL.SurveyNotificationDAL(userdetail.UDID);

            return View(lst);
        }

        public ActionResult StartSurvey(int AssignSurveyId, int SurveyId, int pageNo, [Optional] int NoOfPages, string SurveyName = "")
        {

            if (pageNo == 1)
            {
                Session["AssignSurveyId"] = AssignSurveyId;
                Session["SurveyId"] = SurveyId;
                Session["NoOfPages"] = NoOfPages;
                Session["SurveyName"] = SurveyName;
            }

            Session["pageNo"] = pageNo;

            StartSurveyPassIdModel mod = new StartSurveyPassIdModel();
            mod.AssignSurveyId = AssignSurveyId;
            mod.SurveyId = SurveyId;
            mod.PageNo = pageNo;

            StartSurveyModel model = WebAPIHelper.CallApi<StartSurveyModel>(HttpMethods.Post, "StartUserSurvey", "Survey", mod);

            //StartSurveyModel model = _surveyDAL.StartSurveyDAL(AssignSurveyId, SurveyId, pageNo);

            return View(model);

        }


        public ActionResult SaveUserSurveyAnswer(StartSurveyModel model, string submit)
        {

            UserDetailModel userdetail = new UserDetailModel();
            if (Session["UserDetails"] != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                if (model.UserSurveyAnswerModel.UserSurveyAnswerId == 0)
                    model.UserSurveyAnswerModel.CreatedBy = userdetail.UDID;
                else
                    model.UserSurveyAnswerModel.UpdatedBy = userdetail.UDID;
            }
            else
                RedirectToAction("Logout", "Account");

            model.UserSurveyAnswerModel.QuestionId = model.QuestionModel.QuestionId;
            model.UserSurveyAnswerModel.SurveyId = model.QuestionModel.SurveyId;
            model.UserSurveyAnswerModel.AssignSurveyId = Convert.ToInt32(Session["AssignSurveyId"]);
            //model.UserSurveyAnswerModel.

            ResponseInfo rs1 = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "SaveUserSurveyAnswer", "Survey", model);

            if (submit == "submit")
            {
                AssignSurveyModel mod = new AssignSurveyModel();
                mod.AssignSurveyId = Convert.ToInt32(Session["AssignSurveyId"]);
                mod.SurveyStatus = (int)LOV.LOVId.SurveyStatus_Complete;
                //mod.PaymentStatus = (int)LOV.LOVId.SurveyPaymentStatus_Unpaid;
                //mod.CreatedBy = userdetail.UserId;           
                mod.CreatedBy = userdetail.UDID;

                ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "UpdateAssignSurveyStatus", "Survey", mod);

                //ResponseInfo rs1 = _surveyDAL.UpdateAssignSurveyStatusDAL(mod);

                // mail integration 
                if (mod.SurveyStatus == (int)LOV.LOVId.SurveyStatus_Complete) {

                    SurveyCompleteionMailtoAdmin(mod.AssignSurveyId);
                }
                return RedirectToAction("SurveyNotification");

            }

           
            //ResponseInfo rs = _surveyDAL.SaveUserSurveyAnswerDAL(model);

            //ModelState.Clear();

            if (Convert.ToInt32(Session["pageNo"]) == 1)
            {
                AssignSurveyModel mod = new AssignSurveyModel();
                mod.AssignSurveyId = Convert.ToInt32(Session["AssignSurveyId"]);
                mod.SurveyStatus = (int)LOV.LOVId.SurveyStatus_Incomplete;
                //mod.PaymentStatus = (int)LOV.LOVId.SurveyPaymentStatus_Unpaid;
                //mod.CreatedBy = userdetail.UserId;
        
                mod.CreatedBy = userdetail.UDID;


                ResponseInfo rs = WebAPIHelper.CallApi<ResponseInfo>(HttpMethods.Post, "UpdateAssignSurveyStatus", "Survey", mod);

                //ResponseInfo rs1 = _surveyDAL.UpdateAssignSurveyStatusDAL(mod);
            }
           


            if (Convert.ToInt32(Session["pageNo"]) != Convert.ToInt32(Session["NoOfPages"]))
                return RedirectToAction("StartSurvey", new { AssignSurveyId = Convert.ToInt32(Session["AssignSurveyId"]), SurveyId = Convert.ToInt32(Session["SurveyId"]), pageNo = Convert.ToInt32(Session["pageNo"]) + 1, NoOfPages = Convert.ToInt32(Session["NoOfPages"]), SurveyName = Session["SurveyName"].ToString() });

            else
                return RedirectToAction("StartSurvey", new { AssignSurveyId = Convert.ToInt32(Session["AssignSurveyId"]), SurveyId = Convert.ToInt32(Session["SurveyId"]), pageNo = Convert.ToInt32(Session["pageNo"]), NoOfPages = Convert.ToInt32(Session["NoOfPages"]), SurveyName = Session["SurveyName"].ToString() });
        }

        //private bool SurveyCompleteionMailtoAdmin(int AssignSurveyId)
        //{
        //    bool mailresp = false;
        //    //send mail 
        //    //Code to send mail.

        //    //List<SqlParameter> parameters = new List<SqlParameter>();

        //    //parameters.Add(new SqlParameter()
        //    //{
        //    //    ParameterName = "@AssignSurveyId",
        //    //    SqlDbType = SqlDbType.Int,
        //    //    Value = AssignSurveyId,
        //    //    Direction = System.Data.ParameterDirection.Input
        //    //});

        //    //parameters.Add(message);

        //    DataSet mailDetail = SqlManager.ExecuteDataSet("SurveyCompletionMailDetail_G", parameters.ToArray());

        //    string emailTemplatePath = ConfigurationManager.AppSettings["surveycompletion"];

        //    string AllocatorsEmailId = "";

        //    string subject = "Survey Completion Notification";

        //    //Send mail using email template 
        //    string EmailHTML = string.Empty;

        //    using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(emailTemplatePath)))
        //    {
        //        EmailHTML = reader.ReadToEnd();
        //    }
        //    DataTable dt = mailDetail.Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        AllocatorsEmailId = dt.Rows[0]["AllocatorsEmailId"].ToString();
        //        EmailHTML = EmailHTML.Replace("#?EmployeeName?#", dt.Rows[0]["EmployeeName"].ToString());
        //        EmailHTML = EmailHTML.Replace("#?SurveyName?#", dt.Rows[0]["SurveyName"].ToString());
        //        EmailHTML = EmailHTML.Replace("#?AssignDate?#", Convert.ToDateTime(dt.Rows[0]["AssignDate"]).ToString("dd-MMM-yyyy"));
        //        EmailHTML = EmailHTML.Replace("#?CompletionDate?#", Convert.ToDateTime(dt.Rows[0]["CompletionDate"]).ToString("dd-MMM-yyyy"));

        //        //replace tags whereever possible and then return the final html

        //        mailresp = Email.SendMail(AllocatorsEmailId, subject, EmailHTML);
        //    }

        //    return true;
        //}


        public void SurveyCompleteionMailtoAdmin(int AssignSurveyId)
        {
            // DataTable Dtrecord = GetEmailData(objAddInci.InvoiceItemID ,objAddInci.StatusID);
            DataTable Dtrecord = GetEmailSurveyData(AssignSurveyId);

            string EmployeeName = "";
            string SurveyName = "";
            string AssignDate = "";
            string CompletionDate = "";
            string AllocatorsEmailId = "";
           

            if (Dtrecord.Rows.Count > 0)
            {
                EmployeeName = Dtrecord.Rows[0]["EmployeeName"].ToString();
                SurveyName = Dtrecord.Rows[0]["SurveyName"].ToString();
                AssignDate = Convert.ToDateTime(Dtrecord.Rows[0]["AssignDate"]).ToString("dd-MMM-yyyy");
                CompletionDate = Convert.ToDateTime(Dtrecord.Rows[0]["CompletionDate"]).ToString("dd-MMM-yyyy");
                AllocatorsEmailId = Dtrecord.Rows[0]["AllocatorsEmailId"].ToString();

                //if (Dtrecord.Rows[0]["EmailId"].ToString() != " ")
                //    Emailids += Dtrecord.Rows[0]["EmailId"].ToString();
            }

           // UserDetailModel userdetail = (UserDetailModel)Session["UserDetails"];
            //Send mail using email template 

            string subject = "Survey Completion Notification";

            string EmailHTML = string.Empty;
            string EmailTemplatePath = ConfigurationManager.AppSettings["surveycompletion"];
            using (StreamReader reader = new StreamReader(EmailTemplatePath))
            {
                EmailHTML = reader.ReadToEnd();
            }

            EmailHTML = EmailHTML.Replace("#?EmployeeName?#", EmployeeName);
            EmailHTML = EmailHTML.Replace("#?SurveyName?#", SurveyName);
            EmailHTML = EmailHTML.Replace("#?AssignDate?#", AssignDate);
            EmailHTML = EmailHTML.Replace("#?CompletionDate?#", CompletionDate);

            //Code to send Mail to User
            bool mailresp = Email.SendMail(AllocatorsEmailId, subject, EmailHTML);

        }

        public DataTable GetEmailSurveyData(int AssignSurveyId)
        {


            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter()
            {
                ParameterName = "@AssignSurveyId",
                SqlDbType = SqlDbType.Int,
                Value = AssignSurveyId,
                Direction = System.Data.ParameterDirection.Input
            });


            DataSet dataSet2 = DAL.SqlManager.ExecuteDataSet("SurveyCompletionMailDetail_G", parameters.ToArray());
            DataTable datatable = dataSet2.Tables[0];


            return datatable;

        }

        // User Start Survey region end


        // Survey Status region start

        public ActionResult Status()
        {
            UserDetailModel userdetail = new UserDetailModel();

            int userId = 0;
            if (Session["UserDetails"] != null)
            {
                userdetail = (UserDetailModel)Session["UserDetails"];
                userId = userdetail.UDID;

            }
            else
                RedirectToAction("Logout", "Account");

            StatusAggregateModel model = new StatusAggregateModel();

            List<GetAssignSurveyModel> lst = WebAPIHelper.CallApi<List<GetAssignSurveyModel>>(HttpMethods.Get, "GetListAssignSurvey", "Survey", null, null, userId);

           // List<GetAssignSurveyModel> lst = _surveyDAL.SurveyNotificationDAL(userdetail.UDID);
            model.lstGetAssignSurveyModel = lst;

            GetMaters();
            return View(model);
        }

        //public ActionResult UpdateSurveyPaymentStatus(StatusAggregateModel model)
        //{

        //    UserDetailModel userdetail = new UserDetailModel();
        //    if (Session != null)
        //    {
        //        userdetail = (UserDetailModel)Session["UserDetails"];
        //        model.AssignSurveyModel.CreatedBy = userdetail.UDID;
        //        //model.Ed = (int)LOV.LOVId.StatusActive;
        //    }



        //    ResponseInfo rs = _surveyDAL.UpdateAssignSurveyStatusDAL(model.AssignSurveyModel);

        //    //ModelState.Clear();

        //    TempData["Success"] = rs.Msg;


        //    //else
        //    //{
        //    //    TempData["Success"] = rs.Msg;
        //    //    return View("AddQuestion", model);
        //    //}
        //    return RedirectToAction("Status");

        //}

        // Survey Status region End

        public ActionResult UserSurveyQA(int UserId, int SurveyId)
        {
            

            List<GETQuestionAnswer> lstQuestionModel = WebAPIHelper.CallApi<List<GETQuestionAnswer>>(HttpMethods.Get, "UserSurveyQA", "Survey", null, SurveyId, UserId);

            return View(lstQuestionModel);
        }
    }
}