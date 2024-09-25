using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class TicketListCommonModel
    {

        public List<TicketListModel> MyTicketList { get; set; }

        public ChangeTicketStatusModel ChangeTicketStatus { get; set; }

        public AllocateToTeamModel AllocateToTeam { get; set; }

        public GetDepartmentReqListModel GetDepartmentList { get; set; }


    }
}
