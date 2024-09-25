using BAL.Interface.FacilityRTD;
using DAL.Interface.FacilityRTD;
using Model.Models;
using Model.Models.FacilityRTD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.FacilityRTD
{
    public class FacilityRTDBAL: IFacilityRTDBAL
    {
        private IFacilityRTDDAL _iFacilityRTDDAL;


        public FacilityRTDBAL()
        {
            _iFacilityRTDDAL = BALFactory.GetFacilityRTDDALInstance();
        }

        public List<WeeksModel> GetWeeksListBAL()
        {
            return _iFacilityRTDDAL.GetWeeksListDAL();
        }
        //public List<WeeksListModel> GetWeeksListBAL(PassIdModel model)
        //{
        //    return _iFacilityRTDDAL.GetWeeksListDAL(model);
        //}
        public WeeksListModel GetWeeksDetailsBAL(int userId)
        {
            return _iFacilityRTDDAL.GetWeeksDetailsDAL(userId);
        }

        public ResponseInfo SaveBAL(FoodDetailsModel model)
        {
            return _iFacilityRTDDAL.SaveDAL(model);
        }

        public List<WeeksListModel> GetListFoodDetailsBAL()
        {
            return _iFacilityRTDDAL.GetListFoodDetailsDAL();
        }

        public EditFoodDetailsModel GetEditFoodDetailsBAL(int yearId, int weekId)
        {
            return _iFacilityRTDDAL.GetEditFoodDetailsDAL(yearId, weekId);
        }

        public ViewFoodDetailsModel GetViewFoodDetailsBAL(int yearId, int weekId)
        {
            return _iFacilityRTDDAL.GetViewFoodDetailsDAL(yearId, weekId);
        }

        public ViewFoodDetailsModel GetMenuViewDetailsBAL(PassIdModel model)
        {
            return _iFacilityRTDDAL.GetMenuViewDetailsDAL(model);
        }

        public ResponseInfo SaveMeterDetailsBAL(MeterReadingModel model)
        {
            return _iFacilityRTDDAL.SaveMeterDetailsDAL(model);
        }

        public List<MeterReadingListModel> GetListMeterDetailsBAL(int? id)
        {
            return _iFacilityRTDDAL.GetListMeterDetailsDAL(id);
        }

        public EditMeterReadingModel GetEditMeterDetailsBAL(int id)
        {
            return _iFacilityRTDDAL.GetEditMeterDetailsDAL(id);
        }
    }
}
