using BAL.Interface.Department;
using DAL.Interface.Department;
using Model.Models;
using Model.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.Department
{
    public class DepartmentBAL: IDepartmentBAL
    {
        private IDepartmentDAL _iDepartmentDAL;

        public DepartmentBAL()
        {
            _iDepartmentDAL = BALFactory.GetDepartmentDALInstance();
        }

        public ResponseInfo SaveDepartmentBAL(DepartmentModel model)
        {
            return _iDepartmentDAL.SaveDepartmentDAL(model);
        }

        public List<DepartmentModel> GetListDepartmentBAL()
        {
            return _iDepartmentDAL.GetListDepartmentDAL();
        }

        public DepartmentModel GetEditDepartmentBAL(int id)
        {
            return _iDepartmentDAL.GetEditDepartmentDAL(id);
        }

        public ResponseInfo DeleteDepartmentBAL(int id)
        {
            return _iDepartmentDAL.DeleteDepartmentDAL(id);
        }

        public GetDepartmentEmailIdModel GetEscalationEmailIdBAL(int id)
        {
            return _iDepartmentDAL.GetEscalationEmailIdDAL(id);
        }

        public List<DepartmentModel> GetListDepartmentMappedBAL(int userId)
        {
            return _iDepartmentDAL.GetListDepartmentMappedDAL(userId);
        }
    }
}
