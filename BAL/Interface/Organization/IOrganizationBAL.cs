using Model.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.Organization
{
     public interface IOrganizationBAL
    {
        List<OrganizationModel> GetOrganizationIdBAL();

        List<OrganizationModel> GetOrganizationDetail(int userId);
    }
}
