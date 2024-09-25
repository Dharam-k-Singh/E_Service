using BAL.Interface.Survey;
using Model.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class SurveyController : ApiController
    {

        private ISurveyBAL _iSurveyBAL;

        SurveyController()
        {
            _iSurveyBAL = ServiceFactory.GetSurveyBALInstance();
        }

        [HttpPost]
        public IHttpActionResult SaveSurvey(SurveyModel model)
        {
            return Ok(_iSurveyBAL.SaveSurveyBAL(model));
        }

        public IHttpActionResult GetListSurvey(int id)
        {
            return Ok(_iSurveyBAL.GetListSurveyBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetEditSurvey(int id)
        {
            return Ok(_iSurveyBAL.GetEditSurveyBAL(id));
        }

        [HttpPost]
        public IHttpActionResult DeleteSurvey(int id)
        {
            return Ok(_iSurveyBAL.DeleteSurveyBAL(id));
        }
        //Survey region end

        //Question region start
        [HttpPost]
        public IHttpActionResult SaveQuestion(QuestionAggregateModel model)
        {
            return Ok(_iSurveyBAL.SaveQuestionBAL(model));
        }

        public IHttpActionResult GetListQuestion()
        {
            return Ok(_iSurveyBAL.GetListQuestionBAL());
        }

        public IHttpActionResult GetQuestionList(int id)
        {
            return Ok(_iSurveyBAL.GetQuestionListBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetQuestionDetails(int id)
        {
            return Ok(_iSurveyBAL.GetQuestionDetailsBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetQuestionPolldetails(int id)
        {
            return Ok(_iSurveyBAL.GetQuestionPolldetailsBAL(id));
        }

        [HttpGet]
        public IHttpActionResult GetQuestionPollList(int id)
        {
            return Ok(_iSurveyBAL.GetQuestionPollListBAL(id));
        }

        [HttpPost]
        public IHttpActionResult DeleteQuestion(int id)
        {
            return Ok(_iSurveyBAL.DeleteQuestionBAL(id));
        }


        public IHttpActionResult GetListAssignSurvey(int userId)
        {
            return Ok(_iSurveyBAL.GetListAssignSurveyBAL(userId));
        }

        public IHttpActionResult GetSurveyNotification(int userId)
        {
            return Ok(_iSurveyBAL.GetSurveyNotificationBAL(userId));
        }

        [HttpPost]
        public IHttpActionResult StartUserSurvey(StartSurveyPassIdModel model)
        {
            return Ok(_iSurveyBAL.StartUserSurveyBAL(model));
        }

        [HttpPost]
        public IHttpActionResult SaveUserSurveyAnswer(StartSurveyModel model)
        {
            return Ok(_iSurveyBAL.SaveUserSurveyAnswerBAL(model));
        }

        [HttpPost]
        public IHttpActionResult UpdateAssignSurveyStatus(AssignSurveyModel model)
        {
            return Ok(_iSurveyBAL.UpdateAssignSurveyStatusBAL(model));
        }


        [HttpPost]
        public IHttpActionResult SaveAssignSurvey(AssignSurveyModel model)
        {
            return Ok(_iSurveyBAL.SaveAssignSurveyBAL(model));
        }

        public IHttpActionResult GetListAssignedSurvey(int id)
        {
            return Ok(_iSurveyBAL.ListAssignSurveyBAL(id));
        }

       
        [HttpPost]
        public IHttpActionResult DeleteAssignSurvey(int id)
        {
            return Ok(_iSurveyBAL.DeleteAssignSurveyBAL(id));
        }

        [HttpPost]
        public IHttpActionResult AllocateSurveyBAL(SurveyModel model)
        {
            return Ok(_iSurveyBAL.AllocateSurveyBAL(model));
        }

        [HttpGet]
        public IHttpActionResult UserSurveyQA(int id, int UserId)
        {
            return Ok(_iSurveyBAL.UserSurveyQuestionAnswerBAL(id, UserId));
        }
    }
}
