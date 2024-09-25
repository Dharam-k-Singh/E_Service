using BAL.Interface.ListOfCategory;
using DAL.Interface.ListOfCategory;
using Model.Models.ListOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.ListOfCategory
{
    public class ListOfCategoryBAL: IListOfCategoryBAL
    {
        private IListOfCategoryDAL _iListOfCategory;

        public ListOfCategoryBAL()
        {
            _iListOfCategory = BALFactory.GetListOfCategoryInstance();
        }

       
        public List<ListOfCategoryModel> GetListOfCategory(int id)
        {
            return _iListOfCategory.GetListOfCategory(id);
        }

        public List<ListOfCategoryModel> GetListOfSubCategory(int id)
        {
            return _iListOfCategory.GetListOfSubCategory(id);
        }

        //public List<ListOfCategoryModel> GetListOfLineItems(int id)
        //{
        //    return _iListOfCategory.GetListOfLineItems(id);
        //}
    }
}
