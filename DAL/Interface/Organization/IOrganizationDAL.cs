using Model.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Organization
{
    public interface IOrganizationDAL
    {

        List<OrganizationModel> GetOrganizationIdDAL();

        List<OrganizationModel> GetOrganizationDetail(int userId);
    }
}
