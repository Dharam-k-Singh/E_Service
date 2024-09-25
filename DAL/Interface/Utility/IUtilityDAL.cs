﻿using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUtilityDAL
    {
        void LogError(ErrorLogModel logModel);

        void ActivityLog(ActivityModel activityModel);
    }
}
