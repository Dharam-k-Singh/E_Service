using DAL.Interface.Department;
using Model.Models;
using Model.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.Department
{
     public class DepartmentDAL : BaseClassDAL, IDepartmentDAL
    {

        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        public List<DepartmentModel> GetListDepartmentDAL()
        {
            var result = entities.M_Department.Where(m => m.IsActive == true).ToList();
            List<DepartmentModel> lstDepartment = Mapping<List<DepartmentModel>>(result);
            return lstDepartment;
        }

        public ResponseInfo SaveDepartmentDAL(DepartmentModel model)
        {
            ResponseInfo respInfo = new ResponseInfo();

            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));

            if (model.DepartmentId == 0)
            {
                var result = entities.Department_CRUD(model.DepartmentId, model.DepartmentName,model.DepartmentEmailId,model.EscalationEmailLevel1,model.NoOfDaysForEscalation, model.Createdby, 1, OutputParam);
                respInfo.ID = model.DepartmentId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }
            else
            {

                var result = entities.Department_CRUD(model.DepartmentId, model.DepartmentName, model.DepartmentEmailId, model.EscalationEmailLevel1, model.NoOfDaysForEscalation, model.UpdatedBy, 2, OutputParam);
                respInfo.ID = model.DepartmentId;
                respInfo.Status = "";
                respInfo.IsSuccess = true;
                respInfo.Msg = OutputParam.Value.ToString();
            }

            return respInfo;

        }

        public DepartmentModel GetEditDepartmentDAL(int id)
        {
            var result = entities.M_Department.Where(m => m.DepartmentId == id).FirstOrDefault();
            DepartmentModel obj = Mapping<DepartmentModel>(result);
            return obj;
        }

        public ResponseInfo DeleteDepartmentDAL(int id)
        {
            System.Data.Entity.Core.Objects.ObjectParameter OutputParam = new System.Data.Entity.Core.Objects.ObjectParameter("OutError", typeof(string));
            ResponseInfo respInfo = new ResponseInfo();
           // var res = entities.Department_D(id, OutputParam);
            respInfo.Status = "";
            respInfo.ID = id;
            respInfo.IsSuccess = true;
            respInfo.Msg = OutputParam.Value.ToString();
            return respInfo;
        }

        public GetDepartmentEmailIdModel GetEscalationEmailIdDAL(int id)
        {

            var result = entities.DepartmentEscalationEmailId_G(id).FirstOrDefault();
            GetDepartmentEmailIdModel lstdepDetail = Mapping<GetDepartmentEmailIdModel>(result);
            return lstdepDetail;

        }

        public List<DepartmentModel> GetListDepartmentMappedDAL(int userId)
        {

            var result = entities.M_UserDepartmentMappedList_G(userId).ToList();
            List<DepartmentModel> lstdepDetail = Mapping<List<DepartmentModel>>(result);
            return lstdepDetail;

        }
    }
}
