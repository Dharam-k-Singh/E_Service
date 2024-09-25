using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using Model.Models.ListOfValue;

namespace DAL.Concreate
{
    public class ListOfValueDAL:BaseClassDAL, IListOfValueDAL
    {
       // IListOfValueDAL _iListOfvalueDAL;

        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();
        public List<ListOfValueModel> GetListOfValue(int id)
        {
            var result = entities.M_LOV_G(id).ToList();
            List<ListOfValueModel> lstListOfvalue = Mapping<List<ListOfValueModel>>(result);
            return lstListOfvalue;
        } 
        
        public List<ListOfValueModel> GetListOfDepartmentDetail(int userId)
        {
            var result = entities.M_ListOfDepartment_G(userId).ToList();
            List<ListOfValueModel> lstListOfvalue = Mapping<List<ListOfValueModel>>(result);
            return lstListOfvalue;
        }

        public List<ListOfValueModel> GetListOfValueRTDDetail(int id)
        {
            var result = entities.M_LOV_RTD_G(id).ToList();
            List<ListOfValueModel> lstListOfvalue = Mapping<List<ListOfValueModel>>(result);
            return lstListOfvalue;
        }

        public List<ListOfYearModel> GetListOfYearDetail(Int16 id)
        {
            var result = entities.M_Year_G(id).ToList();
            List<ListOfYearModel> lstListOfvalue = Mapping<List<ListOfYearModel>>(result);
            return lstListOfvalue;
        }
    }
}
