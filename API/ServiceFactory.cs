using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BAL;
using BAL.Concreate;
using BAL.Interface;


using BAL.Concreate.UserCreation;

using BAL.Interface.ListOfCategory;
using BAL.Concreate.ListOfCategory;
using BAL.Concreate.Organization;
using BAL.Interface.Organization;
using BAL.Concreate.RequestForm;
using BAL.Interface.RequestForm;
using BAL.Concreate.Campaign;
using BAL.Interface.Campaign;
using BAL.Interface.Survey;
using BAL.Concreate.Survey;
using BAL.Interface.Department;
using BAL.Concreate.Department;
using BAL.Interface.Warehouse;
using BAL.Concreate.Warehouse;
using BAL.Concreate.FacilityRTD;
using BAL.Interface.FacilityRTD;

namespace API
{
    public static class ServiceFactory
    {
        public static IUsersBAL GetBalObject()
        {
            return new UsersBAL();
        }
        public static IUsersDetailBAL GetUsersDetailInstance()
        {
            return new UsersDetailBAL();
        }
        public static IUtilityBAL GetUtilityInstance()
        {
            return new UtilityBAL();
        }
        public static IHomeBAL GetHomeInstance()
        {
            return new HomeBAL();
        }
        public static IMenu GetMenuObject()
        {
            return new Menu();
        }
      
        public static IListOfValueBAL GetListOfValueInstance()
        {
            return new ListOfValueBAL();
        }

        public static IRoleBAL GetRoleInstance()
        {
            return new RoleBAL();
        }
       
        public static IUserCreationBAL GetUserCreationInstance()
        {
            return new UserCreationBAL();
        }

        public static IListOfCategoryBAL GetListOfCategoryInstance()
        {
            return new ListOfCategoryBAL();
        }

        public static IOrganizationBAL GetOrganizationInstance()
        {
            return new OrganizationBAL();
        }

        public static IRequestFormBAL GetRequestFormInstance()
        {
            return new RequestFormBAL();
        }

        public static ICampaignBAL GetCampaignBALInstance()
        {
            return new CampaignBAL();
        }

        public static ISurveyBAL GetSurveyBALInstance()
        {
            return new SurveyBAL();
        }

        public static IDepartmentBAL GetDepartmentBALInstance()
        {
            return new DepartmentBAL();
        }
        public static IWarehouseBAL GetWarehouseBALInstance()
        {
            return new WarehouseBAL();
        }
        public static IFacilityRTDBAL GetFacilityRTDBALInstance()
        {
            return new FacilityRTDBAL();
        }
    }
}