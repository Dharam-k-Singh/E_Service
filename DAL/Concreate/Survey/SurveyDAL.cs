using DAL.Interface.Survey;
using Model.Models;
using Model.Models.Survey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.Survey
{
    public class SurveyDAL:BaseClassDAL, ISurveyDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        //Survey region start

        public List<GetSurveyModel> GetListSurveyDAL(int id)
        {
            var result = entities.Survey_G(id).ToList();
            List<GetSurveyModel> lstSurvey = Mapping<List<GetSurveyModel>>(result);
            return lstSurvey;
        }

        public ResponseInfo SaveSurveyDAL(SurveyModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

            if (model.SurveyId == 0)
            {
                var result = entities.Survey_CRUD(model.SurveyId, model.CampaignId, model.SurveyName, model.NoOfPages, model.StartDate, model.EndDate, model.Status, model.CreatedBy, 1, OutputParam);
                respInfo.ID = model.SurveyId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {

                var result = entities.Survey_CRUD(model.SurveyId, model.CampaignId, model.SurveyName, model.NoOfPages, model.StartDate, model.EndDate, model.Status, model.UpdatedBy, 2, OutputParam);
                respInfo.ID = model.SurveyId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }

            return respInfo;

        }

        public SurveyModel GetEditSurveyDAL(int id)
        {
            var result = (from survey in entities.M_Survey
                          join campaign in entities.M_Campaign on survey.CampaignId equals campaign.CampaignId
                          where survey.SurveyId == id
                          select new
                          {
                              SurveyId = survey.SurveyId,
                              CampaignId = survey.CampaignId,
                              SurveyName = survey.SurveyName,
                              CampaignName = campaign.CampaignName,
                              NoOfPages = survey.NoOfPages,
                              StartDate = survey.StartDate,
                              EndDate = survey.EndDate,
                              Status = survey.Status,
                              CreatedBy = survey.CreatedBy,
                              CreatedDate = survey.CreatedDate,
                              UpdatedBy = survey.UpdatedBy,
                              UpdatedDate = survey.UpdatedDate,
                              IsActive = survey.IsActive

                          }).FirstOrDefault();
            SurveyModel obj = Mapping<SurveyModel>(result);
            return obj;
        }

        public ResponseInfo DeleteSurveyDAL(int id)
        {
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            ResponseInfo respInfo = new ResponseInfo();
            var res = entities.Survey_D(id, OutputParam);
            respInfo.Status = "";
            respInfo.ID = id;
            respInfo.IsSuccess = true;
            respInfo.Msg = OutputParam.Value.ToString();
            return respInfo;
        }

        //Survey region end

        //Question region start

        public List<GetQuestionModel> GetListQuestionDAL()
        {
            var result = entities.Question_G(0).ToList();
            List<GetQuestionModel> lstQuestion = Mapping<List<GetQuestionModel>>(result);
            return lstQuestion;
        }

        public List<GetQuestionModel> GetQuestionListDAL(int surveyid)
        {
            var result = entities.Question_G(surveyid).ToList();
            List<GetQuestionModel> lstQuestion = Mapping<List<GetQuestionModel>>(result);
            return lstQuestion;
        }
        public ResponseInfo SaveQuestionDAL(QuestionAggregateModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            //ObjectParameter OutputParamQuestionId = new ObjectParameter("QuestionId", typeof(int));
            System.Data.Entity.Core.Objects.ObjectParameter OutQuestionId = new System.Data.Entity.Core.Objects.ObjectParameter("OutQuestionId", typeof(int));

            int QuestionId = 0;

            if (model.QuestionModel.QuestionId == 0)
            {
                var result = entities.Question_CRUD(model.QuestionModel.QuestionId, model.QuestionModel.SurveyId, model.QuestionModel.Question, model.QuestionModel.DisplayOnPageNo, model.QuestionModel.QuestionTypeId, model.QuestionModel.CreatedBy, 1, OutputParam, OutQuestionId);
                QuestionId = (int)OutQuestionId.Value;
                respInfo.ID = model.QuestionModel.QuestionId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {

                var result = entities.Question_CRUD(model.QuestionModel.QuestionId, model.QuestionModel.SurveyId, model.QuestionModel.Question, model.QuestionModel.DisplayOnPageNo, model.QuestionModel.QuestionTypeId, model.QuestionModel.UpdatedBy, 2, OutputParam, OutQuestionId);
                QuestionId = model.QuestionModel.QuestionId;
                respInfo.ID = model.QuestionModel.QuestionId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }

            if (model.QuestionModel.QuestionTypeId == 15)
            {
                model.lstQuestionPollOptionModel = new List<QuestionPollOptionModel>();
                model.lstQuestionPollOptionModel.Add(model.QuestionPollOptionModel);
            }

            if (model.lstQuestionPollOptionModel != null)
                SaveQuestionPollOptions(model.lstQuestionPollOptionModel, QuestionId);

            return respInfo;

        }

        //public QuestionAggregateModel EditQuestionDAL(int id)
        //{
        //    QuestionAggregateModel model = new QuestionAggregateModel();
        //    var result = entities.M_Question.Where(m => m.QuestionId == id).FirstOrDefault();
        //    model.QuestionModel = Mapping<QuestionModel>(result);
        //    if (model.QuestionModel.QuestionTypeId == 15)
        //    {
        //        var result1 = entities.M_QuestionPollOption.Where(m => m.QuestionId == id).FirstOrDefault();
        //        model.QuestionPollOptionModel = Mapping<QuestionPollOptionModel>(result1);
        //    }
        //    if (model.QuestionModel.QuestionTypeId == 14 || model.QuestionModel.QuestionTypeId == 18)
        //    {
        //        var result2 = entities.M_QuestionPollOption.Where(m => m.QuestionId == id).ToList();
        //        model.lstQuestionPollOptionModel = Mapping<List<QuestionPollOptionModel>>(result2);
        //    }
        //    return model;
        //}

        public QuestionModel GetQuestionDetailsDAL(int id)
        {
            var result = entities.M_Question.Where(m => m.QuestionId == id).FirstOrDefault();
            QuestionModel lstDetail = Mapping<QuestionModel>(result);
            return lstDetail;
        }

        public QuestionPollOptionModel GetQuestionPolldetailsDAL(int id)
        {
            var result = entities.M_QuestionPollOption.Where(m => m.QuestionId == id).FirstOrDefault();
            QuestionPollOptionModel lstDetail = Mapping<QuestionPollOptionModel>(result);
            return lstDetail;
        }

        public List<QuestionPollOptionModel> GetQuestionPollListDAL(int id)
        {
            var result = entities.M_QuestionPollOption.Where(m => m.QuestionId == id).ToList();
            List<QuestionPollOptionModel> lstDetail = Mapping<List<QuestionPollOptionModel>>(result);
            return lstDetail;
        }
        public ResponseInfo DeleteQuestionDAL(int id)
        {
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam1 = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            ResponseInfo respInfo = new ResponseInfo();
            var res = entities.Question_D(id, OutputParam);
            var res1 = entities.QuestionPollOption_D(id, OutputParam1);
            respInfo.Status = "";
            respInfo.ID = id;
            respInfo.IsSuccess = true;
            respInfo.Msg = OutputParam.Value.ToString();
            return respInfo;
        }

        private ResponseInfo SaveQuestionPollOptions(List<QuestionPollOptionModel> model, int QuestionId)
        {
            ResponseInfo respInfo = new ResponseInfo();
            respInfo.Status = "";
            respInfo.ID = QuestionId;

            if (model != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("QuestionId", typeof(int));
                dt.Columns.Add("PollOption", typeof(String));
                dt.Columns.Add("QuestionTypeId", typeof(int));
                dt.Columns.Add("EditableTypeId", typeof(int));
                dt.Columns.Add("TotalNoOfRating", typeof(int));
                dt.Columns.Add("StartName", typeof(int));
                dt.Columns.Add("EndName", typeof(int));
                dt.Columns.Add("CreatedBy", typeof(int));

                foreach (QuestionPollOptionModel item in model)
                {
                    dt.Rows.Add(QuestionId, item.PollName, item.QuestionTypeId, item.EditableTypeId, item.TotalNoOfRating, item.StartName, item.EndName, item.CreatedBy);
                }

                ObjectParameter OutputParam = new ObjectParameter("OutError", typeof(string));

                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter()
                {
                    ParameterName = "@PollOptionTable",
                    SqlDbType = SqlDbType.Structured,
                    Value = dt,
                    Direction = System.Data.ParameterDirection.Input
                });

                SqlParameter message = new SqlParameter()
                {
                    ParameterName = "@OutError",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 1000,
                    Direction = System.Data.ParameterDirection.Output
                };
                parameters.Add(message);

                var dtRuleData = SqlManager.ExecuteNonQuery("QuestionPollOption_CRUD", parameters.ToArray());
                string errormessage = message.Value.ToString();

                respInfo.Msg = errormessage;
                respInfo.IsSuccess = true;
            }
            else
            {
                respInfo.IsSuccess = false;
            }

            return respInfo;
        }


        ////Question region end

        //// Assign Survey region start


        public ResponseInfo SaveAssignSurveyDAL(AssignSurveyModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

            var result = entities.AssignSurvey_CRUD(model.AssignSurveyId, model.SurveyId, model.AssignMemberIds, model.SurveyAmount, model.SurveyStatus, model.PaymentStatus, model.CreatedBy, 1, OutputParam);
            respInfo.ID = model.SurveyId;
            respInfo.Status = "";
            respInfo.IsSuccess = true;
            respInfo.Msg = OutputParam.Value.ToString();


            return respInfo;

        }

        public List<GetAssignSurveyModel> ListAssignSurveyDAL(int id)
        {
            var result = entities.AssignSurvey_G(id).ToList();
            List<GetAssignSurveyModel> lstAssignSurvey = Mapping<List<GetAssignSurveyModel>>(result);
            return lstAssignSurvey;
        }

        public ResponseInfo DeleteAssignSurveyDAL(int id)
        {
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            ResponseInfo respInfo = new ResponseInfo();
            var res = entities.AssignSurvey_D(id, OutputParam);
            respInfo.Status = "";
            respInfo.ID = id;
            respInfo.IsSuccess = true;
            respInfo.Msg = OutputParam.Value.ToString();
            return respInfo;
        }


        // Assign Survey region end


        // user Start Survey region start

        public List<GetAssignSurveyModel> GetListAssignSurveyDAL(int userId)
        {
            var result = entities.UserAssignedSurvey_G(userId).ToList();
            List<GetAssignSurveyModel> lstUserAssignedSurvey = Mapping<List<GetAssignSurveyModel>>(result);
            return lstUserAssignedSurvey;
        }

        public List<GetAssignSurveyModel> GetSurveyNotificationDAL(int userId)
        {
            var result = entities.UserAssignedSurvey_G(userId).ToList();
            List<GetAssignSurveyModel> lstUserAssignedSurvey = Mapping<List<GetAssignSurveyModel>>(result);
            return lstUserAssignedSurvey;
        }

        public StartSurveyModel StartUserSurveyDAL(StartSurveyPassIdModel model1)
        {


            StartSurveyModel model = new StartSurveyModel();

            var question = entities.M_Question.Where(x => x.SurveyId == model1.SurveyId && x.DisplayOnPageNo == model1.PageNo && x.IsActive == true).FirstOrDefault();
            model.QuestionModel = Mapping<QuestionModel>(question);

            if (model.QuestionModel != null)
            {

                var questionOption = entities.M_QuestionPollOption.Where(x => x.QuestionId == model.QuestionModel.QuestionId && x.IsActive == true).ToList();
                model.lstQuestionPollOptionModel = Mapping<List<QuestionPollOptionModel>>(questionOption);

                var answer = entities.UserSurveyAnswer_G(model1.AssignSurveyId, model.QuestionModel.QuestionId).FirstOrDefault();
                model.UserSurveyAnswerModel = Mapping<UserSurveyAnswerModel>(answer);
            }
            return model;

        }

        public ResponseInfo SaveUserSurveyAnswerDAL(StartSurveyModel model1)
        {
            ResponseInfo respInfo = new ResponseInfo();

            UserSurveyAnswerModel model = model1.UserSurveyAnswerModel;

            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

            if (model.UserSurveyAnswerId == 0)
            {
                var result = entities.UserSurveyAnswer_CRUD(model.UserSurveyAnswerId, model.AssignSurveyId, model.SurveyId, model.QuestionId, model.Answer, model.Remark, model.CreatedBy, 1, OutputParam);
                respInfo.ID = model.SurveyId;
            }
            else
            {
                var result = entities.UserSurveyAnswer_CRUD(model.UserSurveyAnswerId, model.AssignSurveyId, model.SurveyId, model.QuestionId, model.Answer, model.Remark, model.UpdatedBy, 2, OutputParam);
                respInfo.ID = model.SurveyId;
            }

            respInfo.Status = "";
            respInfo.IsSuccess = true;

            respInfo.Msg = OutputParam.Value.ToString();


            return respInfo;

        }

        public ResponseInfo UpdateAssignSurveyStatusDAL(AssignSurveyModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();


            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));


            var result = entities.UpdateAssignSurveyStatus_CRUD(model.AssignSurveyId, model.AssignMemberIds, model.SurveyStatus, model.PaymentStatus, model.CreatedBy, OutputParam);
            respInfo.ID = model.SurveyId;


            respInfo.Status = "";
            respInfo.IsSuccess = true;

            respInfo.Msg = OutputParam.Value.ToString();


            return respInfo;

        }

        // user Start Survey region End


        public ResponseInfo AllocateSurveyDAL(SurveyModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

            if (model.SurveyId == 0)
            {
                var result = entities.AllocateSurvey_CRUD(model.SurveyId, model.CreatedBy, model.IsActive);
                respInfo.ID = model.SurveyId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {

                var result = entities.AllocateSurvey_CRUD(model.SurveyId, model.CreatedBy, model.IsActive);
                respInfo.ID = model.SurveyId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = "";
            }

            return respInfo;
        }


        public List<GETQuestionAnswer> UserSurveyQuestionAnswerDAL(int id, int UserId)
        {
            var result = entities.UserSurvey_QuestionAnswer_G(id, UserId).ToList();
            List<GETQuestionAnswer> lstUserQASurvey = Mapping<List<GETQuestionAnswer>>(result);
            return lstUserQASurvey;
        }
    }

}

