using Model.Models;
using Model.Models.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.Survey
{
    public interface ISurveyBAL
    {
        ResponseInfo SaveSurveyBAL(SurveyModel model);

        List<GetSurveyModel> GetListSurveyBAL(int id);

        SurveyModel GetEditSurveyBAL(int id);

        ResponseInfo DeleteSurveyBAL(int id);


        ResponseInfo SaveQuestionBAL(QuestionAggregateModel model);

        List<GetQuestionModel> GetListQuestionBAL();

        List<GetQuestionModel> GetQuestionListBAL(int id);

        QuestionModel GetQuestionDetailsBAL(int id);

        QuestionPollOptionModel GetQuestionPolldetailsBAL(int id);

        List<QuestionPollOptionModel> GetQuestionPollListBAL(int id);

        ResponseInfo DeleteQuestionBAL(int id);

        List<GetAssignSurveyModel> GetListAssignSurveyBAL(int userId);

        List<GetAssignSurveyModel> GetSurveyNotificationBAL(int userId);

        StartSurveyModel StartUserSurveyBAL(StartSurveyPassIdModel model);

        ResponseInfo SaveUserSurveyAnswerBAL(StartSurveyModel model);

        ResponseInfo UpdateAssignSurveyStatusBAL(AssignSurveyModel model);


        ResponseInfo SaveAssignSurveyBAL(AssignSurveyModel model);

        List<GetAssignSurveyModel> ListAssignSurveyBAL(int id);

        ResponseInfo DeleteAssignSurveyBAL(int id);

        ResponseInfo AllocateSurveyBAL(SurveyModel model);

        List<GETQuestionAnswer> UserSurveyQuestionAnswerBAL(int id, int UserId);


    }
}
