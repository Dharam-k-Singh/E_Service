using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Department
{
    public class GetDepartmentEmailIdModel
    {

        public int DepartmentId { get; set; }

        public string EscalationEmailLevel1 { get; set; }
    }
}
