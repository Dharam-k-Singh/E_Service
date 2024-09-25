using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interface;
using Model.Models.Account;
using Model.Models.UserDetail;
using Model.User;
using Utility;


namespace DAL.Concreate
{
    public class UsersDAL : BaseClassDAL, IUsersDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        public UserInfo GetUserRole(string userId)
        {
            string role = string.Empty;
            UserInfo user = new UserInfo();
            using (LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities())
            {
                dynamic result = (from ud in entities.UserDetails
                                  join rm in entities.Map_UserRole on ud.UDID equals rm.UDID
                                  join r in entities.M_Role on rm.RoleId equals r.RoleId
                                  where (ud.EmailId == userId)
                                  select new
                                  {
                                      EmployeeName = ud.EmployeeName,
                                      Role = r.RoleName,
                                      EmailId = ud.EmailId,
                                      Id = ud.UDID,
                                      RoleId = r.RoleId,
                                  }).FirstOrDefault();

                var res = Utility.JsonSerializer.Serialization(result);
                user = Utility.JsonSerializer.DeSerialization(res, user);
            }
            return user;
        }

        public UserDetailModel GetUserDetails(int id)
        {
            UserDetailModel userDetails;
            using (LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities())
            {
                if (id != 1)
                {
                    var result = (from ud in entities.UserDetails
                                  join rm in entities.Map_UserRole on ud.UDID equals rm.UDID
                                  join r in entities.M_Role on rm.RoleId equals r.RoleId
                                  where ud.UDID == id
                                  select new
                                  {
                                      EmployeeName = ud.EmployeeName,
                                      Role = r.RoleName,
                                      EmailId = ud.EmailId,
                                      UDID = ud.UDID,
                                      RoleId = r.RoleId,
                                      ReportingToID = ud.ReportingToID,
                                      DepartmentID = ud.DepartmentID,
                                      Password = ud.Password,
                                      MobileNo = ud.MobileNo,
                                      OrganizationID = ud.OrganizationID,
                                      InitialPasswordReset = ud.InitialPasswordReset,
                                      SaltKey = ud.saltKey,
                                      IsHOD=ud.isHOD,
                                      ProfileImagePath = ud.ProfileImagePath
                                  }).FirstOrDefault();

                    userDetails = Mapping<UserDetailModel>(result);
                }
                else
                {
                    var result = (from ud in entities.UserDetails
                                  join rm in entities.Map_UserRole on ud.UDID equals rm.UDID
                                  join r in entities.M_Role on rm.RoleId equals r.RoleId
                                  where ud.UDID == id
                                  select new
                                  {
                                      EmployeeName = ud.EmployeeName,
                                      Role = r.RoleName,
                                      EmailId = ud.EmailId,
                                      UDID = ud.UDID,
                                      RoleId = r.RoleId,
                                      ReportingToID = ud.ReportingToID,
                                      DepartmentID = ud.DepartmentID,
                                      Password = ud.Password,
                                      MobileNo = ud.MobileNo,
                                      OrganizationID = ud.OrganizationID,
                                      InitialPasswordReset = ud.InitialPasswordReset,
                                      SaltKey = ud.saltKey,
                                      IsHOD = ud.isHOD,
                                      ProfileImagePath = ud.ProfileImagePath
                                  }).FirstOrDefault();

                    userDetails = Mapping<UserDetailModel>(result);
                }


            }
            return userDetails;
        }


        public UserDetailModel GetUserDetailsOne(ValididateUser_OnePortal Model)
        {
            UserDetailModel userDetails;
            using (LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities())
            {
                if (Model.Udid != 1)
                {
                    var result = (from ud in entities.UserDetails
                                  join rm in entities.Map_UserRole on ud.UDID equals rm.UDID
                                  join r in entities.M_Role on rm.RoleId equals r.RoleId
                                  where ud.EmailId == Model.EmailID
                                  select new
                                  {
                                      EmployeeName = ud.EmployeeName,
                                      Role = r.RoleName,
                                      EmailId = ud.EmailId,
                                      UDID = ud.UDID,
                                      RoleId = r.RoleId,
                                      ReportingToID = ud.ReportingToID,
                                      DepartmentID = ud.DepartmentID,
                                      Password = ud.Password,
                                      MobileNo = ud.MobileNo,
                                      OrganizationID = ud.OrganizationID,
                                      InitialPasswordReset = ud.InitialPasswordReset,
                                      SaltKey = ud.saltKey,
                                      IsHOD = ud.isHOD,
                                      ProfileImagePath = ud.ProfileImagePath
                                  }).FirstOrDefault();

                    userDetails = Mapping<UserDetailModel>(result);
                }
                else
                {
                    var result = (from ud in entities.UserDetails
                                  join rm in entities.Map_UserRole on ud.UDID equals rm.UDID
                                  join r in entities.M_Role on rm.RoleId equals r.RoleId
                                  where ud.EmailId == Model.EmailID
                                  select new
                                  {
                                      EmployeeName = ud.EmployeeName,
                                      Role = r.RoleName,
                                      EmailId = ud.EmailId,
                                      UDID = ud.UDID,
                                      RoleId = r.RoleId,
                                      ReportingToID = ud.ReportingToID,
                                      DepartmentID = ud.DepartmentID,
                                      Password = ud.Password,
                                      MobileNo = ud.MobileNo,
                                      OrganizationID = ud.OrganizationID,
                                      InitialPasswordReset = ud.InitialPasswordReset,
                                      SaltKey = ud.saltKey,
                                      IsHOD = ud.isHOD,
                                      ProfileImagePath = ud.ProfileImagePath
                                  }).FirstOrDefault();

                    userDetails = Mapping<UserDetailModel>(result);
                }


            }
            return userDetails;
        }

        //public UserRoleDetails GetUserDetails(int id)
        //{
        //    UserRoleDetails userDetails;
        //    using (LFTZ_InvestorPortalEntities entities =new LFTZ_InvestorPortalEntities())
        //    {
        //        var result = entities.Userdetails_G().FirstOrDefault();
        //        userDetails = Mapping<UserRoleDetails>(result);
        //    }
        //    return userDetails;
        //}
        //------------------------------------------------------------------------------------------------------------
        //public Model.Models.UserDetail.UserDetailModel SaveUsersDetails(Model.Models.UserDetail.UserDetailModel users)
        //{
        //    Model.Models.UserDetail.UserDetailModel userDeatails = null;
        //    //UserDetail usr = entities.UserDetails.Where(m => m.EmployeeWorkdayID == users.EmployeeWorkdayID).FirstOrDefault();
        //    //if (usr != null)
        //    //{
        //    //    return usr;
        //    //}
        //    //entities.UserDetails.Add(users);
        //    //entities.SaveChanges();
        //    if (users != null)
        //    {
        //      //  Model.Models.UserDetail result = entities.UserDetails.Where(m => m.EmployeeWorkdayID == users.EmployeeWorkdayID).AsQueryable().FirstOrDefault();
        //       // userDeatails = Mapper.Map<Model.Models.UserDetail.UserDetailModel>(result);
        //    }

        //    return userDeatails;
        //}
    }
}
