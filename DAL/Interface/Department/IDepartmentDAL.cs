using Model.Models;
using Model.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Department
{
    public interface IDepartmentDAL
    {

        ResponseInfo SaveDepartmentDAL(DepartmentModel model);

        List<DepartmentModel> GetListDepartmentDAL();

        DepartmentModel GetEditDepartmentDAL(int id);

        ResponseInfo DeleteDepartmentDAL(int id);

        GetDepartmentEmailIdModel GetEscalationEmailIdDAL(int id);

        List<DepartmentModel> GetListDepartmentMappedDAL(int userId);
    }
}
