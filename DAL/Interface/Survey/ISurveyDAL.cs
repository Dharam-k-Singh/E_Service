using Model.Models;
using Model.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Survey
{
    public interface ISurveyDAL
    {
        ResponseInfo SaveSurveyDAL(SurveyModel model);

        List<GetSurveyModel> GetListSurveyDAL(int id);

        SurveyModel GetEditSurveyDAL(int id);

        ResponseInfo DeleteSurveyDAL(int id);


        ResponseInfo SaveQuestionDAL(QuestionAggregateModel model);

        List<GetQuestionModel> GetListQuestionDAL();

        List<GetQuestionModel> GetQuestionListDAL(int id);

        QuestionModel GetQuestionDetailsDAL(int id);

        QuestionPollOptionModel GetQuestionPolldetailsDAL(int id);

        List<QuestionPollOptionModel> GetQuestionPollListDAL(int id);

        ResponseInfo DeleteQuestionDAL(int id);

        List<GetAssignSurveyModel> GetListAssignSurveyDAL(int userId);

        List<GetAssignSurveyModel> GetSurveyNotificationDAL(int userId);

        StartSurveyModel StartUserSurveyDAL(StartSurveyPassIdModel model);

        ResponseInfo SaveUserSurveyAnswerDAL(StartSurveyModel model);

        ResponseInfo UpdateAssignSurveyStatusDAL(AssignSurveyModel model);

        ResponseInfo SaveAssignSurveyDAL(AssignSurveyModel model);

        List<GetAssignSurveyModel> ListAssignSurveyDAL(int id);

        ResponseInfo DeleteAssignSurveyDAL(int id);

        ResponseInfo AllocateSurveyDAL(SurveyModel model);

        List<GETQuestionAnswer> UserSurveyQuestionAnswerDAL(int id, int UserId);
    }
}
