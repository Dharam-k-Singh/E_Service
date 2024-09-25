using Model.Models.UserDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class DepartmentTicketUserlistModel
    {

        public List<TicketListModel> lstUser { get; set; }

        public List<GetUserDetailModel> lstDep { get; set; }
    }
}
