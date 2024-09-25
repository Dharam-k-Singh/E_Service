using DAL.Interface.FacilityRTD;
using Model.Models;
using Model.Models.FacilityRTD;
using Model.Models.ListOfValue;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.FacilityRTD
{
    public class FacilityRTDDAL: BaseClassDAL, IFacilityRTDDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        public List<WeeksModel> GetWeeksListDAL()
        {

            var result = entities.M_Weeks_G().ToList();
            List<WeeksModel> lstUserList = Mapping<List<WeeksModel>>(result);
            return lstUserList;
        }

        //public List<WeeksListModel> GetWeeksListDAL(PassIdModel model)
        //{
        //    var result = entities.M_CurrentWeeks_G(model.Currentdate.Date).ToList();
        //    List<WeeksListModel> lstUserList = Mapping<List<WeeksListModel>>(result);
        //    return lstUserList;
        //}

        public WeeksListModel GetWeeksDetailsDAL(int id)
        {
            var result = entities.M_WeeksDetails_G(id).FirstOrDefault();
            WeeksListModel lstweeks = Mapping<WeeksListModel>(result);
            return lstweeks;
        }


        public ResponseInfo SaveDAL(FoodDetailsModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            if (model.FDId == 0)
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                ObjectParameter OutputParamReqID = new ObjectParameter("FoodDetailsID", typeof(int));

                int FoodDetailsID = 0;


                var result = entities.FoodDetailsRTD_CRUD(model.FDId, model.Year, model.WeekId, model.Monday_Date.Date, model.Monday_BF, model.Monday_L, model.Monday_D,model.Tuesday_Date.Date, model.Tuesday_BF, model.Tuesday_L, 
                    model.Tuesday_D,model.Wednesday_Date.Date, model.Wednesday_BF, model.Wednesday_L, model.Wednesday_D, model.Thursday_Date.Date, model.Thursday_BF,model.Thursday_L, model.Thursday_D,
                    model.Friday_Date.Date, model.Friday_BF,model.Friday_L,model.Friday_D,
                    model.Saturday_Date.Date, model.Saturday_BF,model.Saturday_L,model.Saturday_D, model.Sunday_Date.Date, model.Sunday_BF,model.Sunday_L,model.Sunday_D
                    , model.Createdby, model.IsActive, 1, OutputParamReqID, OutputParam);

                FoodDetailsID = (int)OutputParamReqID.Value;

                respInfo.ID = FoodDetailsID;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {

                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                ObjectParameter OutputParamReqID = new ObjectParameter("FoodDetailsID", typeof(int));

                int FoodDetailsID = 0;

                var result = entities.FoodDetailsRTD_CRUD(model.FDId, model.Year, model.WeekId, model.Monday_Date.Date, model.Monday_BF, model.Monday_L, model.Monday_D, model.Tuesday_Date.Date, model.Tuesday_BF, model.Tuesday_L,
                    model.Tuesday_D, model.Wednesday_Date.Date, model.Wednesday_BF, model.Wednesday_L, model.Wednesday_D, model.Thursday_Date.Date, model.Thursday_BF, model.Thursday_L, model.Thursday_D,
                    model.Friday_Date.Date, model.Friday_BF, model.Friday_L, model.Friday_D,
                    model.Saturday_Date.Date, model.Saturday_BF, model.Saturday_L, model.Saturday_D, model.Sunday_Date.Date, model.Sunday_BF, model.Sunday_L, model.Sunday_D
                    , model.Createdby, model.IsActive, 2, OutputParamReqID, OutputParam);

                // ReqID = model.RequestId;
                FoodDetailsID = (int)OutputParamReqID.Value;

                respInfo.ID = FoodDetailsID;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();

            }

            return respInfo;

        }

        public List<WeeksListModel> GetListFoodDetailsDAL()
        {

            var result = entities.FoodDetailsList_G().ToList();
            List<WeeksListModel> lstUserList = Mapping<List<WeeksListModel>>(result);
            return lstUserList;
        }

        public EditFoodDetailsModel GetEditFoodDetailsDAL(int yearId, int weekId)
        {
            var result = entities.FoodDetailsEdit_G(yearId, weekId).FirstOrDefault();
            EditFoodDetailsModel lstUserList = Mapping<EditFoodDetailsModel>(result);
            return lstUserList;
        }
        public ViewFoodDetailsModel GetViewFoodDetailsDAL(int yearId, int weekId)
        {
            var result = entities.FoodDetailsView_G(yearId, weekId).FirstOrDefault();
            ViewFoodDetailsModel lstUserList = Mapping<ViewFoodDetailsModel>(result);
            return lstUserList;
        }

        public ViewFoodDetailsModel GetMenuViewDetailsDAL(PassIdModel model)
        {
            var result = entities.FoodDetailsTenantView_G(model.Currentdate.Date).FirstOrDefault();
            ViewFoodDetailsModel lstUserList = Mapping<ViewFoodDetailsModel>(result);
            return lstUserList;
        }

        public ResponseInfo SaveMeterDetailsDAL(MeterReadingModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            if (model.MId == 0)
            {
                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                //ObjectParameter OutputParamReqID = new ObjectParameter("FID", typeof(int));

               // int FoodDetailsID = 0;


                var result = entities.MeterDetailsRTD_CRUD(model.MId, model.YearId, model.MonthId, model.CategoryId, model.SubcategoryId, model.MeterReading, model.Createdby, model.IsActive, 1,  OutputParam);

               // FoodDetailsID = (int)OutputParamReqID.Value;

                respInfo.ID = 0;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {

                System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

                //ObjectParameter OutputParamReqID = new ObjectParameter("FoodDetailsID", typeof(int));

                //int FoodDetailsID = 0;

                var result = entities.MeterDetailsRTD_CRUD(model.MId, model.YearId, model.MonthId, model.CategoryId, model.SubcategoryId, model.MeterReading, model.Createdby, model.IsActive, 2,  OutputParam);

                // ReqID = model.RequestId;
               // FoodDetailsID = (int)OutputParamReqID.Value;

               // respInfo.ID = FoodDetailsID;
                respInfo.ID = 0;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();

            }

            return respInfo;

        }

        public List<MeterReadingListModel> GetListMeterDetailsDAL(int? id)
        {

            var result = entities.MeterDetailsView_G(id).ToList();
            List<MeterReadingListModel> lstUserList = Mapping<List<MeterReadingListModel>>(result);
            return lstUserList;
        }

        public EditMeterReadingModel GetEditMeterDetailsDAL(int id)
        {
            var result = entities.MeterDetailsEdit_G(id).FirstOrDefault();
            EditMeterReadingModel lstUserList = Mapping<EditMeterReadingModel>(result);
            return lstUserList;
        }
    }
}
