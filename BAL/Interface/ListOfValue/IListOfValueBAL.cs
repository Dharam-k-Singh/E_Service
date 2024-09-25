using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models.ListOfValue;

namespace BAL.Interface
{
     public interface IListOfValueBAL
    {
        List<ListOfValueModel> GetListOFValueDetail(int id);

        List<ListOfValueModel> GetListOfDepartmentDetail(int userId);

        List<ListOfValueModel> GetListOfValueRTDDetail(int id);

        List<ListOfYearModel> GetListOfYearDetail(Int16 id);
    }
}
