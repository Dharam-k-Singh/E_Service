﻿using DAL.Interface;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate
{
    public class UtilityDAL : IUtilityDAL
    {
        public void LogError(ErrorLogModel logModel)
        {
            using (LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities())
            {
                ExceptionLog log = new ExceptionLog();
                log.ExceptionMsg = logModel.ExceptionMsg;
                log.ExceptionURL = logModel.ExceptionURL;
                log.Logdate = System.DateTime.Now;
                entities.ExceptionLogs.Add(log);
                entities.SaveChanges();
            }
        }

        public void ActivityLog(ActivityModel activityModel)
        {
            using (LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities())
            {
                ActivityLog log = new ActivityLog();
                log.ModuleId = activityModel.ModuleId;
                log.RoleId = activityModel.RoleId;
                log.UserId = activityModel.UDID;
                log.Activitydate = System.DateTime.Now;
                log.ActivityType = activityModel.ActivityType;
                log.Remarks = activityModel.Remarks;

                entities.ActivityLogs.Add(log);
                entities.SaveChanges();
            }
        }
    }
}
