﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Role
{
    public class GetRoleModel
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleHAbove { get; set; }

        public string RoleHBelow { get; set; }
    }
}
