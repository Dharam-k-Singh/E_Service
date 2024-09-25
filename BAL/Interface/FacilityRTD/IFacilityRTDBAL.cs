using Model.Models;
using Model.Models.FacilityRTD;
using Model.Models.ListOfValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.FacilityRTD
{
    public interface IFacilityRTDBAL
    {

        //List<WeeksListModel> GetWeeksListBAL(PassIdModel model);

        List<WeeksModel> GetWeeksListBAL();
        WeeksListModel GetWeeksDetailsBAL(int id);

        ResponseInfo SaveBAL(FoodDetailsModel model);

        List<WeeksListModel> GetListFoodDetailsBAL();

        EditFoodDetailsModel GetEditFoodDetailsBAL(int yearId, int weekId);

        ViewFoodDetailsModel GetViewFoodDetailsBAL(int yearId, int weekId);

        ViewFoodDetailsModel GetMenuViewDetailsBAL(PassIdModel model);

        ResponseInfo SaveMeterDetailsBAL(MeterReadingModel model);

        List<MeterReadingListModel> GetListMeterDetailsBAL(int? id);

        EditMeterReadingModel GetEditMeterDetailsBAL(int id);
    }
}
