using BAL.Interface.Survey;
using DAL.Interface.Survey;
using Model.Models;
using Model.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.Survey
{
    public class SurveyBAL : ISurveyBAL
    {

        private ISurveyDAL _iSurveyDAL;

        public SurveyBAL()
        {
            _iSurveyDAL = BALFactory.GetSurveyDALInstance();
        }

        public ResponseInfo SaveSurveyBAL(SurveyModel model)
        {
            return _iSurveyDAL.SaveSurveyDAL(model);
        }

        public List<GetSurveyModel> GetListSurveyBAL(int id)
        {
            return _iSurveyDAL.GetListSurveyDAL(id);
        }

        public SurveyModel GetEditSurveyBAL(int id)
        {
            return _iSurveyDAL.GetEditSurveyDAL(id);
        }

        public ResponseInfo DeleteSurveyBAL(int id)
        {
            return _iSurveyDAL.DeleteSurveyDAL(id);
        }

        public ResponseInfo SaveQuestionBAL(QuestionAggregateModel model)
        {
            return _iSurveyDAL.SaveQuestionDAL(model);
        }

        public List<GetQuestionModel> GetListQuestionBAL()
        {
            return _iSurveyDAL.GetListQuestionDAL();
        }

        public List<GetQuestionModel> GetQuestionListBAL(int id)
        {
            return _iSurveyDAL.GetQuestionListDAL(id);
        }


        public QuestionModel GetQuestionDetailsBAL(int id)
        {
            return _iSurveyDAL.GetQuestionDetailsDAL(id);
        }


        public QuestionPollOptionModel GetQuestionPolldetailsBAL(int id)
        {
            return _iSurveyDAL.GetQuestionPolldetailsDAL(id);
        }


        public List<QuestionPollOptionModel> GetQuestionPollListBAL(int id)
        {
            return _iSurveyDAL.GetQuestionPollListDAL(id);
        }

        public ResponseInfo DeleteQuestionBAL(int id)
        {
            return _iSurveyDAL.DeleteQuestionDAL(id);
        }

        public List<GetAssignSurveyModel> GetListAssignSurveyBAL(int userId)
        {
            return _iSurveyDAL.GetListAssignSurveyDAL(userId);
        }

        public List<GetAssignSurveyModel> GetSurveyNotificationBAL(int userId)
        {
            return _iSurveyDAL.GetSurveyNotificationDAL(userId);
        }

        public StartSurveyModel StartUserSurveyBAL(StartSurveyPassIdModel model)
        {
            return _iSurveyDAL.StartUserSurveyDAL(model);
        }

        public ResponseInfo SaveUserSurveyAnswerBAL(StartSurveyModel model)
        {
            return _iSurveyDAL.SaveUserSurveyAnswerDAL(model);
        }

        public ResponseInfo UpdateAssignSurveyStatusBAL(AssignSurveyModel model)
        {
            return _iSurveyDAL.UpdateAssignSurveyStatusDAL(model);
        }


        public ResponseInfo SaveAssignSurveyBAL(AssignSurveyModel model)
        {
            return _iSurveyDAL.SaveAssignSurveyDAL(model);
        }

        public List<GetAssignSurveyModel> ListAssignSurveyBAL(int id)
        {
            return _iSurveyDAL.ListAssignSurveyDAL(id);
        }

        public ResponseInfo DeleteAssignSurveyBAL(int id)
        {
            return _iSurveyDAL.DeleteAssignSurveyDAL(id);
        }

        public ResponseInfo AllocateSurveyBAL(SurveyModel model)
        {
            return _iSurveyDAL.AllocateSurveyDAL(model);
        }

        public List<GETQuestionAnswer> UserSurveyQuestionAnswerBAL(int id, int UserId)
        {
            return _iSurveyDAL.UserSurveyQuestionAnswerDAL(id, UserId);
        }
    }
}
