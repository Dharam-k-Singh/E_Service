using DAL.Interface.ListOfCategory;
using Model.Models.ListOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.ListOfCategory
{
    public class ListOfCategoryDAL : BaseClassDAL ,IListOfCategoryDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        //public List<ListOfCategoryModel> GetListOfValue(int id)
        //{
        //    var result = entities.M_LOV_G(id).ToList();
        //    List<ListOfCategoryModel> lstListOfvalue = Mapping<List<ListOfCategoryModel>>(result);
        //    return lstListOfvalue;
        //}
        public List<ListOfCategoryModel> GetListOfCategory(int id)
        {
            var result = entities.M_LOC_G(id).ToList();
            List<ListOfCategoryModel> lstListOfvalue = Mapping<List<ListOfCategoryModel>>(result);
            return lstListOfvalue;
        }

        public List<ListOfCategoryModel> GetListOfSubCategory(int id)
        {
            var result = entities.M_LOC_Sub_G(id).ToList();
            List<ListOfCategoryModel> lstListOfSubcat = Mapping<List<ListOfCategoryModel>>(result);
            return lstListOfSubcat;
        }

        //public List<ListOfCategoryModel> GetListOfCategory(int id)
        //{
        //    var result = entities.M_LOC_BasedonDepartment_G(id).ToList();
        //    List<ListOfCategoryModel> lstListOfBudget = Mapping<List<ListOfCategoryModel>>(result);
        //    return lstListOfBudget;
        //}
        //public List<ListOfCategoryModel> GetListOfLineItems(int id)
        //{
        //    var result = entities.M_LineItems_BasedonsubCategory_G(id).ToList();
        //    List<ListOfCategoryModel> lstListOfBudget = Mapping<List<ListOfCategoryModel>>(result);
        //    return lstListOfBudget;
        //}
    }
}
