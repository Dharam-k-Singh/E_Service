using DAL.Interface.Organization;
using Model.Models.Organization;
using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.Organization
{
    public class OrganizationDAL: BaseClassDAL, IOrganizationDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();
            
        public List<OrganizationModel> GetOrganizationIdDAL()
        {

            var result = entities.M_Organization_G().ToList();
            List<OrganizationModel> lstUserList = Mapping<List<OrganizationModel>>(result);
            return lstUserList;
        }

        public List<OrganizationModel> GetOrganizationDetail(int userId)
        {
            var result = entities.M_ListOfEnterprise_G(userId).ToList();
            List<OrganizationModel> lstListOfvalue = Mapping<List<OrganizationModel>>(result);
            return lstListOfvalue;
        }

    }
}
