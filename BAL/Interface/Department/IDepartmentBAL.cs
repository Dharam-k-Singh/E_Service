using Model.Models;
using Model.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.Department
{
    public interface IDepartmentBAL
    {
        ResponseInfo SaveDepartmentBAL(DepartmentModel model);

        List<DepartmentModel> GetListDepartmentBAL();

        DepartmentModel GetEditDepartmentBAL(int id);

        ResponseInfo DeleteDepartmentBAL(int id);

        GetDepartmentEmailIdModel GetEscalationEmailIdBAL(int id);

        List<DepartmentModel> GetListDepartmentMappedBAL(int userId);
    }
}
