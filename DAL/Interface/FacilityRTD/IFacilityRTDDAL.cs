using Model.Models;
using Model.Models.FacilityRTD;
using Model.Models.ListOfValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.FacilityRTD
{
    public interface IFacilityRTDDAL
    {
        //List<WeeksListModel> GetWeeksListDAL(PassIdModel model);
        List<WeeksModel> GetWeeksListDAL();

        WeeksListModel GetWeeksDetailsDAL(int id);

        ResponseInfo SaveDAL(FoodDetailsModel model);

        List<WeeksListModel> GetListFoodDetailsDAL();

        EditFoodDetailsModel GetEditFoodDetailsDAL(int yearId, int weekId);

        ViewFoodDetailsModel GetViewFoodDetailsDAL(int yearId, int weekId);

        ViewFoodDetailsModel GetMenuViewDetailsDAL(PassIdModel model);


        ResponseInfo SaveMeterDetailsDAL(MeterReadingModel model);

        List<MeterReadingListModel> GetListMeterDetailsDAL(int? id);

        EditMeterReadingModel GetEditMeterDetailsDAL(int id);
    }
}
