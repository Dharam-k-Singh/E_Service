using Model.Models.ListOfCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.ListOfCategory
{
    public interface IListOfCategoryBAL
    {
       
        List<ListOfCategoryModel> GetListOfCategory(int id);

        List<ListOfCategoryModel> GetListOfSubCategory(int id);

        //List<ListOfCategoryModel> GetListOfLineItems(int id);
    }
}
