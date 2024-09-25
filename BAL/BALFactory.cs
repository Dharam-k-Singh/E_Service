using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using BAL.Concreate;
using DAL.Interface;
using DAL.Concreate;
using DAL;
using DAL.Interface.UserCreation;
using DAL.Concreate.UserCreation;

using DAL.Interface.ListOfCategory;
using DAL.Concreate.ListOfCategory;
using DAL.Concreate.Organization;
using DAL.Interface.Organization;
using DAL.Interface.RequestForm;
using DAL.Concreate.RequestForm;
using DAL.Interface.Campaign;
using DAL.Concreate.Campaign;
using DAL.Interface.Survey;
using DAL.Concreate.Survey;
using DAL.Interface.Department;
using DAL.Concreate.Department;
using DAL.Interface.Warehouse;
using DAL.Concreate.Warehouse;
using DAL.Interface.FacilityRTD;
using DAL.Concreate.FacilityRTD;

namespace BAL
{
    public static class BALFactory
    {
        public static IUsersDAL GetUsersDAL()
        {
            return new UsersDAL();
        }

        public static IHomeDAL GetHomeInstance()
        {
            return new HomeDAL();
        }

        public static IUsersDetailDAL GetUserDetailInstance()
        {
            return new UsersDetailDAL();
        }

      
        public static IUtilityDAL GetUtilityInstance()
        {
            return new UtilityDAL();
        }

        public static IMenuDAL GetMenuObject()
        {
            return new MenuDAL();
        }

        public static IListOfValueDAL GetListOfValueInstance()
        {
            return new ListOfValueDAL();
        }
        public static IRoleDAL GetRoleInstance()
        {
            return new RoleDAL();
        }
       
        public static IUserCreationDAL GetUserCreationDALInstance()
        {
            return new UserCreationDAL();
        }

        public static IListOfCategoryDAL GetListOfCategoryInstance()
        {
            return new ListOfCategoryDAL();
        }

        public static IOrganizationDAL GetOrganizationDALInstance()
        {
            return new OrganizationDAL();
        }

        public static IRequestFormDAL GetRequestFormDALInstance()
        {
            return new RequestFormDAL();
        }

        public static ICampaignDAL GetCampaignDALInstance()
        {
            return new CampaignDAL();
        }

        public static ISurveyDAL GetSurveyDALInstance()
        {
            return new SurveyDAL();
        }

        public static IDepartmentDAL GetDepartmentDALInstance()
        {
            return new DepartmentDAL();
        }

        public static IWarehouseDAL GetWarehouseDALInstance()
        {
            return new WarehouseDAL();
        }

        public static IFacilityRTDDAL GetFacilityRTDDALInstance()
        {
            return new FacilityRTDDAL();
        }
    }
}
