using BAL.Interface.Organization;
using DAL.Interface.Organization;
using Model.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.Organization
{
    public class OrganizationBAL: IOrganizationBAL
    {
        private IOrganizationDAL _iOrganizationDAL;

        public OrganizationBAL()
        {
            _iOrganizationDAL = BALFactory.GetOrganizationDALInstance();
        }

        public List<OrganizationModel> GetOrganizationIdBAL()
        {
            return _iOrganizationDAL.GetOrganizationIdDAL();
        }
        public List<OrganizationModel> GetOrganizationDetail(int userId)
        {
            return _iOrganizationDAL.GetOrganizationDetail(userId);
        }
    }
}
